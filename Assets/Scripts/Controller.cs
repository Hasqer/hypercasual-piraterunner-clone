using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float autoSpeed = 80;
    public float horizontalSpeed = 80;
    public float floorLeftLimit = -26;
    public float floorRightLimit = 26;
    public GameObject player;
    private GameObject[] tunnels;
    public float rotationSpeed = 90;
    public float Score;
    public float followerCount = 0;
    public Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.1f;

    public float rotatespeed = 10f;
    private float _startingPosition;

    private float X = 0;
    private float Y = 0;
    public float speed = 0.1f;
    public float tunnelSpeed = 10f;
    public GameObject tunnel;
    public float verticalSpeed = 0;
    void Start()
    {
        tunnels = GameObject.FindGameObjectsWithTag("Tunnel");
    }

  

    void Update()
    {
        verticalSpeed = Screen.height / 8;
         tunnels = GameObject.FindGameObjectsWithTag("Tunnel");
        //Forward
         player.transform.Translate(Vector3.forward * autoSpeed * Time.deltaTime);

        //Left and Right
        //if ((Input.GetKey(KeyCode.A) || Input.GetAxis("Mouse X") < 0) && player.transform.position.x > floorLeftLimit)
        //    player.transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
        //if ((Input.GetKey(KeyCode.D) || Input.GetAxis("Mouse X") > 0) && player.transform.position.x < floorRightLimit)
        //     player.transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);

        /*
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startingPosition = touch.position.y;
                    break;
                case TouchPhase.Moved:
                    if (_startingPosition > touch.position.y)
                    {
                        transform.Rotate(Vector3.back, rotatespeed * Time.deltaTime);
                    }
                    else if (_startingPosition < touch.position.y)
                    {
                        transform.Rotate(Vector3.back, rotatespeed * Time.deltaTime);
                    }
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Touch Phase Ended.");
                    break;
            }
        }*/


        //*********************************************************
        //Left and Right

        if (Input.GetMouseButtonDown(0))
        {
            X = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
            float x2 = X - Input.mousePosition.x;
            transform.position = new Vector3(transform.position.x - (x2 * speed * Time.deltaTime),transform.position.y,transform.position.z);
        }
        if (transform.position.x > 26f)
        {
            transform.position = new Vector3(26f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -26f)
        {
            transform.position = new Vector3(-26f, transform.position.y, transform.position.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Y = Input.mousePosition.y;
        }
        if (Input.GetMouseButton(0))
        {
            if(Y-verticalSpeed > Input.mousePosition.y)
            {
                foreach (var tunnel in tunnels)
                {
                    var rotationVector = tunnel.transform.rotation.eulerAngles;
                    rotationVector.z += rotationSpeed * Time.deltaTime;
                    tunnel.transform.rotation = Quaternion.Euler(rotationVector);
                }
            }
            else if(Y+ verticalSpeed < Input.mousePosition.y)
            { 
                foreach (var tunnel in tunnels)
                {
                    var rotationVector = tunnel.transform.rotation.eulerAngles;
                    rotationVector.z -= rotationSpeed * Time.deltaTime;
                    tunnel.transform.rotation = Quaternion.Euler(rotationVector);
                }
            }
            
        }
        //*********************************************
        //Turn Right and Left



/*
        if (Input.GetMouseButtonDown(0) == true)
        {
            Y = Input.mousePosition.y;
        }
        if (Input.GetMouseButton(0) == true)
        {
            float y2 = Y - Input.mousePosition.y;
            foreach (var tunnel in tunnels)
            {
                tunnel.transform.rotation = new Quaternion(tunnel.transform.rotation.x, tunnel.transform.rotation.y, tunnel.transform.rotation.z + (y2 * tunnelSpeed * Time.deltaTime),1);
            }
        }
*/



        //Turn Right and Left
        if (Input.GetKey(KeyCode.W))
        {
            foreach (var tunnel in tunnels)
            {
                var rotationVector = tunnel.transform.rotation.eulerAngles;
                rotationVector.z += rotationSpeed * Time.deltaTime;
                tunnel.transform.rotation = Quaternion.Euler(rotationVector);
            }
   
        }

        if (Input.GetKey(KeyCode.S))
        {
            foreach (var tunnel in tunnels)
            {
                var rotationVector = tunnel.transform.rotation.eulerAngles;
                rotationVector.z -= rotationSpeed * Time.deltaTime;
                tunnel.transform.rotation = Quaternion.Euler(rotationVector);
            }


        }


    

    }

   

}
