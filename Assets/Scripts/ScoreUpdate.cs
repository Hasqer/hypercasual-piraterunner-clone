using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreUpdate : MonoBehaviour
{

    private TextMeshProUGUI score;
    private GameObject Player;
    void Start()
    {
       score = this.gameObject.GetComponent<TextMeshProUGUI>();
       Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        try
        {
             float currentScore = Player.GetComponent<Controller>().Score;
             score.text = currentScore.ToString();
        }
        catch (System.Exception)
        {

         
        }
         
        
    }
}
