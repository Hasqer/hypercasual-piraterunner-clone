using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class İnfiniteWay : MonoBehaviour
{

    public GameObject[] section;
    public int secNum ;
    private int zPos = 1404;
    private int yPos = 780;
    private int xPos = 686;
    public bool creatingSection = false;
    void Update()
    {
        
        if (creatingSection == false)
        {

            creatingSection = true;
            StartCoroutine(GenerateSection());

        }
        
    }

    IEnumerator GenerateSection() {

        secNum = Random.Range(0,5);
        Instantiate(section[secNum], new Vector3(xPos, yPos, zPos), Quaternion.identity);
       
        yield return new WaitForSeconds(10);
        zPos += 1000;
        creatingSection = false;
      
    }
}
