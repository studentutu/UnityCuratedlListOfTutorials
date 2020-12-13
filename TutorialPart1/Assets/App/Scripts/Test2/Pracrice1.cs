using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pracrice1 : MonoBehaviour
{
    
    public float LiterationNumber = 10;
    public Vector3 Position5 =new Vector3(5,5,5 );
    private void Awake()
    {
        float BestMaxreturn = Mathf.Max(18,7,1 );
        Debug.Log(BestMaxreturn);
        float maxValaible=MaxVar(18, 7, 1);
        Debug.Log(maxValaible);
        StartCoroutine(CorMetod());
        // StartCoroutine( (IEnumerator)null);
    }

   // private void Update()
    //{
       // transform.position = Position5+new Vector3(0,1,0 );
       // transform.rotation = transform.rotation * Quaternion.Euler(Vector3.one * LiterationNumber);
    //}
    private IEnumerator CorMetod()
    {
        yield return null;
        transform.rotation= Quaternion.Euler(Vector3.one*LiterationNumber);
        transform.position = Position5;
        float second = 5f;
        while (second>0)
        {
            transform.rotation= transform.rotation * Quaternion.Euler(Vector3.one*LiterationNumber);
            transform.position = Position5;
            second = second - Time.deltaTime; // від 5 теперишніх 5 сек відняли поередній фрейм 
            yield return null ;
        } 
    }

    private float MaxVar(float x,float y, float z)
    {
        float returnVaiable;
        if (x>y)
        {
            returnVaiable = x;
        }
        else
        {
            returnVaiable = y;
        }
        
        if (returnVaiable>z)
        {
            returnVaiable = returnVaiable;
        }
        else
        {
            returnVaiable = z;
        }

        return returnVaiable;
        
    }

    private float BestMax(float x, float y, float z)
    {
        return Mathf.Max(x, y, z);;
    }
}


