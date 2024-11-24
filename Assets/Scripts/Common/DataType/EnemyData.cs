[System.Serializable]
public class EnemyData : StatusData
{
    public int id;
    public string name;
    public int dropEXP;
    public int dropG;
    public int dropItemID_1;
    public int dropItemChance_1;
    public int dropItemID_2;
    public int dropItemChance_2;
    public DataValidation._pattern pattern;
    public string useSkill;
    public int judge;
    public string flavorText;
    public string sprite;
}