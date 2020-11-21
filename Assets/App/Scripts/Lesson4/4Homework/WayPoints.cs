using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

[RequireComponent(typeof(Rigidbody))]
public class WayPoints : MonoBehaviour
{
    // 1. Points 2. Cube bitween points 3. Check if near target 4. Reaped step ->2
    [SerializeField] private Transform[] aarays;
    [SerializeField] private List<Transform> list;

    // public Rigidbody rb;
    // public int clickForce = 500;
   
    float rotation = 80;
    [SerializeField] private GameObject ObjectToMove;


    private void Start()
    {
        StartCoroutine(MoveToWaitPoint());

    }



    // private void OnCollisionEnter(Collision other)
    // {
    //     var Target = list;
    //     if (ObjectToMove.gameObject.name ==  ;
    //     Debug.Log("collissians " + ObjectToMove.gameObject.name);
    // }



    private IEnumerator MoveToWaitPoint()
    {
        for (int i = 0; i < list.Count; i++)
        {

            var Target = list[i];
            yield return null;
            while ((Target.position - ObjectToMove.transform.position).magnitude > 0.05f)
            {
                ObjectToMove.transform.MoveToPosition(Target);
                yield return null;

                // if ((Target.position = ObjectToMove.transform.position).sqrMagnitude > 0.05f) ;
                // }
                //
                // ObjectToMove.transform.MoveToPosition(Target);
                // }
            }
        }
    }


    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        
            ObjectToMove.transform.position+= ObjectToMove.transform.position + new UnityEngine.Vector3(0, 3f,0);
            
            // while (rotation >= 0) {
                // rotation = rotation + Time.deltaTime;   
            // }
           
            
                
        }
        

        // var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // var mouseDir = mousePos - gameObject.transform.position;
        // mouseDir.z = 0.0f;
        // mouseDir = mouseDir.normalized;
        //
        // if (Input.GetMouseButtonDown(0))
        // {
        //     rb.AddForce(mouseDir * clickForce);
        // }
    }
}



