using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CommandDisplay : MonoBehaviour
{
    //必要なデータを取得するためのManagerクラスの変数
    BattleManager battleManager;
    CommandManager commandManager;
    SkillManager skillManager;
    PartyManager partyManager;

    //コマンド表示用のオブジェクト
    GameObject partyCommandWindow;
    GameObject partyCommand;    //パーティ全体のコマンド
    GameObject partyCommand_First;  //パーティ全体の最初に選択されるコマンド
    GameObject charaCommandWindow;
    GameObject charaCommand;    //個人のコマンド
    GameObject charaCommand_First;  //個人の最初に選択されるコマンド
    GameObject[] skillCommand;

    void Start()
    {
        //Managerクラスの取得
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        commandManager = GameObject.Find("CommandManager").GetComponent<CommandManager>();
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        partyManager = GameObject.Find("PartyManager").GetComponent<PartyManager>();

        //コマンド表示用のオブジェクトの取得
        partyCommandWindow = GameObject.Find("PartyCommandWindow");
        partyCommand = GameObject.Find("PartyCommand");
        partyCommand_First = partyCommand.transform.GetChild(0).gameObject;
        partyCommandWindow.SetActive(false);

        charaCommandWindow = GameObject.Find("CharaCommandWindow");
        charaCommand = GameObject.Find("CharaCommand");
        charaCommand_First = charaCommand.transform.GetChild(0).gameObject;

        skillCommand = new GameObject[charaCommand.transform.childCount];
        for (int n = 0; n < charaCommand.transform.childCount; n++)
        {
            skillCommand[n] = charaCommand.transform.GetChild(n).gameObject;
        }
        charaCommandWindow.SetActive(false);
    }

    void Update()
    {
        if (battleManager.endFLG)
        {
            partyCommandWindow.SetActive(false);
            charaCommandWindow.SetActive(false);
            return;
        }

        //コマンド入力中の処理
        if (commandManager.isCommand)
        {
            //パーティコマンドが表示されている時の処理
            if (partyCommandWindow.activeSelf)
            {
                IsPartyCommand();
            }
            //キャラコマンドが表示されている時の処理
            else if (charaCommandWindow.activeSelf)
            {
                IsCharaCommand();
            }
            //ウインドウが表示されていない時の処理
            else
            {
                partyCommandWindow.SetActive(true);
                EventSystem.current.SetSelectedGameObject(partyCommand_First);
            }
        }
        //コマンド入力中でない時の処理
        if (!commandManager.isCommand)
        {
            partyCommandWindow.SetActive(false);
            charaCommandWindow.SetActive(false);
        }
    }

    //パーティコマンドが表示されている時の処理
    void IsPartyCommand()
    {
        if (commandManager.isBattle)
        {
            partyCommandWindow.SetActive(false);
            charaCommandWindow.SetActive(true);

            EventSystem.current.SetSelectedGameObject(charaCommand_First);
        }
    }

    //キャラコマンドが表示されている時の処理
    void IsCharaCommand()
    {
        SkillDisplay();

        if (Input.GetButtonDown("Cancel"))
        {
            if (commandManager.currentNum <= 0)
            {
                commandManager.Command_Battle(false);
                partyCommandWindow.SetActive(true);
                charaCommandWindow.SetActive(false);

                EventSystem.current.SetSelectedGameObject(partyCommand_First);
            }
            else
            {
                commandManager.CommandCancel();
                EventSystem.current.SetSelectedGameObject(charaCommand_First);
            }
        }

        if (Input.GetButtonDown("Submit"))
        {
            EventSystem.current.SetSelectedGameObject(charaCommand_First);
        }
    }

    //スキルの表示
    void SkillDisplay()
    {
        for (int n = 0; n < skillCommand.Length; n++)
        {
            //スキルIDの取得
            int skillID = partyManager.GetPlayerSkill(commandManager.currentNum, n);

            //スキルが無かったらコマンドを表示しない
            if (skillID < 0)
            {
                skillCommand[n].SetActive(false);
                continue;
            }

            skillCommand[n].SetActive(true);

            //テキストメッシュプロの取得
            TextMeshProUGUI skillNameText;
            skillNameText = skillCommand[n].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

            //スキル名の取得
            string skillName = skillManager.GetSkillName(skillID);

            //スキル名の表示
            skillNameText.text = skillName;
        }
    }
}
