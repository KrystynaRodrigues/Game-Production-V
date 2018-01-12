using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDetectorLight : MonoBehaviour
{

    public Light objectLight;
    // Use this for initialization
    void Start()
    {
        objectLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Disable>().isDetectorOff)
        {
            objectLight.color = Color.green;
        }

    }
}
