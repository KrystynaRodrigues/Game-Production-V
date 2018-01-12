using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField] string LevelName;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (GameObject.Find("Player").GetComponent<PickUpItem>().itemPickedUp && GameObject.Find("Player").GetComponent<SetFire>().isFireSet)
                {
                    Debug.Log("End Level");
                    LoadScene(LevelName);
                }
            }
        }
        

    }
     
    public void LoadScene(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }

}
