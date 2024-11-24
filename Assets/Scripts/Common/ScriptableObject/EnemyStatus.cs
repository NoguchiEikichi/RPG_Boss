using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "ScriptableObjects/CreateEnemyStatusDataAsset")]
public class EnemyStatus : ScriptableObject
{
    public EnemyStatusData[] enemyStatusDatas;
}