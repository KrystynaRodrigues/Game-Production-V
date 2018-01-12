using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawnTimer : MonoBehaviour
{
    public GameObject SpawnedFire;
    public GameObject fire;
    public Transform[] fireSpawnWaypoints;
    public int currentWaypoint;

    public float startTime = 0f;
    public float waitTime = 10.0f;

    
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GameObject.Find("Player").GetComponent<SetFire>().isFireSet)
        {
            startTime = startTime + 0.01f;
            SpawnFire();
        }

    }

    void SpawnFire()
    {
        if (startTime >= waitTime)
        {
            Debug.Log("Spawn");
            int spawnPointIndex = Random.Range(0, fireSpawnWaypoints.Length);
            GameObject SpawnedFire = Instantiate(fire, fireSpawnWaypoints [spawnPointIndex].position, fireSpawnWaypoints[spawnPointIndex].rotation) as GameObject;
            
            waitTime = waitTime + 12;
            startTime = startTime + 10.0f;
        }

        return;    
    }
}
