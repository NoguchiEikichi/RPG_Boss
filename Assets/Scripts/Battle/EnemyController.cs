using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemyManager enemyManager;
    SkillManager skillManager;

    DataValidation._pattern pattern = DataValidation._pattern.none;

    int turn = 0;

    void Start()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
    }

    void Update()
    {
        if (LoadObserver.Instance.loadEnd && pattern == DataValidation._pattern.none)
        {
            pattern = enemyManager.GetEnemyStatus_Pattern(0);
        }
    }

    public void EnemyMove()
    {
        int targetID = TargetSelect();
        int skillID = 0;

        switch (pattern)
        {
            case DataValidation._pattern.random:
                int randomNum = Random.Range(0, enemyManager.enemySkill.Length);
                skillID = enemyManager.enemySkill[randomNum];
                skillManager.UseSkill(skillID, 0, targetID);
                break;

            case DataValidation._pattern.systematic:
                skillID = enemyManager.enemySkill[turn];
                skillManager.UseSkill(skillID, 0, targetID);
                turn++;
                if (turn >= enemyManager.enemySkill.Length) turn = 0;
                break;
        }
    }

    int TargetSelect()
    {
        int randomNum = 0;
        int targetNum = 0;

        randomNum = Random.Range(0, 100);

        switch (PartyManager.Instance.GetActiveMemberNum())
        {
            case 3:
                if (randomNum < 50) targetNum = 0;
                else if (randomNum < 80) targetNum = 1;
                else targetNum = 2;
                break;

            case 2:
                if (randomNum < 70) targetNum = 0;
                else targetNum = 1;
                break;

            case 1:
                break;

            default:
                break;
        }
        List<int> targetList = PartyManager.Instance.GetActiveMemberIndex();

        return targetList[targetNum] + Const.Team.Ally * 100;
    }
}
