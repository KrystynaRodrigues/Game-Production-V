using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIgnite : MonoBehaviour
{

    public GameObject fire;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Flammable"))
        {
            Ignite();
        }
    }

    void Ignite()
    {
        
        GameObject spawnFire = Instantiate(fire, transform.position, transform.rotation) as GameObject; //spawns fire prefab
        spawnFire.GetComponent<Rigidbody>().velocity = transform.forward * 10;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
