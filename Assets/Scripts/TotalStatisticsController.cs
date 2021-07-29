using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TotalStatisticsController : MonoBehaviour
{

    public string mainMenuScene;
    public string[] nextLevel;

    public GameObject stats;

    public Text killText;
    public Text deathText;
    public Text dmgTakenText;
    public Text dmgDealtText;
    public Text peopleText;

    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        updateText();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        clearValues();
    }

    public void updateText()
    {
        killText.text = "TOTAL KILLS: " + GlobalVariables.totalKills;
        deathText.text = "TOTAL DEATHS: " + GlobalVariables.totalDeaths;
        dmgTakenText.text = "TOTAL DAMAGE TAKEN: " + GlobalVariables.totaldmgTakenText + "dps";
        dmgDealtText.text = "TOTAL DAMAGE DEALT: " + GlobalVariables.totaldmgDealtText + "dps";
        peopleText.text = "TOTAL PEOPLE SAVED: " + GlobalVariables.totalpeopleText + "/" + GlobalVariables.totalpeopleTotal; //Change thu
    }

    public void NextLevel()
    {

        SceneManager.LoadScene(nextLevel[counter]);

        PlayerPrefs.SetString("CurrentLevel", "");
        PlayerPrefs.SetString(nextLevel + "_cp", "");

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void clearValues()
    {
        GlobalVariables.totalKills = 0;
        GlobalVariables.totalDeaths = 0;
        GlobalVariables.totaldmgTakenText = 0;
        GlobalVariables.totaldmgDealtText = 0;
        GlobalVariables.totalpeopleText = 0;
        GlobalVariables.totalpeopleTotal = 0;
    }
}
