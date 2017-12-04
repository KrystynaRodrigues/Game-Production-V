using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFire : MonoBehaviour {


    public GameObject fire;
    float startFire = 2.0f;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        startFire -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F)) //start fire when f is pushed
        {
            if(startFire <= 0f)
            {
                setFire();
            }
            
            
        }
        
	}

    void setFire()
    {
            GameObject spawnFire = Instantiate(fire, transform.position, transform.rotation) as GameObject; //spawns fire prefab
            spawnFire.GetComponent<Rigidbody>().velocity = transform.forward * 10;
    }
}   
