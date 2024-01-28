using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{    
    private AudioSource audioSource;

    // Method to be called when a language button is pressed
    public void OnLanguageButtonClick(string languageSceneName)
    {        
        SceneManager.LoadScene(languageSceneName);
    }

    // Method to be called when the back button is pressed
    public void OnBackButtonClick(string previousSceneName)
    {        
        SceneManager.LoadScene(previousSceneName);
    }

    // Method to be called when the play button is pressed
    public void OnPlayButtonClick()
    {
        if (audioSource != null)
        {            
            audioSource.Play();
        }
    }

    // Method to be called when the pause button is pressed
    public void OnPauseButtonClick()
    {
        if (audioSource != null)
        {            
            audioSource.Pause();
        }
    }

    private void Start()
    {        
        audioSource = GetComponent<AudioSource>();
    }
}

