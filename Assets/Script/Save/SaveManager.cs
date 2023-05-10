using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private string saveFileName = "gameData.txt";

    public void SaveGameData(string gameData)
    {
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);
        File.WriteAllText(filePath, gameData);
        Debug.Log("Game data saved!");
    }
}