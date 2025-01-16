using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    //コマンド入力の判定用変数
    #region
    //コマンド入力中か
    public bool _isCommand = false;
    //_isCommandを返す　CM内からであれば変更できる
    /// <summary>
    /// コマンド入力中か
    /// </summary>
    public bool isCommand
    {
        get { return _isCommand; }
        private set { _isCommand = value; }
    }

    int memberNum = 0;
    int _currentNum = 0;
    public int currentNum
    {
        get { return _currentNum; }
        private set { _currentNum = value; }
    }
    #endregion

    //入力された内容の格納用変数
    #region
    bool _isBattle;
    public bool isBattle
    {
        get { return _isBattle; }
        private set { _isBattle = value; }
    }

    //逃走用のフラグ
    bool _escapeFLG;
    public bool escapeFLG
    {
        get { return _escapeFLG; }
        private set { _escapeFLG = value; }
    }

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
    }

    void Update()
    {
    }

    public void Command_Battle(bool flg)
    {
        isBattle = flg;
    }

    public void Command_Escape()
    {
        escapeFLG = true;
        isCommand = false;
    }

    /*
    public void Command_Attack()
    {
        CommandSet(DataValidation._command.Attack,255);
    }

    public void Command_Skill()
    {
    }
    */

    public void Select_Skill(int id)
    {
        if(isBattle) CommandSet(DataValidation._command.Skill, id);
    }

    /*
    public void Command_Defense()
    {
        CommandSet(DataValidation._command.Defense,255);
    }

    public void Command_Item()
    {
        CommandSet(DataValidation._command.Item,1);
    }
    */

    void CommandSet(DataValidation._command _command, int _commandId)
    {
        command[currentNum] = _command;
        commandID[currentNum] = _commandId;
        currentNum++;

        //メンバー全員のコマンド入力が終わったらisCommandをfalseにする
        if (currentNum >= memberNum) isCommand = false;
    }

    public void CommandCancel()
    {
        currentNum--;
    }

    //コマンドの初期化
    public void CommandReset()
    {
        isBattle = false;
        command = new DataValidation._command[memberNum];
        commandID = new int[memberNum];
        currentNum = 0;
        isCommand = true;
    }

    //パーティの人数の登録
    public void SetMemberNum(int num)
    {
        memberNum = num;
    }
}
