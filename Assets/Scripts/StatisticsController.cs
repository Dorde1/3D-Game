using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatisticsController : MonoBehaviour
{

    public string mainMenuScene;
    public string[] nextLevel;

    public GameObject stats, savedPeople;

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

        if (GlobalVariables.PreviousLevel == "Level2")
        {
            counter = 0;
        }

        if (GlobalVariables.PreviousLevel == "Level4")
        {
            counter = 1;
        }

        if (GlobalVariables.PreviousLevel == "Level6")
        {
            counter = 2;
        }

        if (GlobalVariables.PreviousLevel == "BossLevel")
        {
            counter = 3;
            savedPeople.SetActive(false);
        }

        Debug.Log("HERE");
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnDestroy()
    {
        updateTotal();
        clearValues();

    }

    public void updateText()
    {
        killText.text = "KILLS: " + GlobalVariables.kills;
        deathText.text = "DEATHS: " + GlobalVariables.deaths;
        dmgTakenText.text = "DAMAGE TAKEN: " + GlobalVariables.dmgTakenText + "dps";
        dmgDealtText.text = "DAMAGE DEALT: " + GlobalVariables.dmgDealtText + "dps";
        peopleText.text = "PEOPLE SAVED: " + GlobalVariables.peopleText + "/" + GlobalVariables.peopleTotal; //Change thu
    }

    public void NextLevel()
    {
        //if(counter < nextLevel.Length)
        //{
        //    counter += 1;
        //    SceneManager.LoadScene(nextLevel[counter]);
        //    Debug.Log("Added 1 " + nextLevel[counter]);
        //}
        //else
        //{
        //    SceneManager.LoadScene(nextLevel[counter]);
        //    Debug.Log("Added 1 " + nextLevel[counter]);
        //}
        Debug.Log(SceneManager.GetActiveScene().name);


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
        GlobalVariables.kills = 0;
        GlobalVariables.deaths = 0;
        GlobalVariables.dmgTakenText = 0;
        GlobalVariables.dmgDealtText = 0;
        GlobalVariables.peopleText = 0;
        GlobalVariables.peopleTotal = 0;
    }

    public void updateTotal()
    {

        GlobalVariables.totalKills += GlobalVariables.kills;
        GlobalVariables.totalDeaths += GlobalVariables.deaths;
        GlobalVariables.totaldmgTakenText += GlobalVariables.dmgTakenText;
        GlobalVariables.totaldmgDealtText += GlobalVariables.dmgDealtText;
        GlobalVariables.totalpeopleText += GlobalVariables.peopleText;
        GlobalVariables.totalpeopleTotal += GlobalVariables.peopleTotal;
    }

}
