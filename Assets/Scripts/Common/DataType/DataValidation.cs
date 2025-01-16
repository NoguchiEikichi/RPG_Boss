[System.Serializable]
public class DataValidation  //ゲーム全体で共通のenumを定義
{
    //コマンドの種類
    public enum _command
    {
        Attack,
        Skill,
        Defense,
        Item,
        None
    }

    //ステータスの種類
    public enum _status
    {
        HP,
        MP,
        SP,
        STR,
        DEF,
        INT,
        MND,
        AGI,
        LUK,
        HIT,
        DEX,
        CRI,
        CRI_mul,
        Aptitude_Fire,
        Aptitude_Aqua,
        Aptitude_Wind,
        Aptitude_Earth,
        Aptitude_Light,
        Aptitude_Dark,
        Resist_Fire,
        Resist_Aqua,
        Resist_Wind,
        Resist_Earth,
        Resist_Light,
        Resist_Dark
    }

    //プレイヤーの種類
    public enum _roll
    {
        warrior,
        mage,
        priest,
    }

    //状態変化の種類
    public enum _statusEffect
    {
        Defense,
        Dead,
    }

    //属性の種類
    public enum _element
    {
        Fire,
        Aqua,
        Wind,
        Earth,
        Light,
        Dark,
        None
    }

    //スキルの分類
    public enum _skillType
    {
        Attack,
        Heal,
        Buff,
        Move,
    }

    //スキルやアイテムを使用する対象の種類
    public enum _target
    {
        enemy_Once,
        enemy_All,
        enemy_Random,
        oneself,
        ally_Once,
        ally_All,
        ally_Random,
    }

    //スキルの追加効果
    public enum _additionalEffect
    {
        //特殊効果
        multistrike,  //複数回攻撃
        recoil,  //反動ダメージを受ける
        drain,  //HPを吸収する
        penetrate,  //相手のバフを無視してダメージを与える
        quick,  //先制攻撃
        cancellation,  //バフ解除
        amplify,  //ステータス上昇数に応じて威力アップ

        //状態変化付与
        posioned,  //毒状態付与
        stunned,  //スタン状態付与
        burn,  //火傷状態付与
        blind,  //盲目状態付与
        frozen,  //凍結状態付与
        silenced,  //沈黙状態付与
        dazzle,  //幻惑状態付与
        defence,  //ダメージカット状態付与
        attention,  //ターゲット集中状態付与
        regenerate,  //リジェネ状態付与

        //状態異常回復
        cure,
        statusReset,
        allCure,
        resurrection,

        //ステータス上昇
        up_STR,
        up_DEF,
        up_INT,
        up_MND,
        up_AGI,

        //ステータス低下
        down_STR,
        down_DEF,
        down_INT,
        down_MND,
        down_AGI,

        none,
    }

    //敵の行動パターンの種類
    public enum _pattern
    {
        random,
        systematic,
        logical,
        none
    }
}