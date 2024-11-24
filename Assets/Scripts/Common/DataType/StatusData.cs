[System.Serializable]
public class StatusData
{
    public int HP;
    public int MP;
    public int SP;
    public int STR;
    public int DEF;
    public int INT;
    public int MND;
    public int AGI;
    public int LUK;
    public int HIT;
    public int DEX;
    public int CRI;
    public int CRI_mul;
    public int Aptitude_Fire;
    public int Aptitude_Aqua;
    public int Aptitude_Wind;
    public int Aptitude_Earth;
    public int Aptitude_Light;
    public int Aptitude_Dark;
    public int Resist_Fire;
    public int Resist_Aqua;
    public int Resist_Wind;
    public int Resist_Earth;
    public int Resist_Light;
    public int Resist_Dark;

    // + 演算子をオーバーロードして、StatusData同士の加算を可能にする
    public static StatusData operator +(StatusData a, StatusData b)
    {
        return new StatusData
        {
            HP = a.HP + b.HP,
            MP = a.MP + b.MP,
            SP = a.SP + b.SP,
            STR = a.STR + b.STR,
            DEF = a.DEF + b.DEF,
            INT = a.INT + b.INT,
            MND = a.MND + b.MND,
            AGI = a.AGI + b.AGI,
            LUK = a.LUK + b.LUK,
            HIT = a.HIT + b.HIT,
            DEX = a.DEX + b.DEX,
            CRI = a.CRI + b.CRI,
            CRI_mul = a.CRI_mul + b.CRI_mul,
            Aptitude_Fire = a.Aptitude_Fire + b.Aptitude_Fire,
            Aptitude_Aqua = a.Aptitude_Aqua + b.Aptitude_Aqua,
            Aptitude_Wind = a.Aptitude_Wind + b.Aptitude_Wind,
            Aptitude_Earth = a.Aptitude_Earth + b.Aptitude_Earth,
            Aptitude_Light = a.Aptitude_Light + b.Aptitude_Light,
            Aptitude_Dark = a.Aptitude_Dark + b.Aptitude_Dark,
            Resist_Fire = a.Resist_Fire + b.Resist_Fire,
            Resist_Aqua = a.Resist_Aqua + b.Resist_Aqua,
            Resist_Wind = a.Resist_Wind + b.Resist_Wind,
            Resist_Earth = a.Resist_Earth + b.Resist_Earth,
            Resist_Light = a.Resist_Light + b.Resist_Light,
            Resist_Dark = a.Resist_Dark + b.Resist_Dark
        };
    }
}
