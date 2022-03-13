using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Follower : MonoBehaviour
{
    private GameObject Player;
    private float f_RotSpeed=150f,f_MoveSpeed = 90f;
    private float FollowerCount =0;
    private bool work = false;
    private float playerDistance = 21;
    private bool oneTime =true;
    private Transform Target;

    void Start () {

        Player = GameObject.Find("Player");   //Player Bilgilerini alýyor
        FollowerCount = Player.GetComponent<Controller>().followerCount; //Follower Sayýsý alýyor
        Target = Player.transform;
    }
 

 void Update () {
       
        playerDistance = ((transform.position - Player.transform.position).z);
        if (work)
        {
            try
            {
                   transform.rotation = Quaternion.Slerp(transform.rotation,
                  Quaternion.LookRotation(new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - playerDistance) - transform.position), f_RotSpeed * Time.deltaTime);

                transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
            }
            catch (Exception) { }
          
       
        }

        else if (playerDistance > -5 && oneTime && playerDistance < 5)
        {
            FollowerCount = Player.GetComponent<Controller>().followerCount; //Follower Sayýsý alýyor
            playerDistance = FollowerCount;
            Player.GetComponent<Controller>().followerCount += 1;

            Target = Player.transform;
            f_MoveSpeed -= playerDistance * 0.85f;

            work = true;
            oneTime = false;
        }
    }
}
