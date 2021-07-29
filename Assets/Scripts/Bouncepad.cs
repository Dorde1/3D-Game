using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncepad : MonoBehaviour
{
    public float bounceForce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.Bounce(bounceForce);

            AudioManager1.instance.PlaySFX(0);
        }
    }
}
