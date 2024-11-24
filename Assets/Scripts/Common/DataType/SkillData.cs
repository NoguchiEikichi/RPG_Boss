[System.Serializable]
public class SkillData
{
    public int id;
    public string name;
    public DataValidation._status costStatus;  //使用時に支払うコストのステータス
    public int costNum;  //使用時に支払うコストの量
    public DataValidation._status effectFormula_AttackStatus;  //攻撃側の使用ステータス
    public float effectFormula_AttackStatus_mul;  //攻撃側の効果の倍率
    public DataValidation._status effectFormula_DefenceStatus;  //防御側の使用ステータス
    public float effectFormula_DefenceStatus_mul;  //防御側の効果の倍率
    public DataValidation._element element;  //スキルの属性
    public DataValidation._skillType type;  //スキルの分類
    public DataValidation._target target;  //使用対象
    public int HIT;  //命中率
    public int CRI;  //会心の確率
    public int CRI_mul;  //会心の倍率
    public string additionalEffect;  //追加効果三つまで
    public string description;  //説明文
    public string flavorText;  //フレーバーテキスト
    public string useText;  //使用時のテキスト
    public string sprite;  //画像のリンク
    public string effect;  //エフェクトのリンク
}