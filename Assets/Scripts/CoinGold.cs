using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGold : MonoBehaviour
{

    private GameObject Player;

    void Start()
    {
      
            Player = GameObject.Find("Player");
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
             Player.GetComponent<Controller>().Score += 1;
             Destroy(this.gameObject);
        }
        catch (System.Exception)
        {

          
        }
       
        
     
    }
}
