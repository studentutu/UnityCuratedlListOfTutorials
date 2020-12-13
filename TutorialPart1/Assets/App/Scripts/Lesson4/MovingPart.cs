using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPart : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 0.1f;
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<MovingPart>()!=null)
        {
            return;
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("Destroyed " + gameObject.name);
    }
}
