using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnemyManager : MonoBehaviour, PerformLoading
{
    public EnemyStatus[] enemyStatus_Selection;

    EnemyStatusData[] enemyStatus;

    //必要なアセットの読み込み
    #region
    // Addressablesのアドレスを設定
    [Header("EnemyDatabaseのアドレス")]
    [SerializeField] string enemyDBAddress = "EnemyDatabase";

    // EnemyDatabaseを格納する変数
    EnemyDatabase enemyDB;

    bool _loadEnd = false;
    public bool loadEnd
    {
        get { return _loadEnd; }
    }

    void Awake()
    {
        // Addressablesを使ってEnemyDatabaseをロード
        Addressables.LoadAssetAsync<EnemyDatabase>(enemyDBAddress).Completed += OnEnemyDatabaseLoaded;
    }

    // EnemyDatabaseの読み込みが完了した際に呼ばれる
    void OnEnemyDatabaseLoaded(AsyncOperationHandle<EnemyDatabase> handle)
    {
        // 成功したら、enemyDB変数に代入
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            enemyDB = handle.Result;

            int n = 0;
            n = Random.Range(0, enemyStatus_Selection.Length);
            enemyStatus = enemyStatus_Selection[n].enemyStatusDatas;

            _loadEnd = true;
        }
        else Debug.LogError("Failed to load EnemyDatabase");
    }
    #endregion

    //ステータスの初期化
    public void StatusReset()
    {
        for (int n = 0; n < enemyStatus.Length; n++)
        {
            SetStatus_Base(n);
            ResetStatus_ChangeAll(n);
        }
    }

    //変動値の初期化
    #region
    //変動値の全てのステータスの初期化
    void ResetStatus_ChangeAll(int id)
    {
        ResetStatus_ChangeHP(id);
        ResetStatus_ChangeMP(id);
        ResetStatus_ChangeSTR(id);
    }

    //変動値のステータスごとの初期化
    public void ResetStatus_Change(int id, DataValidation._status status)
    {
        //ステータスによる処理の分岐
        switch (status)
        {
            case DataValidation._status.HP:
                ResetStatus_ChangeHP(id);
                break;
            case DataValidation._status.MP:
                ResetStatus_ChangeMP(id);
                break;
            case DataValidation._status.SP:
                ResetStatus_ChangeSP(id);
                break;
            case DataValidation._status.STR:
                ResetStatus_ChangeSTR(id);
                break;
            case DataValidation._status.DEF:
                ResetStatus_ChangeDEF(id);
                break;
            case DataValidation._status.INT:
                ResetStatus_ChangeINT(id);
                break;
            case DataValidation._status.MND:
                ResetStatus_ChangeMND(id);
                break;
            case DataValidation._status.AGI:
                ResetStatus_ChangeAGI(id);
                break;
            case DataValidation._status.LUK:
                ResetStatus_ChangeLUK(id);
                break;
            case DataValidation._status.HIT:
                ResetStatus_ChangeHIT(id);
                break;
            case DataValidation._status.DEX:
                ResetStatus_ChangeDEX(id);
                break;
            case DataValidation._status.CRI:
                ResetStatus_ChangeCRI(id);
                break;
            case DataValidation._status.CRI_mul:
                ResetStatus_ChangeCRI_mul(id);
                break;
            case DataValidation._status.Aptitude_Fire:
                ResetStatus_ChangeAptitude_Fire(id);
                break;

            case DataValidation._status.Aptitude_Aqua:
                ResetStatus_ChangeAptitude_Aqua(id);
                break;

            case DataValidation._status.Aptitude_Wind:
                ResetStatus_ChangeAptitude_Wind(id);
                break;

            case DataValidation._status.Aptitude_Earth:
                ResetStatus_ChangeAptitude_Earth(id);
                break;

            case DataValidation._status.Aptitude_Light:
                ResetStatus_ChangeAptitude_Light(id);
                break;

            case DataValidation._status.Aptitude_Dark:
                ResetStatus_ChangeAptitude_Dark(id);
                break;

            case DataValidation._status.Resist_Fire:
                ResetStatus_ChangeResist_Fire(id);
                break;

            case DataValidation._status.Resist_Aqua:
                ResetStatus_ChangeResist_Aqua(id);
                break;

            case DataValidation._status.Resist_Wind:
                ResetStatus_ChangeResist_Wind(id);
                break;

            case DataValidation._status.Resist_Earth:
                ResetStatus_ChangeResist_Earth(id);
                break;

            case DataValidation._status.Resist_Light:
                ResetStatus_ChangeResist_Light(id);
                break;

            case DataValidation._status.Resist_Dark:
                ResetStatus_ChangeResist_Dark(id);
                break;
            default:
                break;
        }
    }

    //変動値のステータスごとの初期化処理
    #region
    void ResetStatus_ChangeHP(int id)
    {
        if (enemyStatus[id].status_Change.HP != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.HP * -1;
            SetStatus_ChangeHP(id, changeNum);
        }
    }

    void ResetStatus_ChangeMP(int id)
    {
        if (enemyStatus[id].status_Change.MP != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.MP * -1;
            SetStatus_ChangeMP(id, changeNum);
        }
    }

    void ResetStatus_ChangeSP(int id)
    {
        if (enemyStatus[id].status_Change.SP != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.SP * -1;
            SetStatus_ChangeSP(id, changeNum);
        }
    }

    void ResetStatus_ChangeSTR(int id)
    {
        if (enemyStatus[id].status_Change.STR != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.STR * -1;
            SetStatus_ChangeSTR(id, changeNum);
        }
    }

    void ResetStatus_ChangeDEF(int id)
    {
        if (enemyStatus[id].status_Change.DEF != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.DEF * -1;
            SetStatus_ChangeDEF(id, changeNum);
        }
    }

    void ResetStatus_ChangeINT(int id)
    {
        if (enemyStatus[id].status_Change.INT != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.INT * -1;
            SetStatus_ChangeINT(id, changeNum);
        }
    }

    void ResetStatus_ChangeMND(int id)
    {
        if (enemyStatus[id].status_Change.MND != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.MND * -1;
            SetStatus_ChangeMND(id, changeNum);
        }
    }

    void ResetStatus_ChangeAGI(int id)
    {
        if (enemyStatus[id].status_Change.AGI != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.AGI * -1;
            SetStatus_ChangeAGI(id, changeNum);
        }
    }

    void ResetStatus_ChangeLUK(int id)
    {
        if (enemyStatus[id].status_Change.LUK != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.LUK * -1;
            SetStatus_ChangeLUK(id, changeNum);
        }
    }

    void ResetStatus_ChangeHIT(int id)
    {
        if (enemyStatus[id].status_Change.HIT != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.HIT * -1;
            SetStatus_ChangeHIT(id, changeNum);
        }
    }

    void ResetStatus_ChangeDEX(int id)
    {
        if (enemyStatus[id].status_Change.DEX != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.DEX * -1;
            SetStatus_ChangeDEX(id, changeNum);
        }
    }

    void ResetStatus_ChangeCRI(int id)
    {
        if (enemyStatus[id].status_Change.CRI != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.CRI * -1;
            SetStatus_ChangeCRI(id, changeNum);
        }
    }

    void ResetStatus_ChangeCRI_mul(int id)
    {
        if (enemyStatus[id].status_Change.CRI_mul != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.CRI_mul * -1;
            SetStatus_ChangeCRI_mul(id, changeNum);
        }
    }

    void ResetStatus_ChangeAptitude_Fire(int id)
    {
        if (enemyStatus[id].status_Change.Aptitude_Fire != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.Aptitude_Fire * -1;
            SetStatus_ChangeAptitude_Fire(id, changeNum);
        }
    }

    void ResetStatus_ChangeAptitude_Aqua(int id)
    {
        if (enemyStatus[id].status_Change.Aptitude_Aqua != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.Aptitude_Aqua * -1;
            SetStatus_ChangeAptitude_Aqua(id, changeNum);
        }
    }

    void ResetStatus_ChangeAptitude_Wind(int id)
    {
        if (enemyStatus[id].status_Change.Aptitude_Wind != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.Aptitude_Wind * -1;
            SetStatus_ChangeAptitude_Wind(id, changeNum);
        }
    }

    void ResetStatus_ChangeAptitude_Earth(int id)
    {
        if (enemyStatus[id].status_Change.Aptitude_Earth != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.Aptitude_Earth * -1;
            SetStatus_ChangeAptitude_Earth(id, changeNum);
        }
    }

    void ResetStatus_ChangeAptitude_Light(int id)
    {
        if (enemyStatus[id].status_Change.Aptitude_Light != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.Aptitude_Light * -1;
            SetStatus_ChangeAptitude_Light(id, changeNum);
        }
    }

    void ResetStatus_ChangeAptitude_Dark(int id)
    {
        if (enemyStatus[id].status_Change.Aptitude_Dark != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.Aptitude_Dark * -1;
            SetStatus_ChangeAptitude_Dark(id, changeNum);
        }
    }

    void ResetStatus_ChangeResist_Fire(int id)
    {
        if (enemyStatus[id].status_Change.Resist_Fire != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.Resist_Fire * -1;
            SetStatus_ChangeResist_Fire(id, changeNum);
        }
    }

    void ResetStatus_ChangeResist_Aqua(int id)
    {
        if (enemyStatus[id].status_Change.Resist_Aqua != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.Resist_Aqua * -1;
            SetStatus_ChangeResist_Aqua(id, changeNum);
        }
    }

    void ResetStatus_ChangeResist_Wind(int id)
    {
        if (enemyStatus[id].status_Change.Resist_Wind != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.Resist_Wind * -1;
            SetStatus_ChangeResist_Wind(id, changeNum);
        }
    }

    void ResetStatus_ChangeResist_Earth(int id)
    {
        if (enemyStatus[id].status_Change.Resist_Earth != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.Resist_Earth * -1;
            SetStatus_ChangeResist_Earth(id, changeNum);
        }
    }

    void ResetStatus_ChangeResist_Light(int id)
    {
        if (enemyStatus[id].status_Change.Resist_Light != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.Resist_Light * -1;
            SetStatus_ChangeResist_Light(id, changeNum);
        }
    }

    void ResetStatus_ChangeResist_Dark(int id)
    {
        if (enemyStatus[id].status_Change.Resist_Dark != 0)
        {
            int changeNum = 0;
            changeNum = enemyStatus[id].status_Change.Resist_Dark * -1;
            SetStatus_ChangeResist_Dark(id, changeNum);
        }
    }
    #endregion
    #endregion

    //ステータスの検索
    #region
    /// <summary>
    /// idと合致するステータスデータの要素番号を渡す
    /// </summary>
    int GetEnemyStatus_index(int id)
    {
        int result = 0;

        for (int i = 0; i < enemyStatus.Length; i++)
        {
            if (enemyStatus[i].id == id)
            {
                result = i;
                break;
            }
        }

        return result;
    }

    /// <summary>
    /// idと合致する敵データベースの要素番号を渡す
    /// </summary>
    int GetEnemyDB_index(int id)
    {
        int result = 0;

        for (int i = 0; i < enemyDB.enemyDatas.Length; i++)
        {
            if (enemyDB.enemyDatas[i].id == id)
            {
                result = i;
                break;
            }
        }

        return result;
    }

    /// <summary>
    /// idの敵のLvを渡す
    /// </summary>
    public int GetStatus_Lv(int id)
    {
        int result = 0;

        int index = GetEnemyStatus_index(id);

        result = enemyStatus[index].lv;

        return result;
    }

    /// <summary>
    /// idの敵の名前を渡す
    /// </summary>
    public string GetStatus_Name(int id)
    {
        string result = "";

        int index = GetEnemyDB_index(id);

        result = enemyDB.enemyDatas[index].name;

        return result;
    }

    //基本ステータスの検索
    #region
    /// <summary>
    /// idの敵の基本ステータスを渡す
    /// </summary>
    StatusData GetStatus_Base(int id)
    {
        StatusData result;

        int index = GetEnemyStatus_index(id);

        result = enemyStatus[index].status_Base;

        return result;
    }

    /// <summary>
    /// idの敵の基本HPを渡す
    /// </summary>
    int GetStatus_BaseHP(int id)
    {
        int result = 0;

        int index = GetEnemyStatus_index(id);

        result = enemyStatus[index].status_Base.HP;

        return result;
    }
    #endregion

    //加算値の検索
    #region
    /// <summary>
    /// idの敵の加算値を渡す
    /// </summary>
    StatusData GetStatus_Plus(int id)
    {
        StatusData result;

        int index = GetEnemyStatus_index(id);

        result = enemyStatus[index].status_Plus;

        return result;
    }
    #endregion

    //変動値の検索
    #region
    /// <summary>
    /// idの敵の変動値を渡す
    /// </summary>
    StatusData GetStatus_Change(int id)
    {
        StatusData result;

        int index = GetEnemyStatus_index(id);

        result = enemyStatus[index].status_Change;

        return result;
    }
    #endregion

    //最大ステータスの検索
    #region
    /// <summary>
    /// idの敵の最大ステータスを渡す
    /// </summary>
    StatusData GetStatus_Max(int id)
    {
        StatusData result;

        int index = GetEnemyStatus_index(id);

        result = enemyStatus[index].status_Max;

        return result;
    }

    /// <summary>
    /// idの敵の最大ステータスをステータスごとに検索
    /// </summary>
    public int GetStatus_Max(int id, DataValidation._status status)
    {
        int result = 0;

        int index = GetEnemyStatus_index(id);

        // ステータスによる処理の分岐
        switch (status)
        {
            case DataValidation._status.HP:
                result = GetStatus_MaxHP(index);
                break;

            case DataValidation._status.MP:
                result = GetStatus_MaxMP(index);
                break;

            case DataValidation._status.SP:
                result = GetStatus_MaxSP(index);
                break;

            case DataValidation._status.STR:
                result = GetStatus_MaxSTR(index);
                break;

            case DataValidation._status.DEF:
                result = GetStatus_MaxDEF(index);
                break;

            case DataValidation._status.INT:
                result = GetStatus_MaxINT(index);
                break;

            case DataValidation._status.MND:
                result = GetStatus_MaxMND(index);
                break;

            case DataValidation._status.AGI:
                result = GetStatus_MaxAGI(index);
                break;

            case DataValidation._status.LUK:
                result = GetStatus_MaxLUK(index);
                break;

            case DataValidation._status.HIT:
                result = GetStatus_MaxHIT(index);
                break;

            case DataValidation._status.DEX:
                result = GetStatus_MaxDEX(index);
                break;

            case DataValidation._status.CRI:
                result = GetStatus_MaxCRI(index);
                break;

            case DataValidation._status.CRI_mul:
                result = GetStatus_MaxCRIMul(index);
                break;

            case DataValidation._status.Aptitude_Fire:
                result = GetStatus_MaxAptitudeFire(index);
                break;

            case DataValidation._status.Aptitude_Aqua:
                result = GetStatus_MaxAptitudeAqua(index);
                break;

            case DataValidation._status.Aptitude_Wind:
                result = GetStatus_MaxAptitudeWind(index);
                break;

            case DataValidation._status.Aptitude_Earth:
                result = GetStatus_MaxAptitudeEarth(index);
                break;

            case DataValidation._status.Aptitude_Light:
                result = GetStatus_MaxAptitudeLight(index);
                break;

            case DataValidation._status.Aptitude_Dark:
                result = GetStatus_MaxAptitudeDark(index);
                break;

            case DataValidation._status.Resist_Fire:
                result = GetStatus_MaxResistFire(index);
                break;

            case DataValidation._status.Resist_Aqua:
                result = GetStatus_MaxResistAqua(index);
                break;

            case DataValidation._status.Resist_Wind:
                result = GetStatus_MaxResistWind(index);
                break;

            case DataValidation._status.Resist_Earth:
                result = GetStatus_MaxResistEarth(index);
                break;

            case DataValidation._status.Resist_Light:
                result = GetStatus_MaxResistLight(index);
                break;

            case DataValidation._status.Resist_Dark:
                result = GetStatus_MaxResistDark(index);
                break;

            default:
                break;
        }

        return result;
    }
    //各ステータスの最大ステータスの取得
    #region
    //idの敵の最大HPを渡す
    int GetStatus_MaxHP(int index)
    {
        int result = 0;

        result = enemyStatus[index].status_Max.HP;

        return result;
    }

    // idの敵の最大MPを渡す
    int GetStatus_MaxMP(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.MP;
        return result;
    }

    // idの敵の最大SPを渡す
    int GetStatus_MaxSP(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.SP;
        return result;
    }

    // idの敵の最大筋力を渡す
    int GetStatus_MaxSTR(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.STR;
        return result;
    }

    // idの敵の最大耐久を渡す
    int GetStatus_MaxDEF(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.DEF;
        return result;
    }

    // idの敵の最大知力を渡す
    int GetStatus_MaxINT(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.INT;
        return result;
    }

    // idの敵の最大精神を渡す
    int GetStatus_MaxMND(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.MND;
        return result;
    }

    // idの敵の最大敏捷を渡す
    int GetStatus_MaxAGI(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.AGI;
        return result;
    }

    // idの敵の最大幸運を渡す
    int GetStatus_MaxLUK(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.LUK;
        return result;
    }

    // idの敵の最大命中率を渡す
    int GetStatus_MaxHIT(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.HIT;
        return result;
    }

    // idの敵の最大回避率を渡す
    int GetStatus_MaxDEX(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.DEX;
        return result;
    }

    // idの敵の最大会心率を渡す
    int GetStatus_MaxCRI(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.CRI;
        return result;
    }

    // idの敵の最大会心倍率を渡す
    int GetStatus_MaxCRIMul(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.CRI_mul;
        return result;
    }

    //最大の属性適性の取得
    #region
    // idの敵の最大の火属性適性を渡す
    int GetStatus_MaxAptitudeFire(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.Aptitude_Fire;
        return result;
    }

    // idの敵の最大の水属性適性を渡す
    int GetStatus_MaxAptitudeAqua(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.Aptitude_Aqua;
        return result;
    }

    // idの敵の最大の風属性適性を渡す
    int GetStatus_MaxAptitudeWind(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.Aptitude_Wind;
        return result;
    }

    // idの敵の最大の地属性適性を渡す
    int GetStatus_MaxAptitudeEarth(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.Aptitude_Earth;
        return result;
    }

    // idの敵の最大の光属性適性を渡す
    int GetStatus_MaxAptitudeLight(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.Aptitude_Light;
        return result;
    }

    // idの敵の最大の闇属性適性を渡す
    int GetStatus_MaxAptitudeDark(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.Aptitude_Dark;
        return result;
    }
    #endregion

    //最大の属性耐性の取得
    #region
    // idの敵の最大の火属性耐性を渡す
    int GetStatus_MaxResistFire(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.Resist_Fire;
        return result;
    }

    // idの敵の最大の水属性耐性を渡す
    int GetStatus_MaxResistAqua(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.Resist_Aqua;
        return result;
    }

    // idの敵の最大の風属性耐性を渡す
    int GetStatus_MaxResistWind(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.Resist_Wind;
        return result;
    }

    // idの敵の最大の地属性耐性を渡す
    int GetStatus_MaxResistEarth(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.Resist_Earth;
        return result;
    }

    // idの敵の最大の光属性耐性を渡す
    int GetStatus_MaxResistLight(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.Resist_Light;
        return result;
    }

    // idの敵の最大の闇属性耐性を渡す
    int GetStatus_MaxResistDark(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Max.Resist_Dark;
        return result;
    }
    #endregion
    #endregion
    #endregion

    //現在ステータスの検索
    #region
    /// <summary>
    /// idの敵の現在ステータスを渡す
    /// </summary>
    StatusData GetStatus_Current(int id)
    {
        StatusData result;

        int index = GetEnemyStatus_index(id);

        result = enemyStatus[index].status_Current;

        return result;
    }

    /// <summary>
    /// idの敵の現在ステータスをステータスごとに検索
    /// </summary>
    public int GetStatus_Current(int id, DataValidation._status status)
    {
        int result = 0;

        int index = GetEnemyStatus_index(id);

        // ステータスによる処理の分岐
        switch (status)
        {
            case DataValidation._status.HP:
                result = GetStatus_CurrentHP(index);
                break;

            case DataValidation._status.MP:
                result = GetStatus_CurrentMP(index);
                break;

            case DataValidation._status.SP:
                result = GetStatus_CurrentSP(index);
                break;

            case DataValidation._status.STR:
                result = GetStatus_CurrentSTR(index);
                break;

            case DataValidation._status.DEF:
                result = GetStatus_CurrentDEF(index);
                break;

            case DataValidation._status.INT:
                result = GetStatus_CurrentINT(index);
                break;

            case DataValidation._status.MND:
                result = GetStatus_CurrentMND(index);
                break;

            case DataValidation._status.AGI:
                result = GetStatus_CurrentAGI(index);
                break;

            case DataValidation._status.LUK:
                result = GetStatus_CurrentLUK(index);
                break;

            case DataValidation._status.HIT:
                result = GetStatus_CurrentHIT(index);
                break;

            case DataValidation._status.DEX:
                result = GetStatus_CurrentDEX(index);
                break;

            case DataValidation._status.CRI:
                result = GetStatus_CurrentCRI(index);
                break;

            case DataValidation._status.CRI_mul:
                result = GetStatus_CurrentCRIMul(index);
                break;

            case DataValidation._status.Aptitude_Fire:
                result = GetStatus_CurrentAptitudeFire(index);
                break;

            case DataValidation._status.Aptitude_Aqua:
                result = GetStatus_CurrentAptitudeAqua(index);
                break;

            case DataValidation._status.Aptitude_Wind:
                result = GetStatus_CurrentAptitudeWind(index);
                break;

            case DataValidation._status.Aptitude_Earth:
                result = GetStatus_CurrentAptitudeEarth(index);
                break;

            case DataValidation._status.Aptitude_Light:
                result = GetStatus_CurrentAptitudeLight(index);
                break;

            case DataValidation._status.Aptitude_Dark:
                result = GetStatus_CurrentAptitudeDark(index);
                break;

            case DataValidation._status.Resist_Fire:
                result = GetStatus_CurrentResistFire(index);
                break;

            case DataValidation._status.Resist_Aqua:
                result = GetStatus_CurrentResistAqua(index);
                break;

            case DataValidation._status.Resist_Wind:
                result = GetStatus_CurrentResistWind(index);
                break;

            case DataValidation._status.Resist_Earth:
                result = GetStatus_CurrentResistEarth(index);
                break;

            case DataValidation._status.Resist_Light:
                result = GetStatus_CurrentResistLight(index);
                break;

            case DataValidation._status.Resist_Dark:
                result = GetStatus_CurrentResistDark(index);
                break;

            default:
                break;
        }

        return result;
    }
    //各ステータスの現在ステータスの取得
    #region
    //idの敵の現在HPを渡す
    int GetStatus_CurrentHP(int index)
    {
        int result = 0;

        result = enemyStatus[index].status_Current.HP;

        return result;
    }

    // idの敵の現在MPを渡す
    int GetStatus_CurrentMP(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.MP;
        return result;
    }

    // idの敵の現在SPを渡す
    int GetStatus_CurrentSP(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.SP;
        return result;
    }

    // idの敵の現在筋力を渡す
    int GetStatus_CurrentSTR(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.STR;
        return result;
    }

    // idの敵の現在耐久を渡す
    int GetStatus_CurrentDEF(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.DEF;
        return result;
    }

    // idの敵の現在知力を渡す
    int GetStatus_CurrentINT(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.INT;
        return result;
    }

    // idの敵の現在精神を渡す
    int GetStatus_CurrentMND(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.MND;
        return result;
    }

    // idの敵の現在敏捷を渡す
    int GetStatus_CurrentAGI(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.AGI;
        return result;
    }

    // idの敵の現在幸運を渡す
    int GetStatus_CurrentLUK(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.LUK;
        return result;
    }

    // idの敵の現在命中率を渡す
    int GetStatus_CurrentHIT(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.HIT;
        return result;
    }

    // idの敵の現在回避率を渡す
    int GetStatus_CurrentDEX(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.DEX;
        return result;
    }

    // idの敵の現在会心率を渡す
    int GetStatus_CurrentCRI(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.CRI;
        return result;
    }

    // idの敵の現在会心倍率を渡す
    int GetStatus_CurrentCRIMul(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.CRI_mul;
        return result;
    }

    //現在の属性適性の取得
    #region
    // idの敵の現在の火属性適性を渡す
    int GetStatus_CurrentAptitudeFire(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.Aptitude_Fire;
        return result;
    }

    // idの敵の現在の水属性適性を渡す
    int GetStatus_CurrentAptitudeAqua(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.Aptitude_Aqua;
        return result;
    }

    // idの敵の現在の風属性適性を渡す
    int GetStatus_CurrentAptitudeWind(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.Aptitude_Wind;
        return result;
    }

    // idの敵の現在の地属性適性を渡す
    int GetStatus_CurrentAptitudeEarth(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.Aptitude_Earth;
        return result;
    }

    // idの敵の現在の光属性適性を渡す
    int GetStatus_CurrentAptitudeLight(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.Aptitude_Light;
        return result;
    }

    // idの敵の現在の闇属性適性を渡す
    int GetStatus_CurrentAptitudeDark(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.Aptitude_Dark;
        return result;
    }
    #endregion

    //現在の属性耐性の取得
    #region
    // idの敵の現在の火属性耐性を渡す
    int GetStatus_CurrentResistFire(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.Resist_Fire;
        return result;
    }

    // idの敵の現在の水属性耐性を渡す
    int GetStatus_CurrentResistAqua(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.Resist_Aqua;
        return result;
    }

    // idの敵の現在の風属性耐性を渡す
    int GetStatus_CurrentResistWind(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.Resist_Wind;
        return result;
    }

    // idの敵の現在の地属性耐性を渡す
    int GetStatus_CurrentResistEarth(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.Resist_Earth;
        return result;
    }

    // idの敵の現在の光属性耐性を渡す
    int GetStatus_CurrentResistLight(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.Resist_Light;
        return result;
    }

    // idの敵の現在の闇属性耐性を渡す
    int GetStatus_CurrentResistDark(int index)
    {
        int result = 0;
        result = enemyStatus[index].status_Current.Resist_Dark;
        return result;
    }
    #endregion
    #endregion
    
    public bool GetStatusEffect(int id, DataValidation._statusEffect statusEffect)
    {
        bool result = false;

        return result;
    }
    #endregion
    #endregion

    //ステータスの格納
    #region
    //基本ステータスの格納
    void SetStatus_Base(int id)
    {
        //lvの取得
        int lv = GetStatus_Lv(id);

        //それぞれの基本ステータスの格納
        #region
        SetStatus_BaseHP(id, lv);
        SetStatus_BaseMP(id, lv);
        SetStatus_BaseSP(id);
        SetStatus_BaseSTR(id, lv);
        SetStatus_BaseDEF(id, lv);
        SetStatus_BaseINT(id, lv);
        SetStatus_BaseMND(id, lv);
        SetStatus_BaseAGI(id, lv);
        SetStatus_BaseLUK(id, lv);
        SetStatus_BaseHIT(id);
        SetStatus_BaseDEX(id);
        SetStatus_BaseCRI(id);
        SetStatus_BaseCRI_mul(id);
        SetStatus_BaseAptitude_Fire(id);
        SetStatus_BaseAptitude_Aqua(id);
        SetStatus_BaseAptitude_Wind(id);
        SetStatus_BaseAptitude_Earth(id);
        SetStatus_BaseAptitude_Light(id);
        SetStatus_BaseAptitude_Dark(id);
        SetStatus_BaseResist_Fire(id);
        SetStatus_BaseResist_Aqua(id);
        SetStatus_BaseResist_Wind(id);
        SetStatus_BaseResist_Earth(id);
        SetStatus_BaseResist_Light(id);
        SetStatus_BaseResist_Dark(id);
        #endregion

        //最大ステータスの格納
        SetStatus_Max(id);
    }
    //基本ステータスのステータスごとの処理
    #region
    void SetStatus_BaseHP(int id, int lv)
    {
        int setNum = 0;  //格納する値用の変数

        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        int charaStatus = enemyDB.enemyDatas[enemyDB_index].HP;
        setNum = StatusCalculator_HPMP(charaStatus, lv);

        //値の格納
        enemyStatus[id].status_Base.HP = setNum;
    }

    void SetStatus_BaseMP(int id, int lv)
    {
        int setNum = 0;  //格納する値用の変数

        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        int charaStatus = enemyDB.enemyDatas[enemyDB_index].MP;
        setNum = StatusCalculator_HPMP(charaStatus, lv);

        //値の格納
        enemyStatus[id].status_Base.MP = setNum;
    }

    void SetStatus_BaseSP(int id)
    {
        int setNum = 100;  //格納する値用の変数
                           //SPの基本ステータスは100で固定

        //値の格納
        enemyStatus[id].status_Base.SP = setNum;
    }

    void SetStatus_BaseSTR(int id, int lv)
    {
        int setNum = 0;  //格納する値用の変数

        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        int charaStatus = enemyDB.enemyDatas[enemyDB_index].STR;
        setNum = StatusCalculator_Others(charaStatus, lv);

        //値の格納
        enemyStatus[id].status_Base.STR = setNum;
    }

    void SetStatus_BaseDEF(int id, int lv)
    {
        int setNum = 0;  //格納する値用の変数

        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        int charaStatus = enemyDB.enemyDatas[enemyDB_index].DEF;
        setNum = StatusCalculator_Others(charaStatus, lv);

        //値の格納
        enemyStatus[id].status_Base.DEF = setNum;
    }

    void SetStatus_BaseINT(int id, int lv)
    {
        int setNum = 0;  //格納する値用の変数

        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        int charaStatus = enemyDB.enemyDatas[enemyDB_index].INT;
        setNum = StatusCalculator_Others(charaStatus, lv);

        //値の格納
        enemyStatus[id].status_Base.INT = setNum;
    }

    void SetStatus_BaseMND(int id, int lv)
    {
        int setNum = 0;  //格納する値用の変数

        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        int charaStatus = enemyDB.enemyDatas[enemyDB_index].MND;
        setNum = StatusCalculator_Others(charaStatus, lv);

        //値の格納
        enemyStatus[id].status_Base.MND = setNum;
    }

    void SetStatus_BaseAGI(int id, int lv)
    {
        int setNum = 0;  //格納する値用の変数

        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        int charaStatus = enemyDB.enemyDatas[enemyDB_index].AGI;
        setNum = StatusCalculator_Others(charaStatus, lv);

        //値の格納
        enemyStatus[id].status_Base.AGI = setNum;
    }

    void SetStatus_BaseLUK(int id, int lv)
    {
        int setNum = 0;  //格納する値用の変数

        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        int charaStatus = enemyDB.enemyDatas[enemyDB_index].LUK;
        setNum = StatusCalculator_Others(charaStatus, lv);

        //値の格納
        enemyStatus[id].status_Base.LUK = setNum;
    }

    //確率の基本ステータスの格納
    #region
    void SetStatus_BaseHIT(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].HIT;

        //値の格納
        enemyStatus[id].status_Base.HIT = setNum;
    }

    void SetStatus_BaseDEX(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].DEX;

        //値の格納
        enemyStatus[id].status_Base.DEX = setNum;
    }

    void SetStatus_BaseCRI(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].CRI;

        //値の格納
        enemyStatus[id].status_Base.CRI = setNum;
    }

    void SetStatus_BaseCRI_mul(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].CRI_mul;

        //値の格納
        enemyStatus[id].status_Base.CRI_mul = setNum;
    }
    #endregion

    //属性適性の基本ステータスの格納
    #region
    void SetStatus_BaseAptitude_Fire(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].Aptitude_Fire;

        //値の格納
        enemyStatus[id].status_Base.Aptitude_Fire = setNum;
    }

    void SetStatus_BaseAptitude_Aqua(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].Aptitude_Aqua;

        //値の格納
        enemyStatus[id].status_Base.Aptitude_Aqua = setNum;
    }

    void SetStatus_BaseAptitude_Wind(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].Aptitude_Wind;

        //値の格納
        enemyStatus[id].status_Base.Aptitude_Wind = setNum;
    }

    void SetStatus_BaseAptitude_Earth(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].Aptitude_Earth;

        //値の格納
        enemyStatus[id].status_Base.Aptitude_Earth = setNum;
    }

    void SetStatus_BaseAptitude_Light(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].Aptitude_Light;

        //値の格納
        enemyStatus[id].status_Base.Aptitude_Light = setNum;
    }

    void SetStatus_BaseAptitude_Dark(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].Aptitude_Dark;

        //値の格納
        enemyStatus[id].status_Base.Aptitude_Dark = setNum;
    }
    #endregion

    //属性耐性の基本ステータスの格納
    #region
    void SetStatus_BaseResist_Fire(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].Resist_Fire;

        //値の格納
        enemyStatus[id].status_Base.Resist_Fire = setNum;
    }

    void SetStatus_BaseResist_Aqua(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].Resist_Aqua;

        //値の格納
        enemyStatus[id].status_Base.Resist_Aqua = setNum;
    }

    void SetStatus_BaseResist_Wind(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].Resist_Wind;

        //値の格納
        enemyStatus[id].status_Base.Resist_Wind = setNum;
    }

    void SetStatus_BaseResist_Earth(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].Resist_Earth;

        //値の格納
        enemyStatus[id].status_Base.Resist_Earth = setNum;
    }

    void SetStatus_BaseResist_Light(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].Resist_Light;

        //値の格納
        enemyStatus[id].status_Base.Resist_Light = setNum;
    }

    void SetStatus_BaseResist_Dark(int id)
    {
        int setNum = 0;  //格納する値用の変数

        
        
        int enemyDB_index = GetEnemyDB_index(id);

        //格納する値の取得
        setNum = enemyDB.enemyDatas[enemyDB_index].Resist_Dark;

        //値の格納
        enemyStatus[id].status_Base.Resist_Dark = setNum;
    }
    #endregion

    //ステータスの計算式
    #region
    /// <summary>
    /// HPとMPのステータスの計算式
    /// </summary>
    int StatusCalculator_HPMP(int charaStatus, int lv)
    {
        int result = 0;

        result = charaStatus * 10 * lv / 10 + lv + 10;

        return result;
    }

    /// <summary>
    /// HPとMP以外のステータスの計算式
    /// </summary>
    int StatusCalculator_Others(int charaStatus, int lv)
    {
        int result = 0;

        result = charaStatus * 5 * lv / 100;

        return result;
    }
    #endregion
    #endregion

    //加算値の格納
    public void SetStatus_Plus(int id, int plusNum, DataValidation._status status)
    {
        //ステータスによる処理の分岐
        switch (status)
        {
            case DataValidation._status.HP:
                SetStatus_PlusHP(id, plusNum);
                break;
            case DataValidation._status.MP:
                SetStatus_PlusMP(id, plusNum);
                break;
            case DataValidation._status.STR:
                SetStatus_PlusSTR(id, plusNum);
                break;
            case DataValidation._status.DEF:
                SetStatus_PlusDEF(id, plusNum);
                break;
            case DataValidation._status.INT:
                SetStatus_PlusINT(id, plusNum);
                break;
            case DataValidation._status.MND:
                SetStatus_PlusMND(id, plusNum);
                break;
            case DataValidation._status.AGI:
                SetStatus_PlusAGI(id, plusNum);
                break;
            case DataValidation._status.LUK:
                SetStatus_PlusLUK(id, plusNum);
                break;
            case DataValidation._status.HIT:
                SetStatus_PlusHIT(id, plusNum);
                break;
            case DataValidation._status.DEX:
                SetStatus_PlusDEX(id, plusNum);
                break;
            case DataValidation._status.CRI:
                SetStatus_PlusCRI(id, plusNum);
                break;
            case DataValidation._status.CRI_mul:
                SetStatus_PlusCRI_mul(id, plusNum);
                break;
            case DataValidation._status.Aptitude_Fire:
                SetStatus_PlusAptitude_Fire(id, plusNum);
                break;

            case DataValidation._status.Aptitude_Aqua:
                SetStatus_PlusAptitude_Aqua(id, plusNum);
                break;

            case DataValidation._status.Aptitude_Wind:
                SetStatus_PlusAptitude_Wind(id, plusNum);
                break;

            case DataValidation._status.Aptitude_Earth:
                SetStatus_PlusAptitude_Earth(id, plusNum);
                break;

            case DataValidation._status.Aptitude_Light:
                SetStatus_PlusAptitude_Light(id, plusNum);
                break;

            case DataValidation._status.Aptitude_Dark:
                SetStatus_PlusAptitude_Dark(id, plusNum);
                break;

            case DataValidation._status.Resist_Fire:
                SetStatus_PlusResist_Fire(id, plusNum);
                break;

            case DataValidation._status.Resist_Aqua:
                SetStatus_PlusResist_Aqua(id, plusNum);
                break;

            case DataValidation._status.Resist_Wind:
                SetStatus_PlusResist_Wind(id, plusNum);
                break;

            case DataValidation._status.Resist_Earth:
                SetStatus_PlusResist_Earth(id, plusNum);
                break;

            case DataValidation._status.Resist_Light:
                SetStatus_PlusResist_Light(id, plusNum);
                break;

            case DataValidation._status.Resist_Dark:
                SetStatus_PlusResist_Dark(id, plusNum);
                break;
            default:
                break;
        }

        //最大ステータスの格納
        SetStatus_Max(id);
    }
    //加算値のステータスごとの処理
    #region
    void SetStatus_PlusHP(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.HP += plusNum;
    }

    void SetStatus_PlusMP(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.MP += plusNum;
    }

    void SetStatus_PlusSTR(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.STR += plusNum;
    }

    void SetStatus_PlusDEF(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.DEF += plusNum;
    }

    void SetStatus_PlusINT(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.INT += plusNum;
    }

    void SetStatus_PlusMND(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.MND += plusNum;
    }

    void SetStatus_PlusAGI(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.AGI += plusNum;
    }

    void SetStatus_PlusLUK(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.LUK += plusNum;
    }

    void SetStatus_PlusHIT(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.HIT += plusNum;
    }

    void SetStatus_PlusDEX(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.DEX += plusNum;
    }

    void SetStatus_PlusCRI(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.CRI += plusNum;
    }

    void SetStatus_PlusCRI_mul(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.CRI_mul += plusNum;
    }

    void SetStatus_PlusAptitude_Fire(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.Aptitude_Fire += plusNum;
    }

    void SetStatus_PlusAptitude_Aqua(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.Aptitude_Aqua += plusNum;
    }

    void SetStatus_PlusAptitude_Wind(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.Aptitude_Wind += plusNum;
    }

    void SetStatus_PlusAptitude_Earth(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.Aptitude_Earth += plusNum;
    }

    void SetStatus_PlusAptitude_Light(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.Aptitude_Light += plusNum;
    }

    void SetStatus_PlusAptitude_Dark(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.Aptitude_Dark += plusNum;
    }

    void SetStatus_PlusResist_Fire(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.Resist_Fire += plusNum;
    }

    void SetStatus_PlusResist_Aqua(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.Resist_Aqua += plusNum;
    }

    void SetStatus_PlusResist_Wind(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.Resist_Wind += plusNum;
    }

    void SetStatus_PlusResist_Earth(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.Resist_Earth += plusNum;
    }

    void SetStatus_PlusResist_Light(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.Resist_Light += plusNum;
    }

    void SetStatus_PlusResist_Dark(int id, int plusNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Plus.Resist_Dark += plusNum;
    }
    #endregion

    //変動値の格納
    public void SetStatus_Change(int id, int changeNum, DataValidation._status status)
    {
        //ステータスによる処理の分岐
        switch (status)
        {
            case DataValidation._status.HP:
                SetStatus_ChangeHP(id, changeNum);
                break;
            case DataValidation._status.MP:
                SetStatus_ChangeMP(id, changeNum);
                break;
            case DataValidation._status.SP:
                SetStatus_ChangeSP(id, changeNum);
                break;
            case DataValidation._status.STR:
                SetStatus_ChangeSTR(id, changeNum);
                break;
            case DataValidation._status.DEF:
                SetStatus_ChangeDEF(id, changeNum);
                break;
            case DataValidation._status.INT:
                SetStatus_ChangeINT(id, changeNum);
                break;
            case DataValidation._status.MND:
                SetStatus_ChangeMND(id, changeNum);
                break;
            case DataValidation._status.AGI:
                SetStatus_ChangeAGI(id, changeNum);
                break;
            case DataValidation._status.LUK:
                SetStatus_ChangeLUK(id, changeNum);
                break;
            case DataValidation._status.HIT:
                SetStatus_ChangeHIT(id, changeNum);
                break;
            case DataValidation._status.DEX:
                SetStatus_ChangeDEX(id, changeNum);
                break;
            case DataValidation._status.CRI:
                SetStatus_ChangeCRI(id, changeNum);
                break;
            case DataValidation._status.CRI_mul:
                SetStatus_ChangeCRI_mul(id, changeNum);
                break;
            case DataValidation._status.Aptitude_Fire:
                SetStatus_ChangeAptitude_Fire(id, changeNum);
                break;

            case DataValidation._status.Aptitude_Aqua:
                SetStatus_ChangeAptitude_Aqua(id, changeNum);
                break;

            case DataValidation._status.Aptitude_Wind:
                SetStatus_ChangeAptitude_Wind(id, changeNum);
                break;

            case DataValidation._status.Aptitude_Earth:
                SetStatus_ChangeAptitude_Earth(id, changeNum);
                break;

            case DataValidation._status.Aptitude_Light:
                SetStatus_ChangeAptitude_Light(id, changeNum);
                break;

            case DataValidation._status.Aptitude_Dark:
                SetStatus_ChangeAptitude_Dark(id, changeNum);
                break;

            case DataValidation._status.Resist_Fire:
                SetStatus_ChangeResist_Fire(id, changeNum);
                break;

            case DataValidation._status.Resist_Aqua:
                SetStatus_ChangeResist_Aqua(id, changeNum);
                break;

            case DataValidation._status.Resist_Wind:
                SetStatus_ChangeResist_Wind(id, changeNum);
                break;

            case DataValidation._status.Resist_Earth:
                SetStatus_ChangeResist_Earth(id, changeNum);
                break;

            case DataValidation._status.Resist_Light:
                SetStatus_ChangeResist_Light(id, changeNum);
                break;

            case DataValidation._status.Resist_Dark:
                SetStatus_ChangeResist_Dark(id, changeNum);
                break;
            default:
                break;
        }

        //現在ステータスの格納
        SetStatus_Current(id);
    }
    //変動値のステータスごとの処理
    #region
    void SetStatus_ChangeHP(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.HP += changeNum;
    }

    void SetStatus_ChangeMP(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.MP += changeNum;
    }

    void SetStatus_ChangeSP(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.SP += changeNum;
    }

    void SetStatus_ChangeSTR(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.STR += changeNum;
    }

    void SetStatus_ChangeDEF(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.DEF += changeNum;
    }

    void SetStatus_ChangeINT(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.INT += changeNum;
    }

    void SetStatus_ChangeMND(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.MND += changeNum;
    }

    void SetStatus_ChangeAGI(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.AGI += changeNum;
    }

    void SetStatus_ChangeLUK(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.LUK += changeNum;
    }

    void SetStatus_ChangeHIT(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.HIT += changeNum;
    }

    void SetStatus_ChangeDEX(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.DEX += changeNum;
    }

    void SetStatus_ChangeCRI(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.CRI += changeNum;
    }

    void SetStatus_ChangeCRI_mul(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.CRI_mul += changeNum;
    }

    void SetStatus_ChangeAptitude_Fire(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.Aptitude_Fire += changeNum;
    }

    void SetStatus_ChangeAptitude_Aqua(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.Aptitude_Aqua += changeNum;
    }

    void SetStatus_ChangeAptitude_Wind(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.Aptitude_Wind += changeNum;
    }

    void SetStatus_ChangeAptitude_Earth(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.Aptitude_Earth += changeNum;
    }

    void SetStatus_ChangeAptitude_Light(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.Aptitude_Light += changeNum;
    }

    void SetStatus_ChangeAptitude_Dark(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.Aptitude_Dark += changeNum;
    }

    void SetStatus_ChangeResist_Fire(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.Resist_Fire += changeNum;
    }

    void SetStatus_ChangeResist_Aqua(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.Resist_Aqua += changeNum;
    }

    void SetStatus_ChangeResist_Wind(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.Resist_Wind += changeNum;
    }

    void SetStatus_ChangeResist_Earth(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.Resist_Earth += changeNum;
    }

    void SetStatus_ChangeResist_Light(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.Resist_Light += changeNum;
    }

    void SetStatus_ChangeResist_Dark(int id, int changeNum)
    {
        
        
        //値の格納
        enemyStatus[id].status_Change.Resist_Dark += changeNum;
    }
    #endregion

    //最大ステータスの格納
    void SetStatus_Max(int id)
    {
        StatusData setStatus;
        setStatus = GetStatus_Base(id) + GetStatus_Plus(id);

        enemyStatus[id].status_Max = setStatus;

        //現在ステータスの格納
        SetStatus_Current(id);
    }

    //現在ステータスの格納
    void SetStatus_Current(int id)
    {
        StatusData setStatus;
        setStatus = GetStatus_Max(id) + GetStatus_Change(id);

        enemyStatus[id].status_Current = setStatus;
    }
    #endregion

    public void Damage(int id, int damage)
    {
        SetStatus_Change(id, -damage, DataValidation._status.HP);
    }
}
