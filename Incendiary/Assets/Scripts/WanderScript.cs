using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderScript : MonoBehaviour
{
    public GameObject Player = null;//player ref
    public GameObject Enemy;//gameobject Ref
    public Transform[] wayPoints;//waypoint array, dydnamic size based 
    public bool DrawFOV = false;
    public float rayOffset;
    public float rayDistance;

    public int currentWaypoints;//sets waypoint target
    public int speed;//set speed 

    void FixedUpdate()
    {
        if (DrawFOV) { drawFOV(); }//debug of FOV
        Wander();
    }
    void drawFOV()
    {
        Debug.DrawRay(Enemy.transform.position, Quaternion.AngleAxis(rayOffset, Enemy.transform.forward) * Enemy.transform.right, Color.red, rayDistance, false);//left offset debug
        Debug.DrawRay(Enemy.transform.position, Quaternion.AngleAxis(-rayOffset, Enemy.transform.forward) * Enemy.transform.right, Color.red, rayDistance, false);//right offset debug
        Debug.DrawRay(Enemy.transform.position, Enemy.transform.right, Color.blue, rayDistance, false);//true direction ray debug
    }
    void Wander()
    {
        Debug.Log("Wandering");
        if (currentWaypoints < wayPoints.Length)//checks progress of patrol
        {

            Enemy.transform.LookAt(wayPoints[currentWaypoints].position);  //sets direction to waypoint
            Enemy.transform.Rotate(new Vector3(0, -90, 0), Space.Self);    //sets rotation of game object to waypoint 
            if (Vector3.Distance(Enemy.transform.position, wayPoints[currentWaypoints].position) > 1f) //move if distance from target is greater than 1
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, speed * Time.deltaTime));  // sets transform speed
            }
            else if (Vector3.Distance(Enemy.transform.position, wayPoints[currentWaypoints].position) <= 1f) // if way point is within a distence of 1
            {
                currentWaypoints++; //change to next way point Transform
            }
        }
        else
        {
            Debug.Log("waypoint");

            currentWaypoints = 0; //patrol reset 

        }

    }
}