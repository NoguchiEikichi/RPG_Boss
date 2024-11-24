using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandDisplay : MonoBehaviour
{
    CommandManager commandManager;

    GameObject partyCommand;
    GameObject partyCommand_First;
    GameObject charaCommand;
    GameObject charaCommand_First;

    void Start()
    {
        commandManager = GameObject.Find("CommandManager").GetComponent<CommandManager>();
        partyCommand = GameObject.Find("PartyCommand");
        partyCommand_First = partyCommand.transform.GetChild(0).gameObject;
        charaCommand = GameObject.Find("CharaCommand");
        charaCommand_First = charaCommand.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (partyCommand.activeSelf)
        {
            partyCommand.SetActive(false);
        }
    }

    void SkillDisplay()
    {

    }
}
