using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float waitAfterDying = 1f;

    [HideInInspector]
    public bool levelEnding;

    private bool questOpen = false, menuOpen = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PlayerDied()
    {
        StartCoroutine(PlayerDiedCo());

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator PlayerDiedCo()
    {
        yield return new WaitForSeconds(waitAfterDying);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseUnpause()
    {

        if (UIController.instance.pauseScreen.activeInHierarchy && !UIController.instance.OptionsScreen.activeInHierarchy)
        {

            UIController.instance.pauseScreen.SetActive(false);

            menuOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Time.timeScale = 1f;

            PlayerController.instance.footstepFast.Play();
            PlayerController.instance.footstepSlow.Play();


            if (questOpen && menuOpen == false)
            {

                UIController.instance.NpcGUI.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0f;

                PlayerController.instance.footstepFast.Stop();
                PlayerController.instance.footstepSlow.Stop();
                questOpen = false;
            }
            
        }
        else
        {
            if (UIController.instance.NpcGUI.activeInHierarchy)
            {

                UIController.instance.NpcGUI.SetActive(false);
                questOpen = true;
            }


            UIController.instance.pauseScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;

            PlayerController.instance.footstepFast.Stop();
            PlayerController.instance.footstepSlow.Stop();

            menuOpen = true;
        }
    }

    public void PauseQuest()
    {
        if (UIController.instance.NpcGUI.activeInHierarchy)
        {
            UIController.instance.NpcGUI.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Time.timeScale = 1f;

            PlayerController.instance.footstepFast.Play();
            PlayerController.instance.footstepSlow.Play();
        }
        else
        {
            UIController.instance.NpcGUI.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;

            PlayerController.instance.footstepFast.Stop();
            PlayerController.instance.footstepSlow.Stop();
        }
    }
}