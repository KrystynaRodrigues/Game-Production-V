using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Disable : MonoBehaviour
{
    public float startTime = 0f;
    public float holdTime = 0.5f;
    public bool isSprinklerOff;
    public bool isDetectorOff;
    public int totalObjects;
    public int disabledObjects;

    [SerializeField] string LevelName;

    void Start()
    {
        isSprinklerOff = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (disabledObjects < totalObjects)
        {
            if (GameObject.Find("Player").GetComponent<SetFire>().isFireSet)
            {
                LoseCondition();
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Sprinkler")
        {
            if (Input.GetKey(KeyCode.F))
            {
                startTime = startTime + 0.001f;
                    if (startTime >= holdTime )
                    {
                       // Debug.Log(startTime);
                        DisableSprinkler();
                    }
            }
        }

        else if (other.gameObject.tag == "Detector")
        {
            if (Input.GetKey(KeyCode.F))
            {
                startTime = startTime + 0.001f;
       
                if (startTime >= holdTime)
                {
                    DisableDetector();
                }
            }
        }
    }

    void DisableSprinkler()
      {
        isSprinklerOff = true;
        startTime = 0;
        disabledObjects++;
        Debug.Log("Disabled");
        
        if(disabledObjects >= totalObjects)
        {
            WinCondition();
        }
      }

    void DisableDetector()
    {
        isDetectorOff = true;
        startTime = 0;
        disabledObjects++;
        Debug.Log("Disabled");

        if (disabledObjects >= totalObjects)
        {
            WinCondition();

        }
    }

    void LoseCondition()
    {

        Debug.Log("Game Over");
        LoadScene(LevelName);

    }

    void WinCondition()
    {
        Debug.Log("Everything Disabled");
    }

    public void LoadScene(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}
