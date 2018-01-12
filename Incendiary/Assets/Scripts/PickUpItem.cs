using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public bool itemPickedUp;
    public GameObject QuestItem;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    	
	}

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "QuestItem")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                itemPickedUp = true;
                Debug.Log("Item Picked UP");
                other.gameObject.SetActive(false);
            }


        }
    }
}
