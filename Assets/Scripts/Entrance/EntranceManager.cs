using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceManager : MonoBehaviour
{
    //遷移先のシーンを指定するための変数
    DataValidation._element element = DataValidation._element.Fire;

    EnemyInformation enemyInfo;
    MenuManager menuManager;

    void Start()
    {
        enemyInfo = GameObject.Find("BossInfoSpace").transform.gameObject.GetComponent<EnemyInformation>();
        menuManager = GameObject.Find("MenuManager").transform.gameObject.GetComponent<MenuManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Horizontal") && !menuManager.isMenu)
        {
            int direction = (int)Input.GetAxisRaw("Horizontal");
            BossChange(direction);
        }
    }

    void BossChange(int direction)
    {
        element += direction;

        if (element < 0) element = DataValidation._element.Dark;
        else if (element >= DataValidation._element.None)
            element = DataValidation._element.Fire;

        enemyInfo.BossChange(direction);
    }

    public void SceneMove()
    {
        SceneManager.LoadSceneAsync(((int)element) + 2);
    }
}
