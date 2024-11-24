using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusDisplay : MonoBehaviour
{
    [Header("キャラクターの順番")]
    public int memberNum;

    //それぞれのステータスを表示するオブジェクトが取得できるか
    #region
    bool getNameFLG = false;
    bool getHPFLG = false;
    bool getMPFLG = false;
    bool getSPFLG = false;
    #endregion

    //ステータス表示用の変数
    #region
    //名前表示用の変数
    TextMeshProUGUI nameText;

    //HP表示用の変数
    GameObject currentHPGauge;
    TextMeshProUGUI currentHPText;
    TextMeshProUGUI maxHPText;
    float currentHP = 0;
    int maxHP = 0;

    //MP表示用の変数
    GameObject currentMPGauge;
    TextMeshProUGUI currentMPText;
    TextMeshProUGUI maxMPText;
    float currentMP = 0;
    int maxMP = 0;

    //SP表示用の変数
    GameObject currentSPGauge;
    TextMeshProUGUI currentSPText;
    TextMeshProUGUI maxSPText;
    float currentSP = 0;
    int maxSP = 0;
    #endregion

    //ステータス取得用にPartyManagerを取得
    PartyManager partyManager;

    void Start()
    {
        partyManager = GameObject.Find("PartyManager").GetComponent<PartyManager>();
        //子オブジェクトになにがあるか確認
        ChildrenCheck();
    }

    void Update()
    {
        if (partyManager.startFLG)
        {
            AllDisplay();
        }
    }

    //子オブジェクトになにがあるか確認
    void ChildrenCheck()
    {
        //名前を表示できるか判定
        if (transform.Find("Name").gameObject)
        {
            getNameFLG = true;

            //表示に必要なものを取得
            nameText = transform.Find("Name/NameText").gameObject.GetComponent<TextMeshProUGUI>();
        }

        //HPを表示できるか判定
        if (transform.Find("HP").gameObject)
        {
            getHPFLG = true;

            //表示に必要なものを取得
            GameObject hpObj = transform.Find("HP/HPGauge").gameObject;
            currentHPGauge = hpObj.transform.Find("CurrentHPGauge").gameObject;
            currentHPText = hpObj.transform.Find("CurrentHPText").gameObject.GetComponent<TextMeshProUGUI>();
            maxHPText = hpObj.transform.Find("MaxHPText").gameObject.GetComponent<TextMeshProUGUI>();
        }

        //MPを表示できるか判定
        if (transform.Find("MP").gameObject)
        {
            getMPFLG = true;

            //表示に必要なものを取得
            GameObject hpObj = transform.Find("MP/MPGauge").gameObject;
            currentMPGauge = hpObj.transform.Find("CurrentMPGauge").gameObject;
            currentMPText = hpObj.transform.Find("CurrentMPText").gameObject.GetComponent<TextMeshProUGUI>();
            maxMPText = hpObj.transform.Find("MaxMPText").gameObject.GetComponent<TextMeshProUGUI>();
        }

        //SPを表示できるか判定
        if (transform.Find("SP").gameObject)
        {
            getSPFLG = true;

            //表示に必要なものを取得
            GameObject hpObj = transform.Find("SP/SPGauge").gameObject;
            currentSPGauge = hpObj.transform.Find("CurrentSPGauge").gameObject;
            currentSPText = hpObj.transform.Find("CurrentSPText").gameObject.GetComponent<TextMeshProUGUI>();
            maxSPText = hpObj.transform.Find("MaxSPText").gameObject.GetComponent<TextMeshProUGUI>();
        }
    }

    //表示できるステータスをすべて表示
    public void AllDisplay()
    {
        if (getNameFLG) NameDisplay();
        if (getHPFLG) HPDisplay();
        if (getMPFLG) MPDisplay();
        if (getSPFLG) SPDisplay();
    }

    //名前を表示
    public void NameDisplay()
    {
        nameText.text = partyManager.GetPlayerName(memberNum);
    }

    //HPを表示
    public void HPDisplay()
    {
        //必要な値を取得
        currentHP = partyManager.GetPlayerStatus_Current(memberNum, DataValidation._status.HP);
        maxHP = partyManager.GetPlayerStatus_Max(memberNum, DataValidation._status.HP);

        //画面に表示
        GaugeDisplay(currentHPGauge,currentHP, maxHP);
        TMProDisplay(currentHPText, currentHP);
        TMProDisplay(maxHPText, maxHP);
    }

    //MPを表示
    public void MPDisplay()
    {
        //必要な値を取得
        currentMP = partyManager.GetPlayerStatus_Current(memberNum, DataValidation._status.MP);
        maxMP = partyManager.GetPlayerStatus_Max(memberNum, DataValidation._status.MP);

        //画面に表示
        GaugeDisplay(currentMPGauge, currentMP, maxMP);
        TMProDisplay(currentMPText, currentMP);
        TMProDisplay(maxMPText, maxMP);
    }

    //SPを表示
    public void SPDisplay()
    {
        //必要な値を取得
        currentSP = partyManager.GetPlayerStatus_Current(memberNum, DataValidation._status.SP);
        maxSP = partyManager.GetPlayerStatus_Max(memberNum, DataValidation._status.SP);

        //画面に表示
        GaugeDisplay(currentSPGauge, currentSP, maxSP);
        TMProDisplay(currentSPText, currentSP);
        TMProDisplay(maxSPText, maxSP);
    }

    //ゲージを表示
    void GaugeDisplay(GameObject gauge, float currentNum, int maxNum)
    {
        if (gauge) gauge.GetComponent<Image>().fillAmount = currentNum / maxNum;
    }

    //テキストを表示
    void TMProDisplay(TextMeshProUGUI text, float num)
    {
        if(text) text.text = num.ToString();
    }
}
