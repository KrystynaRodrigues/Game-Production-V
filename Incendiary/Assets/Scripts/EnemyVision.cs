using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float fieldOfViewAngle = 360f;
    public bool playerInSight;
    public Vector3 LastSighting;


    private NavMeshAgent nav;
    private SphereCollider col;
    public GameObject player;
    public GameObject eyes;
    private Vector3 previousSighting;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInSight = true;


            Vector3 direction = player.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle < fieldOfViewAngle * 0.5f)
            {
                Debug.Log("Angle");
                RaycastHit hit;
                if (Physics.Raycast(eyes.transform.position, direction.normalized, out hit, col.radius))
                {
                    if (hit.collider.tag == "Player")
                    {
                        Debug.Log("I see you.");
                    }
                }
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInSight = false;
        }
    }
}
