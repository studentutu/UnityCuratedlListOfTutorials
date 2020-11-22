using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector3 = System.Numerics.Vector3;

public class BoundObject : MonoBehaviour
{
    public Vector2 diraction;
    public float axeleration;
    public Rigidbody rb;
    [SerializeField] private Transform[] aarays;
    [SerializeField] private List<Transform> list;
    //[SerializeField] private List<GameObject> _list;

        [SerializeField]
    private GameObject ObjectToMove;

    private void Start()
    {
        StartCoroutine(MoveToWaitPoint());
        
    }

    private IEnumerator MoveToWaitPoint()
    {
        
        for (int i = 0; i < list.Count; i++)
        {
           
            var Target = list[i]; 
            yield return null;
            while ((Target.position - ObjectToMove.transform.position).magnitude> 0.05f)
            {
                ObjectToMove.transform.MoveToPosition(Target);
                yield return null;
            }
        }
    }

    private void FixedUpdate()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //
        //     rb.AddForce(diraction.normalized, ForceMode.Impulse);
        // }
    }
}

