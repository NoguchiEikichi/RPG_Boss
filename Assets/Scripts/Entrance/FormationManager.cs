using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FormationManager : MonoBehaviour
{
    //キャラ選択中
    bool _isSelect = false;
    public bool isSelect
    {
        get { return _isSelect; }
        private set { _isSelect = value; }
    }

    int position;
    FormationInformarion formationInfo;

    GameObject previousFocus;
    GameObject defaultFocus;

    void Start()
    {
        GameObject charaList = GameObject.Find("ListSpace").transform.gameObject;
        defaultFocus = charaList.transform.GetChild(0).gameObject;

        formationInfo = GameObject.Find("FormationCanvas").transform.GetComponent<FormationInformarion>();
    }

    void Update()
    {
        //選択状態の解除
        if (Input.GetButtonDown("Cancel") && isSelect) Invoke("SelectFinish", 0.05f);
    }

    public void PositionSelect(int pos)
    {
        position = pos;

        previousFocus = EventSystem.current.currentSelectedGameObject;

        EventSystem.current.SetSelectedGameObject(defaultFocus);
        isSelect = true;
    }

    public void CharaSelect(int charaID)
    {
        formationInfo.PartyMemberChange(position, charaID);

        SelectFinish();
    }

    void SelectFinish()
    {
        EventSystem.current.SetSelectedGameObject(previousFocus);
        isSelect = false;
    }
}
