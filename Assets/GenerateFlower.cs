using UnityEngine;
using System.Collections;
 
public class RandomInstantiate : MonoBehaviour 
{
    
     public GameObject[] yourArray;
 
 void Update()
     {
         if (Input.GetMouseButtonDown(0))
         {
             Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
 
             int index = Random.Range(0, yourArray.Length);
    
             Instantiate(yourArray[index], spawnPosition, Quaternion.identity);
         }
     }
 }