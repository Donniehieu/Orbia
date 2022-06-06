
using UnityEngine;
using System.IO;
public class DataManager :MonoBehaviour
{
    string filePath;
 
    string fileContent;
    [ContextMenu("SaveGameData")]
    public void SaveData(DataGame dataGame)
    {
        filePath = Application.dataPath + "/DataGame/PlayingData.json";
        fileContent = JsonUtility.ToJson(dataGame);
        File.WriteAllText(filePath, fileContent);


    }
    [ContextMenu("LoadGameData")]
    public void LoadData()
    {
        DataGame dataGame = new DataGame();
        filePath = Application.dataPath+ "/DataGame/PlayingData.json";
        if(!File.Exists(filePath))
        {
            return;
        }
        fileContent= File.ReadAllText(filePath);
        dataGame = JsonUtility.FromJson<DataGame>(filePath);
      


       

    }
}
