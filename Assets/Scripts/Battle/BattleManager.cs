using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BattleManager : MonoBehaviour
{
    CommandManager commandManager;
    BattleLogManager logManager;
    SkillManager skillManager;

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
    int playerHP
    {
        get { return partyManager.GetPlayerStatus_Current(0, DataValidation._status.HP); }
        set { partyManager.ChangePlayerStatus(0, value, DataValidation._status.HP); }
    }
    int playerSTR
    {
        get { return partyManager.GetPlayerStatus_Current(0, DataValidation._status.STR); }
    }
    bool defenseFLG_P = false;

    //エネミーのデータ
    EnemyManager enemyManager;
    int enemyHP
    {
        get { return enemyManager.GetStatus_Current(0, DataValidation._status.HP); }
        set { enemyManager.SetStatus_Change(0, value, DataValidation._status.HP); }
    }
    int enemySTR
    {
        get { return enemyManager.GetStatus_Current(0, DataValidation._status.STR); }
        set { enemyManager.SetStatus_Change(0, value, DataValidation._status.STR); }
    }
    bool defenseFLG_E
    {
        get { return enemyManager.GetStatusEffect(0, DataValidation._statusEffect.Defense); }
    }

    void Start()
    {
        commandManager = GameObject.Find("CommandManager").GetComponent<CommandManager>();
        logManager = GameObject.Find("BattleLogManager").GetComponent<BattleLogManager>();
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        partyManager = GameObject.Find("PartyManager").GetComponent<PartyManager>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    void Update()
    {
        //ロードが必要なものがロードできているか判定
        if (!startFLG && LoadObserver.Instance.loadEnd)
        {
            //パーティの人数をCommandManagerに登録
            //int num = partyManager.GetMemberNum();
            commandManager.SetMemberNum(1);

            TurnEnd();
            startFLG = true;
        }

        //ターンの処理を開始していいか判定
        if (!commandManager.isCommand && !endFLG && startFLG && !isTurn)
        {
            isTurn = true;
            StartCoroutine(Turn());
        }
    }

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

        for (int n = 0; n < 2; n++)
        {
            switch (n)
            {
                case 0:
                    PlayerTurn();
                    if (playerHP <= 0) wipeOutFLG_P = true;
                    else if (enemyHP <= 0) wipeOutFLG_E = true;
                    break;

                case 1:
                    EnemyTurn();
                    if (enemyHP <= 0) wipeOutFLG_E = true;
                    else if (playerHP <= 0) wipeOutFLG_P = true;
                    break;
            }


            yield return new WaitForSeconds(1.0f);

            //どちらかが全滅しているか判定
            if (wipeOutFLG_P || wipeOutFLG_E) break;
        }

        //どちらかが全滅していたら全滅時の処理　そうでなければターン終了処理
        if (wipeOutFLG_P) WipeOut_Player();
        else if (wipeOutFLG_E) WipeOut_Enemy();
        else TurnEnd();
    }

    //プレイヤーキャラのターンの処理
    void PlayerTurn()
    {
        defenseFLG_P = false;

        //int damage = 0;

        switch (commandManager.command[0])
        {
            /*
            case DataValidation._command.Attack:
                if (defenseFLG_E) damage = playerSTR / 2;
                else damage = playerSTR;
                enemyManager.Damage(0, damage);
                logManager.LogDisplay("ダメージ:" + damage);
                break;*/

            case DataValidation._command.Skill:
                int skillID = partyManager.GetPlayerSkill(0, commandManager.commandID[0]);
                skillManager.UseSkill(skillID, 0, 900);
                break;

                /*
            case DataValidation._command.Defense:
                defenseFLG_P = true;
                logManager.LogDisplay("身を守っている。");
                break;

            case DataValidation._command.Item:
                playerHP -= playerHP;
                logManager.LogDisplay("item");
                break;*/

            default:
                break;
        }
    }

    //敵キャラのターンの処理
    void EnemyTurn()
    {
        int damage = 0;
        if (defenseFLG_P) damage = enemySTR / 2;
        else damage = enemySTR;

        //playerHP = -damage;

        logManager.LogDisplay("ダメージ：" + damage);
    }

    //ターン終了時の処理
    void TurnEnd()
    {
        logManager.LogDisplay("PlayerHP:" + playerHP);
        logManager.LogDisplay("EnemyHP:" + enemyHP);
        commandManager.CommandReset();
        isTurn = false;
    }

    //逃げた時の処理
    void Escape()
    {
        endFLG = true;
        logManager.LogDisplay("逃げ出した！");
    }

    //プレイヤーが全滅した時の処理
    void WipeOut_Player()
    {
        endFLG = true;
        logManager.LogDisplay("全滅した……。");
    }

    //敵が全滅した時の処理
    void WipeOut_Enemy()
    {
        endFLG = true;
        logManager.LogDisplay("敵を倒した！");
    }
}
