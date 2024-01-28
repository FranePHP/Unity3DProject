using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class DataLoader : MonoBehaviour
{
    private string jsonDownloadURL = "https://raw.githubusercontent.com/FranePHP/Unity3DProject/main/data.json";

    private void Start()
    {
        StartCoroutine(DownloadJSON());
    }

    private IEnumerator DownloadJSON()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(jsonDownloadURL))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string jsonText = webRequest.downloadHandler.text;
                // JSON data in the 'jsonText' variable.
                
                HandleJSONData(jsonText);
            }
            else
            {
                Debug.LogError("Failed to download JSON: " + webRequest.error);
            }
        }
    }

    private void HandleJSONData(string jsonText)
    {
        // Save JSON data to persistent data path
        string filePath = Path.Combine(Application.persistentDataPath, "data.json");
        File.WriteAllText(filePath, jsonText);

        Debug.Log("Data saved to: " + filePath);
    }

    private string LoadJSONData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "data.json");

        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }

        Debug.LogError("JSON file not found at: " + filePath);
        return null;
    }

    public LanguageData[] GetLanguages()
    {
        // Logic to get language data from your JSON or wherever it's stored
        // Return an array of LanguageData
        return new LanguageData[]
        {
            new LanguageData { LanguageId = 1, LanguageName = "Hrvatski" },
            new LanguageData { LanguageId = 2, LanguageName = "English" },
            new LanguageData { LanguageId = 3, LanguageName = "Deutsch" },
            // Add more languages as needed
        };
    }
}

