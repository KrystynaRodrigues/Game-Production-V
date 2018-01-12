using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFire : MonoBehaviour {


    public GameObject fire;
    public float startFire;
    public int timer;
    public Transform target;

    public bool isFireSet;

    void Start()
    {
        isFireSet = false;
    }

	void Update ()
    {

        startFire += Time.deltaTime;

	}


    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Flammable")
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                setFire();
            }
                
            
        }
    }

    void setFire()
    {
        if (startFire > timer)
        {
            GameObject spawnFire = Instantiate(fire, target.position, target.rotation) as GameObject; //spawns fire prefab
            spawnFire.GetComponent<Rigidbody>().velocity = transform.forward * 10;
            timer = timer + 25;

        }
        
        startFire = startFire + 10;
        isFireSet = true;

    }
}   
