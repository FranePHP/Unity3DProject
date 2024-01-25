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
                // Now you have the JSON data in the 'jsonText' variable.

                // Call a method to handle the JSON data (e.g., parse it and process it).
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

        // Optionally, you can also download and save other files here.

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
}

