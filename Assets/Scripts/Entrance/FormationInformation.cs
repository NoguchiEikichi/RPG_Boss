using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FormationInformarion : MonoBehaviour
{
    GameObject partySpace;
    List<GameObject> partyMember = new List<GameObject>();
    GameObject listSpace;
    List<GameObject> charaList = new List<GameObject>();
    GameObject statusSpace;

    PartyManager partyManager;
    PlayerManager playerManager;

    void Start()
    {
        partySpace = transform.Find("ButtonSpace").gameObject;
        for (int n = 0; n < partySpace.transform.childCount; n++)
        {
            GameObject addObj = partySpace.transform.GetChild(n).gameObject;
            partyMember.Add(addObj);
        }

        listSpace = transform.Find("ListSpace").gameObject;
        for (int n = 0; n < listSpace.transform.childCount; n++)
        {
            GameObject addObj = listSpace.transform.GetChild(n).gameObject;
            charaList.Add(addObj);
        }

        statusSpace = transform.Find("StatusSpace").gameObject;

        partyManager = GameObject.Find("PartyManager").transform.GetComponent<PartyManager>();
        playerManager = GameObject.Find("PlayerManager").transform.GetComponent<PlayerManager>();
    }

    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            PartyMemberDisplay();
            CharaListDisplay();
        }
    }

    void PartyMemberDisplay()
    {
        for (int n = 0; n < partyMember.Count; n++)
        {
            //
            Image faceImage = partyMember[n].transform.Find("FaceImage").GetComponent<Image>();
            int playerID = partyManager.GetPlayerID(n);
            string imageLink = "Sprite/Player/Player_" + playerID.ToString();
            Sprite sprite = Resources.Load<Sprite>(imageLink);
            faceImage.sprite = sprite;

            //
            TextMeshProUGUI nameText = partyMember[n].transform.Find("NameText").GetComponent<TextMeshProUGUI>();
            string playerName = partyManager.GetPlayerName(n);
            nameText.text = playerName;
        }
    }

    void CharaListDisplay()
    {
        int charaID = 0;

        for (int n = 0; n < charaList.Count; n++)
        {
            charaID = IDCheck(charaID);

            //
            Image faceImage = charaList[n].transform.Find("FaceImage").GetComponent<Image>();
            string imageLink = "Sprite/Player/Player_" + charaID.ToString();
            Sprite sprite = Resources.Load<Sprite>(imageLink);
            faceImage.sprite = sprite;

            charaID++;
        }
    }

    int IDCheck(int id)
    {
        int result = id;

        if (result == partyManager.GetPlayerID(0))
        {
            result++;
            result = IDCheck(result);
        }
        if (result == partyManager.GetPlayerID(1))
        {
            result++;
            result = IDCheck(result);
        }
        if (result == partyManager.GetPlayerID(2))
        {
            result++;
            result = IDCheck(result);
        }

        return result;
    }

    public void PartyMemberChange(int pos, int chara)
    {
        int addCharaID = 0;
        addCharaID = IDCheck(addCharaID);

        for (int n = 0; n < chara; n++)
        {
            addCharaID++;
            addCharaID = IDCheck(addCharaID);
        }

        int removeCharaID = partyManager.GetPlayerID(pos);

        partyManager.ChangePartyMember(addCharaID, removeCharaID);
    }
}
