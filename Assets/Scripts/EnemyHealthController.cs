using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealthController : MonoBehaviour
{
    public int currentHealth = 5;

    public EnemyController theEC;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageEnemy(int damageAmount)
    {
        currentHealth -= damageAmount;
        GlobalVariables.dmgDealtText += damageAmount;

        if (theEC != null)
        {
            theEC.GetShot();
        }

        if (currentHealth <= 0)
        {
            counter++;
            Destroy(gameObject);
            AudioManager1.instance.PlaySFX(2);
            if (counter == 1)
            {
                GlobalVariables.kills += 1;
                if(SceneManager.GetActiveScene().name == "BossLevel")
                {
                    WavesController.instance.counter += 1;
                }
            }
        }
    }
}