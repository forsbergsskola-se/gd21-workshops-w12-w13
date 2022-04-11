using System;
using System.IO;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    private const string SaveFileName = "OurCustomSaveData.dat";

    public SaveData ourSaveData; //Leaving our SaveData public for simplicity, but in an actual game it should be private for a more controlled data-flow.

    public Action<SaveData> OnSaveDataLoaded;

    private void Update()
    {
        //Could be replaced with calls from UI buttons. Or it could be triggered when the player reaches a checkpoint, etc.
        if (Input.GetKeyDown(KeyCode.F1))
            Save();
        if (Input.GetKeyDown(KeyCode.F2))
            Load();
    }

    public void SetPlayerSaveData(Vector3 position, float health, int score)
    {
        ourSaveData.playerPosition = position;
        ourSaveData.playerHealth = health;
        ourSaveData.playerScore = score;
        Debug.Log("Set player data");
    }

    public void Save()
    {
        var jsonSaveData = ourSaveData.ToJson();
        var fullPath = Path.Combine(Application.persistentDataPath, SaveFileName);

        File.WriteAllText(fullPath, jsonSaveData);
        Debug.Log("Saved data");
    }

    public void Load()
    {
        var fullPath = Path.Combine(Application.persistentDataPath, SaveFileName);
        if (File.Exists(fullPath) == false)
        {
            Debug.Log("No save file found!");
            return;
        }

        var result = File.ReadAllText(fullPath);

        //For an example of try/catch error handling, see: https://github.com/UnityTechnologies/UniteNow20-Persistent-Data/blob/main/FileManager.cs

        ourSaveData.LoadFromJson(result);
        Debug.Log("Loaded data");
        OnSaveDataLoaded?.Invoke(ourSaveData);
    }
}