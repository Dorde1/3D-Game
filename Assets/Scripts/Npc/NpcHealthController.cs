using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcHealthController : MonoBehaviour
{
    public int currentHealth = 5;

    public NpcHealthController theNPC;

    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageNPC(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            AudioManager1.instance.PlaySFX(2);
            counter++;
            if (counter == 1)
            {
                DropOffController.instance.savetotal-=1;
                UIController.instance.Counter.text = "Saved: " + DropOffController.instance.saved + "/" + DropOffController.instance.savetotal;
            }
        }
    }
}
