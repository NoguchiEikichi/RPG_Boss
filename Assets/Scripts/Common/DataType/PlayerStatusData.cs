using System.Collections.Generic;
[System.Serializable]
public class PlayerStatusData
{
    public int id;
    public int lv;
    public int exp;

    //ステータス関連
    #region
    /// <summary>
    /// レベルによる基本的なステータス
    /// 基本ステータス
    /// </summary>
    public StatusData status_Base;

    /// <summary>
    /// 装備やアイテムによる継続する変動値
    /// 加算値
    /// </summary>
    public StatusData status_Plus;

    /// <summary>
    /// 消費やスキルによる一時的な変動値
    /// 変動値
    /// </summary>
    public StatusData status_Change;

    /// <summary>
    /// 現在のステータスの最大値
    /// 最大ステータス
    /// </summary>
    public StatusData status_Max;

    /// <summary>
    /// 現在のステータス
    /// 現在ステータス
    /// </summary>
    public StatusData status_Current;
    #endregion

    /// <summary>
    /// 状態変化のフラグ
    /// </summary>
    public StatusEffectData statusEffect;

    /// <summary>
    /// 装備品のID格納用の変数
    /// </summary>
    public EquipPositionData equip;

    public List<int> skill;
}