using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SkillManager : MonoBehaviour, PerformLoading
{
    SkillDatabase skillDB;

    PartyManager partyManager;
    EnemyManager enemyManager;

    //必要なアセットの読み込み
    #region
    // Addressablesのアドレスを設定
    [Header("SkillDatabaseのアドレス")]
    [SerializeField] string skillDBAddress = "SkillDatabase";

    bool _loadEnd = false;
    public bool loadEnd
    {
        get { return _loadEnd; }
        private set { _loadEnd = value; }
    }

    void Awake()
    {
        // Addressablesを使ってPlayerDatabaseをロード
        Addressables.LoadAssetAsync<SkillDatabase>(skillDBAddress).Completed += OnPlayerDatabaseLoaded;
    }

    void Start()
    {
        partyManager = GameObject.Find("PartyManager").GetComponent<PartyManager>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    // PlayerDatabaseの読み込みが完了した際に呼ばれる
    void OnPlayerDatabaseLoaded(AsyncOperationHandle<SkillDatabase> handle)
    {
        // 成功したら、playerDB変数に代入
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            skillDB = handle.Result;
            loadEnd = true;
        }
    }
    #endregion

    //スキル使用の処理
    public void UseSkill(int skillID, int userID, int targetID)
    {
        DataValidation._skillType skillType = skillDB.skillDatas[skillID].type;

        //スキルの種類によって処理を分岐
        switch (skillType)
        {
            case DataValidation._skillType.Attack:
                UseSkill_Attack(skillID, userID, targetID);
                break;

            case DataValidation._skillType.Heal:
                break;

            case DataValidation._skillType.Buff:
                break;

            case DataValidation._skillType.Move:
                break;
        }
    }

    //攻撃スキル用の処理
    void UseSkill_Attack(int skillID, int userID, int targetID)
    {
        //スキルの対象の判断
        DataValidation._target targetCase = TargetJudge(targetID);

        //対象が敵か味方か、対象のIDを格納する変数
        int team = targetID / 100;
        int target = targetID % 100;

        //ダメージ計算に必要な変数
        DataValidation._status status_Attack;  //スキルの計算に使用するステータスを格納する変数
        DataValidation._status status_Defense;  //スキルの計算に使用するステータスを格納する変数
        int damage = 0;  //ダメージを格納する変数
        int atk = 0;  //攻撃力を格納する変数
        int vit = 0;  //防御力を格納する変数

        //対象ごとの処理の分岐
        switch (targetCase)
        {
            case DataValidation._target.enemy_Once:
                //攻撃威力の算出
                status_Attack = skillDB.skillDatas[skillID].effectFormula_AttackStatus;
                atk = partyManager.GetPlayerStatus_Current(userID, status_Attack);
                atk = (int)(atk * skillDB.skillDatas[skillID].effectFormula_AttackStatus_mul);

                //防御力の算出
                status_Defense = skillDB.skillDatas[skillID].effectFormula_DefenceStatus;
                vit = enemyManager.GetStatus_Current(target, status_Defense);
                vit = (int)(vit * skillDB.skillDatas[skillID].effectFormula_DefenceStatus_mul);

                //ダメージの計算
                damage = DamageCalculator.CalculateDamage(atk, vit);
                //ダメージの付与
                ChangeHP(-damage, team, target);

                //使用テキストの表示
                string useText = skillDB.skillDatas[skillID].useText;
                BattleLogManager.Instance.LogDisplay(useText);

                string text = "{0}は{1}に{2}ダメージ与えた。";
                string userName = partyManager.GetPlayerName(userID);
                string targetName = enemyManager.GetEnemyStatus_Name(target);
                useText = string.Format(text, userName, targetName, damage);
                BattleLogManager.Instance.LogDisplay(useText);
                break;

            case DataValidation._target.enemy_All:
                break;

            case DataValidation._target.enemy_Random:
                break;

            case DataValidation._target.oneself:
                break;

            case DataValidation._target.ally_Once:
                //攻撃威力の算出
                status_Attack = skillDB.skillDatas[skillID].effectFormula_AttackStatus;
                atk = enemyManager.GetStatus_Current(userID, status_Attack);
                atk = (int)(atk * skillDB.skillDatas[skillID].effectFormula_AttackStatus_mul);

                //防御力の算出
                status_Defense = skillDB.skillDatas[skillID].effectFormula_DefenceStatus;
                vit = partyManager.GetPlayerStatus_Current(target, status_Defense);
                vit = (int)(vit * skillDB.skillDatas[skillID].effectFormula_DefenceStatus_mul);

                //ダメージの計算
                damage = DamageCalculator.CalculateDamage(atk, vit);
                //ダメージの付与
                ChangeHP(-damage, team, target);
                break;

            case DataValidation._target.ally_All:
                break;

            case DataValidation._target.ally_Random:
                break;

            default:
                break;
        }
    }

    //対象のHP処理
    void ChangeHP(int changeNum, int team, int target)
    {
        switch (team)
        {
            case Const.Team.Ally:
                partyManager.ChangePlayerStatus(target, changeNum, DataValidation._status.HP);
                break;

            case Const.Team.Enemy:
                enemyManager.SetStatus_Change(target, changeNum, DataValidation._status.HP);
                break;
            default:
                break;
        }
    }

    //使用者のMP処理
    void ChangeMP(int changeNum, int team, int userID)
    {
        switch (team)
        {
            case Const.Team.Ally:
                break;

            case Const.Team.Enemy:
                break;

            default:
                break;
        }
    }

    //使用者のSP処理
    void ChangeSP(int changeNum, int team, int userID)
    {
        switch (team)
        {
            case Const.Team.Ally:
                break;

            case Const.Team.Enemy:
                break;

            default:
                break;
        }
    }

    //スキルの対象の判断
    DataValidation._target TargetJudge(int targetID)
    {
        DataValidation._target result = DataValidation._target.enemy_Once;

        //先頭一文字で味方か敵か判定
        //残りの二文字でその中の対象を判定
        //上記の内容を判定しやすくするために計算
        int team = targetID / 100;
        int target = targetID % 100;

        switch (target)
        {
            //対象が全体(99)の場合の処理
            case Const.Target.ALL:
                if (team == Const.Team.Ally)
                    result = DataValidation._target.ally_All;
                if (team == Const.Team.Enemy)
                    result = DataValidation._target.enemy_All;
                break;

            //対象がランダム(77)の時の処理
            case Const.Target.Random:
                if (team == Const.Team.Ally)
                    result = DataValidation._target.ally_Random;
                if (team == Const.Team.Enemy)
                    result = DataValidation._target.enemy_Random;
                break;

            //対象が自身(11)の時の処理
            case Const.Target.Oneself:
                result = DataValidation._target.oneself;
                break;

            //対象が単体の時の処理
            default:
                if (team == Const.Team.Ally)
                    result = DataValidation._target.ally_Once;
                if (team == Const.Team.Enemy)
                    result = DataValidation._target.enemy_Once;
                break;
        }

        return result;
    }

    int GetSkillIndex(int skillID)
    {
        int result = 0;

        for (int n = 0; n < skillDB.skillDatas.Length; n++)
        {
            if (skillID == skillDB.skillDatas[n].id)
            {
                result = n;
                break;
            }
        }

        return result;
    }

    public string GetSkillName(int skillID)
    {
        string result = "";

        int skillIndex = GetSkillIndex(skillID);
        result = skillDB.skillDatas[skillIndex].name;

        return result;
    }
}
