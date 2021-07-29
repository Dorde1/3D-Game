using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropOffController : MonoBehaviour
{
    public static DropOffController instance;
    public GameObject arrow;
    public int savetotal;
    [HideInInspector]
    public int saved = 0;

    void Start()
    {
        instance = this;
        UIController.instance.Counter.text = "Saved: " + (saved) + "/" + savetotal;
        GlobalVariables.peopleTotal += savetotal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            UIController.instance.Counter.text = "Saved: " + (saved += 1) + "/" + savetotal;
            GlobalVariables.peopleText += 1;
            Destroy(other.gameObject);
            AudioManager1.instance.PlaySFX(0);
        }

        if(saved == savetotal)
        {
            arrow.SetActive(false);
        }
    }
}
