using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyInformation : MonoBehaviour
{
    public RectTransform infoTransform;
    public int movePower = 1550;

    DataValidation._element element = DataValidation._element.None;

    List<GameObject> bossInfo = new List<GameObject>();
    List<TextMeshProUGUI> nameText = new List<TextMeshProUGUI>();

    bool setInfo = false;

    EnemyManager enemyManager;

    void Start()
    {
        infoTransform = this.gameObject.GetComponent<RectTransform>();
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
            setInfo = true;
        }
    }

    void EnemyInfoDisplay()
    {
        for (int n = 0; n < nameText.Count; n++)
        {
            nameText[n].text = enemyManager.GetEnemyDB_Name(n);
        }
    }

    public void ElementChange(int direction)
    {
        int move = movePower * direction;
        infoTransform.position += new Vector3(move, 0, 0);
    }
}
