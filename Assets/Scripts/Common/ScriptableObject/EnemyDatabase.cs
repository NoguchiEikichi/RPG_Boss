using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDatabase", menuName = "ScriptableObjects/CreateEnemyDataAsset")]
public class EnemyDatabase : ScriptableObject
{
    public EnemyData[] enemyDatas;
}