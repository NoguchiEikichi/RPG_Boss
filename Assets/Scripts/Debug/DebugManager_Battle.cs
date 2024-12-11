using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugManager_Battle : MonoBehaviour
{
    PlayerManager PM;

    PartyManager partyManager;

    EnemyManager EM;

    void Start()
    {
        PM = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        partyManager = GameObject.Find("PartyManager").GetComponent<PartyManager>();
        EM = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            PM.StatusReset();
            EM.StatusReset();
        }
        if (Input.GetKeyDown(KeyCode.Tab)) SceneReset();

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
