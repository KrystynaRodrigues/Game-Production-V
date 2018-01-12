using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{

    public GameObject Player;
    public GameObject Enemy;
    public Transform playerTransform;
    public bool playerDetected; 
    public bool followPlayer; 
    public Transform[] wayPoints; //waypoint array
    public int currentWaypoints;
    public float speed;
    public bool enemyWander;
    public string LevelName;
    public float Timer;
    public float doneTimer = 2f;



    void Update()
    {
       float move= speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
      Wander();
    }

    void Wander()
    {
        if (currentWaypoints < wayPoints.Length)//checks progress of patrol
        {
            Debug.Log("Wander");
            Enemy.transform.LookAt(wayPoints[currentWaypoints].position);  //sets direction to waypoint 
            if (Vector3.Distance(Enemy.transform.position, wayPoints[currentWaypoints].position) > 1f) //move if distance from target is greater than 1
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, speed * Time.deltaTime));  // sets transform speed
            }
            else if (Vector3.Distance(Enemy.transform.position, wayPoints[currentWaypoints].position) <= 1f) // if way point is within a distence of 1
            {
                currentWaypoints++; //change to next way point Transform
            }
        }
        else if (currentWaypoints >= wayPoints.Length)
        {
            Debug.Log("waypoint");

            currentWaypoints = 0; //patrol reset if (currentWaypoints<wayPoints.Length)//checks progress of patrol
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
       
        }
    }

   void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player)
        {
            Debug.Log("PlayerCheck");
            this.transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, 1);


            GameOver();
        }
    }



    void GameOver()
    {
        Timer = Timer + Time.deltaTime;

        if(Timer >= doneTimer)
        {
            LoadScene(LevelName);
        }
           
        
    }

    public void LoadScene(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }

}
