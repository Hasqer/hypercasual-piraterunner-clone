using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockCollider : MonoBehaviour
{
    public GameObject smokeEffect;
    public GameObject Failed;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag=="Player")
        {
            var rotationVector = other.transform.rotation.eulerAngles;
            rotationVector.y = -270;
            Instantiate(smokeEffect, other.transform.position, Quaternion.Euler(rotationVector));
            Destroy(other.gameObject);
            Destroy(GameObject.Find("LevelControl"));
            Destroy(GameObject.Find("Camera").GetComponent<Camera>());

            Instantiate(Failed);
        }
        else if (other.tag == "Follower")
        {
            var rotationVector = other.transform.rotation.eulerAngles;
            rotationVector.y = -270;
            Instantiate(smokeEffect, other.transform.position, Quaternion.Euler(rotationVector));
            Destroy(other.gameObject);

        }
     

    }

    
}
