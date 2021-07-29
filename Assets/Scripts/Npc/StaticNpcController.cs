using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class StaticNpcController : MonoBehaviour
{

    public GameObject DialogGUI, NpcGUI, Arrow;
    public Image background;
    public Text DialogText;

    public Image backgroundQuest;
    public Image backgroundQUest2;
    public Text Name;

    public Text QuestText;
    public GameObject QuestTextobj;


    [TextArea(5,10)]
    public string[] QuestTextedit;


    public GameObject[] buttons = new GameObject[3];

    private bool closedButton = false, open = false, inArea = false;
    private int counter = 0;

    void Start()
    {
        DialogGUI.SetActive(true);
        HideGUI();
        //hideQuest();

    }

    void Update()
    {

        if(Input.GetKey(KeyCode.E) == true && closedButton == false && open ==false && inArea == true)
        {
            open = true;
            HideGUI();
            showQuest();
        }

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            showGUI();
            inArea = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            HideGUI();
            inArea = false;
        } 
    }

    public void showGUI()
    {
        background.enabled = true;
        DialogText.enabled = true;
    }

    public void HideGUI()
    {
        background.enabled = false;
        DialogText.enabled = false;
    }

    public void showQuest()
    {
        counter = 0;
        GameManager.instance.PauseQuest();
        QuestText.text = QuestTextedit[counter];

    }

    public void hideQuest()
    {
        GameManager.instance.PauseQuest();
        open = false;
        showGUI();
        Arrow.SetActive(false);

    }

    public void NextText()
    {
        if (counter < QuestTextedit.Length)
        {
            if(counter == QuestTextedit.Length -1)
            {
                QuestText.text = QuestTextedit[counter];
            }
            else
            {
                counter++;
                QuestText.text = QuestTextedit[counter];
            }

        }

    }

    public void PrevText()
    {
        if (counter > 0)
        {
            counter--;
            QuestText.text = QuestTextedit[counter];

        }

    }

}

