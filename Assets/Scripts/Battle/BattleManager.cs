using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class BattleManager : MonoBehaviour
{
    CommandManager commandManager;
    BattleLogManager logManager;
    SkillManager skillManager;
    EnemyController enemyController;

    /// <summary>
    /// バトル開始のフラグ
    /// trueになったら開始
    /// </summary>
    bool startFLG = false;
    
    /// <summary>
    /// バトル終了のフラグ
    /// trueになったら終了
    /// </summary>
    bool _endFLG = false;
    public bool endFLG
    {
        get { return _endFLG; }
        private set { _endFLG = value; }
    }

    bool isTurn = false;

    //プレイヤーのデータ
    PartyManager partyManager;
    //エネミーのデータ
    EnemyManager enemyManager;

    //
    List<int> idList = new List<int>();

    List<int> turn = new List<int>();

    void Start()
    {
        commandManager = GameObject.Find("CommandManager").GetComponent<CommandManager>();
        logManager = GameObject.Find("BattleLogManager").GetComponent<BattleLogManager>();
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        partyManager = GameObject.Find("PartyManager").GetComponent<PartyManager>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        enemyController = GameObject.Find("EnemyController").GetComponent<EnemyController>();
    }

    void Update()
    {
        //ロードが必要なものがロードできているか判定
        if (!startFLG && LoadObserver.Instance.loadEnd)
        {
            //パーティの人数をCommandManagerに登録
            int num = partyManager.GetMemberNum();
            commandManager.SetMemberNum(num);

            idList.Add(0);
            idList.Add(1);
            idList.Add(2);
            idList.Add(900);

            TurnEnd();
            startFLG = true;
        }

        //ターンの処理を開始していいか判定
        if (!commandManager.isCommand && !endFLG && startFLG && !isTurn)
        {
            isTurn = true;
            StartCoroutine(Turn());
        }

        if (endFLG && Input.anyKeyDown)
        {
            SceneManager.LoadSceneAsync(1);
        }
    }

    //ターンの処理
    #region
    //ターン全体の流れの処理
    IEnumerator Turn()
    {
        if (commandManager.escapeFLG)
        {
            Escape();
            yield break;
        }

        bool wipeOutFLG_P = false;
        bool wipeOutFLG_E = false;

        Sort();

        for (int n = 0; n < turn.Count; n++)
        {
            if (turn[n] / 100 < 1) PlayerTurn(turn[n]);
            else EnemyTurn();

            yield return new WaitForSeconds(1.0f);

            //プレイヤー側が全滅しているか判定
            int activePlayerMember = PartyManager.Instance.GetActiveMemberNum();
            if (activePlayerMember <= 0) wipeOutFLG_P = true;

            //エネミー側が全滅しているか判定
            int enemyHP = enemyManager.GetStatus_Current(0, DataValidation._status.HP);
            if (enemyHP <= 0) wipeOutFLG_E = true;

            //どちらかが全滅しているか判定
            if (wipeOutFLG_P || wipeOutFLG_E) break;
        }

        //どちらかが全滅していたら全滅時の処理　そうでなければターン終了処理
        if (wipeOutFLG_P) WipeOut_Player();
        else if (wipeOutFLG_E) WipeOut_Enemy();
        else TurnEnd();
    }

    void Sort()
    {
        turn = new List<int>();

        List<int> unfinishedList = new List<int>(idList);
        int max = 0;
        int maxID = 0;

        for (int n = 0; n < idList.Count; n++)
        {
            for (int m = 0; m < unfinishedList.Count; m++)
            {
                int current = GetCharaAGI(unfinishedList[m]);

                if (max < current)
                {
                    max = current;
                    maxID = unfinishedList[m];
                }
                if (max == current)
                {
                    int randomNum = Random.Range(0, 2);
                    if (randomNum < 1)
                    {
                        max = current;
                        maxID = unfinishedList[m];
                    }
                }
            }

            unfinishedList.Remove(maxID);
            turn.Add(maxID);
            max = 0;
        }
    }

    //プレイヤーキャラのターンの処理
    void PlayerTurn(int id)
    {
        switch (commandManager.command[0])
        {
            case DataValidation._command.Skill:
                int skillID = partyManager.GetPlayerSkill(id, commandManager.commandID[id]);
                skillManager.UseSkill(skillID, id, 900);
                break;

            default:
                break;
        }
    }

    //敵キャラのターンの処理
    void EnemyTurn()
    {
        enemyController.EnemyMove();
    }

    //ターン終了時の処理
    void TurnEnd()
    {
        commandManager.CommandReset();
        isTurn = false;
    }

    //逃げた時の処理
    void Escape()
    {
        logManager.LogDisplay("逃げ出した！");
        StartCoroutine(BattleEnd());
    }

    //プレイヤーが全滅した時の処理
    void WipeOut_Player()
    {
        logManager.LogDisplay("全滅した……。");
        StartCoroutine(BattleEnd());
    }

    //敵が全滅した時の処理
    void WipeOut_Enemy()
    {
        logManager.LogDisplay("敵を倒した！");
        StartCoroutine(BattleEnd());
    }

    //バトル終了時の共通処理
    IEnumerator BattleEnd()
    {
        yield return new WaitForSeconds(1.0f);

        endFLG = true;
    }
    #endregion

    //データの取得
    #region
    int GetCharaAGI(int charaID)
    {
        int result = 0;

        if (charaID / 100 < 1)
            result = partyManager.GetPlayerStatus_Current(charaID % 100, DataValidation._status.AGI);
        else 
            result = enemyManager.GetStatus_Current(charaID % 100, DataValidation._status.AGI);

        return result;
    }
    #endregion
}
