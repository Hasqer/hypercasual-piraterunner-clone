using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Image levelBar_fill;
    public TextMeshProUGUI currentLevel;
    public TextMeshProUGUI nextLevel;
    private int level = 1;
    public GameObject player;
    float temp = 0;

    void Update()
    {
        try
        {
            var result = Mathf.Lerp(0f, 1f, Mathf.InverseLerp(0, 999, player.transform.position.z % 1000));

            if (result < temp)
            {
                level++;
                levelBar_fill.GetComponentInParent<Animation>().Play("NewLevel_LevelBar");
            }


            temp = result;
            levelBar_fill.fillAmount = result;

            currentLevel.text = level.ToString();
            nextLevel.text = (level + 1).ToString();
        }
        catch (System.Exception)
        {

         
        }
          
     
    }
}
