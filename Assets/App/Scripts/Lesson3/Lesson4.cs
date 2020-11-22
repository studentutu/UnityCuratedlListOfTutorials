using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
    private float floatSave;
    // Start is called before the first frame update
    void Start()
    {

    
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("clamptest " + floatSave);
        floatSave = Mathf.Clamp(Input.mousePosition.x, -10f, 10f);
        Debug.Log("Unclamptest " + Input.mousePosition.x);
        
        //Homework   Bound - clampPositions values   Same 
        
    }
    
    
}