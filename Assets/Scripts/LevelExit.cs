using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string nextLevel;
    public GameObject arrow;
    public float waitToEndLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Intro" || SceneManager.GetActiveScene().name == "BossLevel" || SceneManager.GetActiveScene().name == "Outro")
        {
            
        }
        else
        {
            if (DropOffController.instance.saved == DropOffController.instance.savetotal)
            {
                arrow.SetActive(true);
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.levelEnding = true;

            StartCoroutine(EndLevelCo());

            AudioManager1.instance.PlayLevelVictory();
        }
    }

    private IEnumerator EndLevelCo()
    {
        PlayerPrefs.SetString(nextLevel + "_cp", "");
        PlayerPrefs.SetString("CurrentLevel", nextLevel);

        yield return new WaitForSeconds(waitToEndLevel);

        SceneManager.LoadScene(nextLevel);
    }

}
