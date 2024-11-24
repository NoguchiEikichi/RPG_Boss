using UnityEngine;

[CreateAssetMenu(fileName = "SkillDatabase", menuName = "ScriptableObjects/CreateSkillDataAsset")]
public class SkillDatabase : ScriptableObject
{
    public SkillData[] skillDatas;
}