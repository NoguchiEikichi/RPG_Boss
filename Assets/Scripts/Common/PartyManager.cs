using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : Singleton<PartyManager>
{
    [Header("主人公のID")]
    [SerializeField] int[] defaultMemberID = { 0, 1, 2 };

    int partyMemberNum = 3;
    List<int> memberIDList = new List<int>();

    //処理を行って問題ないか
    bool _startFLG = false;
    public bool startFLG
    {
        get { return _startFLG; }
        private set { _startFLG = value; }
    }

    void Awake()
    {
        //もし他のオブジェクトの子であれば、親子関係を解除
        if (gameObject.transform.parent != null) gameObject.transform.parent = null;

        //もし他にPartyManagerが存在していたら、このオブジェクトをDestroy
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);  //PartyManagerはシーン遷移しても削除しない
    }

    //最初のIDの登録
    void Start()
    {
        for (int n = 0; n < partyMemberNum; n++)
        {
            AddPartyMember(defaultMemberID[n]);
        }
    }

    //PlayerManagerが必要なアセットをロードできているか確認
    void Update()
    {
        LoadCheck();
    }
    void LoadCheck()
    {
        //PlayerManagerのロードが終わっていたら処理を開始できるようにする
        if (!startFLG && LoadObserver.Instance.loadEnd)
        {
            startFLG = true;
        }
    }

    //プレイヤーキャラクターのデータの取得、変更
    #region
    public string GetPlayerName(int playerIndex)
    {
        string result = "";
        int playerID = memberIDList[playerIndex];

        result = PlayerManager.Instance.GetStatus_Name(playerID);

        return result;
    }

    public int GetPlayerID(int playerIndex)
    {
        return memberIDList[playerIndex];
    }

    public int GetPlayerStatus_Current(int playerIndex, DataValidation._status status)
    {
        int result = 100;
        int playerID = memberIDList[playerIndex];

        result = PlayerManager.Instance.GetStatus_Current(playerID, status);

        return result;
    }
   
    public int GetPlayerStatus_Max(int playerIndex, DataValidation._status status)
    {
        int result = 100;
        int playerID = memberIDList[playerIndex];

        result = PlayerManager.Instance.GetStatus_Max(playerID, status);

        return result;
    }

    public void ChangePlayerStatus(int playerIndex, int changeNum, DataValidation._status status)
    {
        int playerID = memberIDList[playerIndex];

        PlayerManager.Instance.SetStatus_Change(playerID, changeNum, status);
    }
    
    public int GetPlayerSkill(int playerIndex, int skillIndex)
    {
        int result = -1;
        int playerID = memberIDList[playerIndex];

        result = PlayerManager.Instance.GetStatus_Skill(playerID, skillIndex);

        return result;
    }
    #endregion

    //パーティメンバーの変更
    public void ChangePartyMember(int addMemberID, int removeMemberID)
    {
        //メンバーから外す処理を行い、外したいメンバーが存在しなかった場合は処理を終了する
        int index = RemovePartyMember(removeMemberID);
        if (index < 0) return;

        AddPartyMember(addMemberID, index);
    }

    //パーティメンバーを末尾に追加
    void AddPartyMember(int addMemberID)
    {
        //パーティメンバーの数が指定の数以上なら処理を終了する
        if (memberIDList.Count >= partyMemberNum) return;

        //新しいメンバーを末尾に追加
        memberIDList.Add(addMemberID);
    }

    //パーティメンバーを位置を指定して追加
    void AddPartyMember(int addMemberID, int addPos)
    {
        //パーティメンバーの数が指定の数以上なら処理を終了する
        if (memberIDList.Count >= partyMemberNum) return;

        //新しいメンバーを指定した位置に追加
        memberIDList.Insert(addPos, addMemberID);
    }

    //パーティメンバーの削除
    int RemovePartyMember(int removeMemberID)
    {
        //パーティから外したいメンバーの要素番号を調べ、IDがメンバーに含まれていないときは処理を終了する
        int index = memberIDList.IndexOf(removeMemberID);
        if (index < 0) return index;

        //パーティから外したいメンバーをリストから削除し、元々メンバーがいた場所を出力
        memberIDList.RemoveAt(index);
        return index;
    }

    public int GetMemberNum()
    {
        int result = 0;

        result = memberIDList.Count;

        return result;
    }

    public int GetActiveMemberNum()
    {
        int result = 0;

        for (int n = 0; n < memberIDList.Count; n++)
        {
            int hp = GetPlayerStatus_Current(n, DataValidation._status.HP);

            if(hp > 0) result++;
        }

        return result;
    }

    public List<int> GetActiveMemberIndex()
    {
        List<int> result = new List<int>();

        int hp = 0;

        for (int n = 0; n < memberIDList.Count; n++)
        {
            hp = GetPlayerStatus_Current(n, DataValidation._status.HP);

            if (hp > 0) result.Add(n);
        }

        return result;
    }
}