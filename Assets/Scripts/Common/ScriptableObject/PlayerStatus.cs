using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "ScriptableObjects/CreatePlayerStatusDataAsset")]
public class PlayerStatus : ScriptableObject
{
    public PlayerStatusData[] playerStatusDatas;
}