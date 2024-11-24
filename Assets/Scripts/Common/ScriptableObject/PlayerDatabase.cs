using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDatabase", menuName = "ScriptableObjects/CreatePlayerDataAsset")]
public class PlayerDatabase : ScriptableObject
{
    public PlayerData[] playerDatas;
}