using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    public Vector3 playerPosition;
    public float playerHealth;
    public int playerScore;

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string jsonData)
    {
        JsonUtility.FromJsonOverwrite(jsonData, this);
    }
}