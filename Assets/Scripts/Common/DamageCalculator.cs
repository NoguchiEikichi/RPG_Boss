using UnityEngine;

public static class DamageCalculator
{
    //二つの数値を使用したダメージ計算
    public static int CalculateDamage(int numX, int numY)
    {
        int result = 0;

        result = numX + numY;

        float random = Random.Range(0.8f, 1f);

        result = (int)(result * random);

        return result;
    }
    
    //三つの数値を使用したダメージ計算
    public static int CalculateDamage(int numX, int numY, int numZ)
    {
        int result = 0;

        result = numX + numY + numZ;

        float random = Random.Range(1f, 1.25f);

        result = (int)(result * random);

        return result;
    }
}