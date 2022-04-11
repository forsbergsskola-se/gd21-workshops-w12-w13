using UnityEngine;

public class PlayerSaveDataManager : MonoBehaviour
{
    [SerializeField] private SaveDataManager saveDataManager;
    [SerializeField] private float health;
    [SerializeField] private int score;

    private void OnEnable()
    {
        saveDataManager.OnSaveDataLoaded += UpdatePlayerFromSaveData;
    }

    private void OnDisable()
    {
        saveDataManager.OnSaveDataLoaded -= UpdatePlayerFromSaveData;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
            saveDataManager.SetPlayerSaveData(transform.position, health, score);
    }

    private void UpdatePlayerFromSaveData(SaveData saveData)
    {
        transform.position = saveData.playerPosition;
        health = saveData.playerHealth;
        score = saveData.playerScore;
    }
}