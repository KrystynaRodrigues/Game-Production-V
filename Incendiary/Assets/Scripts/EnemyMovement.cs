using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public GameObject Player;
    public GameObject Enemy;
    public bool playerDetected; 
    public float rayDistance;// how far enemy can see player
   

    Ray straight; 
    Ray leftOffset;
    Ray rightOffset;

    RaycastHit hit;
    RaycastHit leftHit;
    RaycastHit rightHit;

    public Color rayColor; //colour to show ray

    public bool followPlayer; 

    private NavMeshAgent mesh;

    public Transform[] wayPoints; //waypoint array

    public int currentWaypoints;

    public int speed;

    public bool enemyWander;

    public bool DrawFOV = false;
    public float rayOffset;

    void Start()
    {
        //Enemy = this.gameObject;//enemy intialization
        Player = GameObject.FindGameObjectWithTag("Player");//player intialization 
         mesh = GetComponent<NavMeshAgent>();
    }
    void Update()
    {

        enemyWander = true;
        straight = new Ray(transform.position, transform.forward * rayDistance);
        leftOffset = new Ray(transform.position, -transform.right * rayDistance);
        rightOffset = new Ray(transform.position, transform.right * rayDistance);

        Debug.Log("sending rays");

        if (DrawFOV) { drawFOV(); }//debug of FOV

        Debug.DrawRay(transform.position, transform.forward * rayDistance, rayColor);
        Debug.DrawRay(transform.position, -transform.right * rayDistance, rayColor);
        Debug.DrawRay(transform.position, transform.right* rayDistance, rayColor);

        Wander();

        if (Physics.Raycast(transform.position, transform.forward * rayDistance) || Physics.Raycast(transform.position, -transform.right * rayDistance) || Physics.Raycast(transform.position, transform.right * rayDistance))
        {
            //if((hit.collider == Player.GetComponent<Collider>()))
            {
                 playerDetected = true;
                  enemyWander = false;
                if(playerDetected == true)
                 {
                    Debug.Log("Detecting Player");
                    enemyWander = false;
                    Follow();
            
                 }
            } 
        }
    
    }


    void Follow()
    {
        Debug.Log("Following");
        mesh.SetDestination(Player.transform.position);
    }

    void Wander()
    {
         Debug.Log("Wandering");
        if (currentWaypoints < wayPoints.Length)//checks progress of patrol
        {
            playerDetected = false;
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

            Update();
        }

    
    }
   void drawFOV()
    {

        Debug.Log("drawing FOV");
        Debug.DrawRay(Enemy.transform.position, Quaternion.AngleAxis(rayOffset, Enemy.transform.forward) * Enemy.transform.right, Color.red, rayDistance, false);//left offset debug
        Debug.DrawRay(Enemy.transform.position, Quaternion.AngleAxis(-rayOffset, Enemy.transform.forward) * Enemy.transform.right, Color.red, rayDistance, false);//right offset debug
        Debug.DrawRay(Enemy.transform.position, Enemy.transform.right, Color.blue, rayDistance, false);//true direction ray debug
    }

    /*
   void detectPlayer()
   {
        if (Physics.Raycast(Enemy.transform.position, Enemy.transform.right, rayDistance, 4))
        {

            Debug.Log("PLAYER Detected!");

           // playerDetected = true;
            Follow();
        }//true direction ray
       // RaycastHit hitL = Physics.Raycast(Enemy.transform.position, Quaternion.AngleAxis(rayOffset, Enemy.transform.forward) * Enemy.transform.right, rayDistance, 1);//right offset 
      //  RaycastHit hitR = Physics.Raycast(Enemy.transform.position, Quaternion.AngleAxis(-rayOffset, Enemy.transform.forward) * Enemy.transform.right, rayDistance, 1);//left offset 


     //  if (hit.collider == Player.GetComponent<Collider>() || hitL.collider == Player.GetComponent<Collider>() || hitR.collider == Player.GetComponent<Collider>())
      // {
        //   playerIsFound = true;
      // }
    
    }

    void Follow()
    {
       // if (playerDetected)
        {
            Debug.Log("follow");

            //Follow//

            Enemy.transform.LookAt(Player.transform.position); //sets direction 
            Enemy.transform.Rotate(new Vector3(0, -90, 0), Space.Self); //sets rotation
            if (Vector3.Distance(Enemy.transform.position, Player.transform.position) > 2f) //move if distance from target is greater than 1
            {
                transform.Translate(new Vector3((speed * 1.5f) * Time.deltaTime, 0, (speed * 1.5f) * Time.deltaTime)); // sets transform speed
            }


            else
            {

                //Enemy Patrol//

                if (currentWaypoints < wayPoints.Length)//checks progress of patrol
                {
                    //playerDetected = false;
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
                    currentWaypoints = 0; //patrol reset 
                }

            }

        }
    }
  */
}
