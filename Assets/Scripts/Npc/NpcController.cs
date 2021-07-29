using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NpcController : MonoBehaviour
{

    private bool chasing;
    public float distanceToChase = 10f, distanceToLose = 15f, distanceToStop = 2f;

    private Vector3 targetPoint, startPoint;

    public NavMeshAgent agent;

    public float keepChasingTime = 5f;
    private float cooldown = 1f, cooldown2 = 1f;
    private float chaseCounter, chaseCounter2;

    public Animator anim;

    private bool following = false;

    public Image bg;
    public Text interact;

    public GameObject showGUI;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        showGUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = PlayerController.instance.transform.position;
        targetPoint.y = transform.position.y;


        if (!chasing)
        {
            HideInteract();
            if (Vector3.Distance(transform.position, targetPoint) < distanceToChase)
            {
                ShowInteract();
            }
            anim.SetBool("isMoving", false);
            if (Vector3.Distance(transform.position, targetPoint) < distanceToChase && (Input.GetKey(KeyCode.E) == true))
            {
                chasing = true;
                HideInteract();
            }
        }
        else
        {
            cooldown2 -= Time.deltaTime;
            HideInteract();
            if (Vector3.Distance(transform.position, targetPoint) < distanceToChase)
            {
                ShowStopInteract();
            }
            if (Input.GetKey(KeyCode.E) == true && cooldown2 <=0 && following == false && Vector3.Distance(transform.position, targetPoint) < distanceToChase)
            {
                following = true;
                cooldown = 1f;
                Debug.Log("Go 2");

            }

            if (following == true)
            {
                cooldown -= Time.deltaTime;
                HideInteract();
                if (Vector3.Distance(transform.position, targetPoint) < distanceToChase)
                {
                    ShowInteract();
                }
                if (cooldown <= 0 && Input.GetKey(KeyCode.E) == true && Vector3.Distance(transform.position, targetPoint) < distanceToChase)
                {
                    following = false;
                    HideInteract();
                    cooldown2 = 1f;
                    Debug.Log("STOP 1");
                }
            }


            if (Vector3.Distance(transform.position, targetPoint) > distanceToStop && following == false)
            {
                agent.destination = targetPoint;
                anim.SetBool("isMoving", true);
                if (agent.remainingDistance < .25f)
                {
                    anim.SetBool("isMoving", false);
                }
                else
                {
                    anim.SetBool("isMoving", true);
                }
            }
            else
            {
                agent.destination = transform.position;
                anim.SetBool("isMoving", true);
                if (agent.remainingDistance < .25f)
                {
                    anim.SetBool("isMoving", false);
                }
                else
                {
                    anim.SetBool("isMoving", true);
                }
            }
        }
    }

    public void ShowInteract()
    {
        bg.enabled = true;
        interact.text = "[E] to Follow";
        interact.enabled = true;
    }

    public void HideInteract()
    {
        interact.enabled = false;
        bg.enabled = false;
    }

    public void ShowStopInteract()
    {
        bg.enabled = true;
        interact.text = "[E] to Stop";
        interact.enabled = true;
    }

    public void GetShot()
    {
        chasing = true;

        agent.destination = PlayerController.instance.transform.position;
    }
}

