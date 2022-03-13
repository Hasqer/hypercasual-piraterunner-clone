using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelCollider : MonoBehaviour
{

    public GameObject Player;
    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Follower")
        {
            Debug.Log("50 Altýn");
            Destroy(other.gameObject);
           
        }
        if (other.tag =="Player")
        {
            Player.GetComponent<Controller>().followerCount = 0;
        }
        Destroy(transform.parent.gameObject, 2);

    }

}
