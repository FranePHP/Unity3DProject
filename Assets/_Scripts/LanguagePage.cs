using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanguagePage : MonoBehaviour
{    
    public DataLoader dataLoader;
   
    public Button languageButtonPrefab;
    
    public Transform buttonContainer;

    private void Start()
    {        
        CreateLanguageButtons();
    }

    private void CreateLanguageButtons()
    {
        // Get language data from the DataLoader or your JSON data
        LanguageData[] languages = dataLoader.GetLanguages();

        foreach (LanguageData language in languages)
        {            
            Button languageButton = Instantiate(languageButtonPrefab, buttonContainer);            
            languageButton.GetComponentInChildren<Text>().text = language.LanguageName;            
            languageButton.onClick.AddListener(() => OnLanguageButtonClick(language.LanguageId));
        }
    }

    private void OnLanguageButtonClick(int selectedLanguageId)
    {
        // Handle language selection        
        PlayerPrefs.SetInt("SelectedLanguage", selectedLanguageId);                
    }
}
