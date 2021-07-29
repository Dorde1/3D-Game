using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;

    public GameObject optionsScreen, continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            if (PlayerPrefs.GetString("CurrentLevel") == "")
            {
                continueButton.SetActive(false);
            }
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));
    }

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);

        PlayerPrefs.SetString("CurrentLevel", "");

        PlayerPrefs.SetString(firstLevel + "_cp", "");
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
