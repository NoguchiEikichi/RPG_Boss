using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyInformation : MonoBehaviour
{
    List<GameObject> bossInfo = new List<GameObject>();
    List<TextMeshProUGUI> nameText = new List<TextMeshProUGUI>();

    bool setInfo = false;

    EnemyManager enemyManager;

    void Start()
    {
        int child = this.gameObject.transform.childCount;

        for (int n = 0; n < child; n++)
        {
            bossInfo.Add(this.gameObject.transform.GetChild(n).gameObject);
            nameText.Add(bossInfo[n].transform.Find("NameText").gameObject.GetComponent<TextMeshProUGUI>());
        }
        enemyManager = GameObject.Find("EnemyManager").transform.gameObject.GetComponent<EnemyManager>();
    }

    void Update()
    {
        if (!setInfo && LoadObserver.Instance.loadEnd)
        {
            EnemyInfoDisplay();

            //情報の順番を変更
            bossInfo[bossInfo.Count - 1].transform.SetAsFirstSibling();
            GameObject lastInfo = bossInfo[bossInfo.Count - 1];
            bossInfo.RemoveAt(bossInfo.Count - 1);
            bossInfo.Insert(0, lastInfo);

            setInfo = true;
        }
    }

    //ボスの情報表示
    void EnemyInfoDisplay()
    {
        for (int n = 0; n < nameText.Count; n++)
        {
            nameText[n].text = enemyManager.GetEnemyDB_Name(n);
        }
    }

    //画面に表示するボスの情報を変更
    public void BossChange(int direction)
    {
        if (direction > 0)
        {
            bossInfo[0].transform.SetAsLastSibling();
            GameObject firstInfo = bossInfo[0];
            bossInfo.RemoveAt(0);
            bossInfo.Add(firstInfo);
        }
        else if (direction < 0)
        {
            bossInfo[bossInfo.Count - 1].transform.SetAsFirstSibling();
            GameObject lastInfo = bossInfo[bossInfo.Count - 1];
            bossInfo.RemoveAt(bossInfo.Count - 1);
            bossInfo.Insert(0, lastInfo);
        }
    }
}
