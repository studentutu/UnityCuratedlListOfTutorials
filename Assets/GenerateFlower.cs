using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class RandomInstantiate : 
    MonoBehaviour 
// Preprocrssor 

// #if CASTOM || ODIN_INSPEKTOR
//    EditorOdin
// #else
//     MonoBehaviour
// #endif
{
    
     public GameObject[] yourArray;
 
 void Update()
     {
         AndroidInput.GetSecondaryTouch(0);
         Debug.Log("Massage");        
         if (Input.GetMouseButtonDown(0))
         {
             Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
 
             int index = Random.Range(0, yourArray.Length);
    
             // Instantiate(yourArray[index], spawnPosition, Quaternion.identity);
         }
     }

 public void Dispose()
 {
 }
}