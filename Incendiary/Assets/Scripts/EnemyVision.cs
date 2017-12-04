using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float FOVAngle = 110f;
    public bool inSight = false;
    public Vector3 lastSighting;

    private NavMeshAgent nav;
    private BoxCollider col;
    private Animator anim;
    private LastPlayerSighting lastPlayerSighting;
    private GameObject player;
    private Animator playerAnim;
    private HashId hash;
    private Vector3 previousSighting;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();

    }
}
