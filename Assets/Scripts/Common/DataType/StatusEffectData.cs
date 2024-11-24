[System.Serializable]
public class StatusEffectData
{
    public bool deadFLG;
    public bool defenseFLG;
    //バフに関する変数
    #region
    /// <summary>
    /// [バフの効力, バフの持続時間]
    /// </summary>
    public int[] buff_HP = new int[2];
    /// <summary>
    /// [バフの効力, バフの持続時間]
    /// </summary>
    public int[] buff_MP = new int[2];
    /// <summary>
    /// [バフの効力, バフの持続時間]
    /// </summary>
    public int[] buff_STR = new int[2];
    /// <summary>
    /// [バフの効力, バフの持続時間]
    /// </summary>
    public int[] buff_DEF = new int[2];
    #endregion
}
