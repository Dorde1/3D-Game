using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesController : MonoBehaviour
{
    public static WavesController instance;
    [HideInInspector]public int counter;

    public GameObject wave2, wave3, boss;
    private bool bossSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter >= 8)
        {
            wave2.SetActive(true);
        }
        
        if(counter >= 16)
        {
            wave3.SetActive(true);
        }

        if(counter >= 24 && bossSpawned == false)
        {
            boss.SetActive(true);
            bossSpawned = true;
        }

        if(counter >= 33)
        {
            SceneManager.LoadScene("StatisticScene");
        }
    }
}
