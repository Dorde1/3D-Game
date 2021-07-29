using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private bool isCollected;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isCollected)
        {
            PlayerController.instance.activeGun.GetAmmo();

            Destroy(gameObject);

            isCollected = true;

            AudioManager1.instance.PlaySFX(3);
        }
    }
}
