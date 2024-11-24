using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugManager_Battle : MonoBehaviour
{
    CommandManager CM;
    bool isSkill = false;

    PlayerManager PM;

    PartyManager partyManager;

    EnemyManager EM;

    void Start()
    {
        CM = GameObject.Find("CommandManager").GetComponent<CommandManager>();
        PM = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        partyManager = GameObject.Find("PartyManager").GetComponent<PartyManager>();
        EM = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PM.StatusReset();
            EM.StatusReset();
        }
        if (Input.GetKeyDown(KeyCode.Tab)) SceneReset();

        if (Input.GetKeyDown(KeyCode.A)) CM.Command_Attack();
        if (Input.GetKeyDown(KeyCode.S)) isSkill = true;
        if (Input.GetKeyDown(KeyCode.D)) CM.Command_Defense();
        if (Input.GetKeyDown(KeyCode.F)) CM.Command_Item();
        if (isSkill)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CM.Select_Skill(0);
                isSkill = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CM.Select_Skill(1);
                isSkill = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.P)) partyManager.ChangePartyMember(3,0);
    }

    void SceneReset()
    {
        // 現在のSceneを取得
        Scene loadScene = SceneManager.GetActiveScene();
        // 現在のシーンを再読み込みする
        SceneManager.LoadScene(loadScene.name);
    }
}
