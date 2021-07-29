using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string theGun;

    private bool isCollected;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isCollected)
        {
            PlayerController.instance.AddGun(theGun);

            Destroy(gameObject);

            isCollected = true;

            AudioManager1.instance.PlaySFX(4);
        }
    }
}
