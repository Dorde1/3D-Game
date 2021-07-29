using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Slider healthSlider;
    public Text healthText, ammoText, Counter;

    public Image damageEffect;
    public float damageAlpha = .25f, damageFadeSpeed = 2f;

    public GameObject pauseScreen;
    public GameObject OptionsScreen;

    public Image blackScreen;
    public float fadeSpeed = 1.5f;

    public Image bgInteract;
    public Text interact;

    public GameObject NpcGUI;
    public GameObject saveGUI;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        bgInteract.enabled = false;
        interact.enabled = false;

        if(SceneManager.GetActiveScene().name == "Intro" || SceneManager.GetActiveScene().name == "BossLevel" || SceneManager.GetActiveScene().name == "Outro")
        {
            saveGUI.SetActive(false);
        }
        else
        {
            saveGUI.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (damageEffect.color.a != 0)
        {
            damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, Mathf.MoveTowards(damageEffect.color.a, 0f, damageFadeSpeed * Time.deltaTime));
        }

        if (!GameManager.instance.levelEnding)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
        }
        else
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
        }
    }

    public void ShowDamage()
    {
        damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, .25f);
    }


    public void ShowInteract()
    {
        UIController.instance.bgInteract.enabled = true;
        UIController.instance.interact.text = "[E] to Follow";
        UIController.instance.interact.enabled = true;

    }

    public void HideInteract()
    {
        UIController.instance.bgInteract.enabled = false;
        UIController.instance.interact.enabled = false;
    }

    public void ShowStopInteract()
    {
        UIController.instance.bgInteract.enabled = true;
        UIController.instance.interact.text = "[E] to Stop";
        UIController.instance.interact.enabled = true;

    }

}
