using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOne : MonoBehaviour
{
    [SerializeField]
    private Vector3 moveToPosition;

    [SerializeField] 
    private bool InstansiateNow = false;
    
    [SerializeField] 
    private Vector3 CloneToPosition;
    // public Vector3 MoveToPosition => moveToPosition; // property;
    [SerializeField]
    private GameObject CobePrefab;
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        
    }

    // Start is called before the first frame update
    private  void Start()
    {
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }


    // Update is called once per frame
    private  void Update()
    {
        Debug.Log("Colled update" + moveToPosition.ToString("F4") );
        MoveToPos(moveToPosition);
        if (InstansiateNow)
        {
            InstansiateNow = false;
            GameObject.Instantiate(CobePrefab, CloneToPosition,Quaternion.identity);
        }

    }

    private void LateUpdate()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void OnDestroy()
    {
        
    }

    public void MoveToPos (Vector3 PisitionToMoveTO)
    {
        transform.position =PisitionToMoveTO;
        
    }

    private float mean(int mean1, int mean2)
    {
        if (mean1>mean2)
        {
            return mean2;
        }

        return mean1;

    }
}
