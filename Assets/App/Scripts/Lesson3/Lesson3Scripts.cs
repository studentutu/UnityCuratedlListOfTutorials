using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class TransformExtantionals
{
    public static void  MoveToPosition(this Transform transform, Transform ToTarget)
    {
        Vector3 result = Vector3.Lerp(transform.position, ToTarget.transform.position,
            Time.deltaTime * 2f); //run Time

        transform.position = result;

    }
}

public class Lesson3Scripts : MonoBehaviour
{
    public Animator AnimatorController;
    public GameObject ObjectToMove;
    public GameObject ToTarget;
    public float second; 
    private void Awake()
    {
        Input.GetAxis("Horizontal");
        
        // StartCoroutine(ProcedurallAnimatiom());

    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {

       Debug.Log("collides world "+ other.gameObject.name);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger world "+ other.gameObject.name);
    }

    private IEnumerator ProcedurallAnimatiom()
    {

        // 1. Object toMove 2. Target Object 3. Lerp - Interpolation 

        
        yield return null;
        // 4. Time to animate 5. create Loop 6. inside Loop always wait for frame 7. Conditiouns while time >0;
        float CecondInLoop = second;
        while (CecondInLoop>0)
        {
            CecondInLoop -= Time.deltaTime;
        ObjectToMove.transform.position = Vector3.Lerp(ObjectToMove.transform.position, ToTarget.transform.position, Time.deltaTime*0.1f);
            yield return null;
        }
        
        
    }

    
    private void Update()
    {
        var TemAxes= Input.GetAxis("Horizontal");
        //procedurelFromUpdate();
        //procedurelFromUpdateV3();
        procedurelFromUpdateV4();
        Debug.Log(" Horizontal  is " +TemAxes);

    }

    private void procedurelFromUpdate()
    {


        // 4. Time to animate 5. create Loop 6. inside Loop always wait for frame 7. Conditiouns while time >0;
        if (second > 0)
        {
        
        
        second -= Time.deltaTime;
        ObjectToMove.transform.position = Vector3.Lerp(ObjectToMove.transform.position, ToTarget.transform.position,
            Time.deltaTime * 0.1f); //Fix from rield value

        }
    }

    private void procedurelFromUpdateV3()
    {
        ObjectToMove.transform.position = Vector3.Lerp(ObjectToMove.transform.position, ToTarget.transform.position,
            Time.deltaTime * 0.5f); //run Time
    }

    private void procedurelFromUpdateV4()
    {
        //Vector3 dicactions = ToTarget.transform.position - ObjectToMove.transform.position;  Find directions
       
        if (ToTarget == null) //PREconditions contract
        {
            return;
        }

        if (ObjectToMove == null)
        {
            return;
        }

        ObjectToMove.transform.MoveToPosition(ToTarget.transform); 

    }

}
