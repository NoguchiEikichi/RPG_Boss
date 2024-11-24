using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    //コマンド入力の判定用変数
    #region
    //コマンド入力中か
    private bool _isCommand = false;

    //_isCommandを返す　CM内からであれば変更できる
    /// <summary>
    /// コマンド入力中か
    /// </summary>
    public bool isCommand
    {
        get { return _isCommand; }
        private set { _isCommand = value; }
    }

    int memberNum = 1;
    int currentNum = 0;
    #endregion

    //入力された内容の格納用変数
    #region
    //入力されたコマンド
    DataValidation._command[] _command;
    public DataValidation._command[] command
    {
        get { return _command; }
        private set { _command = value; }
    }
    
    //入力されたスキル、アイテム
    int[] _commandID;
    public int[] commandID
    {
        get { return _commandID; }
        private set { _commandID = value; }
    }
    #endregion

    void Start()
    {
        _commandID = new int[memberNum];
    }

    void Update()
    {
    }

    public void Command_Attack()
    {
        CommandSet(DataValidation._command.Attack,255);
    }

    public void Command_Skill()
    {
    }

    public void Select_Skill(int id)
    {
        CommandSet(DataValidation._command.Skill, id);
    }

    public void Command_Defense()
    {
        CommandSet(DataValidation._command.Defense,255);
    }

    public void Command_Item()
    {
        CommandSet(DataValidation._command.Item,1);
    }

    void CommandSet(DataValidation._command _command, int _commandId)
    {
        command[currentNum] = _command;
        commandID[currentNum] = _commandId;
        currentNum++;
        if(currentNum >= memberNum) isCommand = false;
    }

    public void CommandReset()
    {
        command = new DataValidation._command[memberNum];
        currentNum = 0;
        isCommand = true;
    }
}
