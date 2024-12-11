using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceManager : MonoBehaviour
{
    DataValidation._element element = DataValidation._element.Fire;

    EnemyInformation enemyInfo;

    void Start()
    {
        enemyInfo = GameObject.Find("BossInfoSpace").transform.gameObject.GetComponent<EnemyInformation>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
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

        enemyInfo.ElementChange(direction);
    }

    public void SceneMove()
    {
        SceneManager.LoadSceneAsync(((int)element) + 2);
    }
}
