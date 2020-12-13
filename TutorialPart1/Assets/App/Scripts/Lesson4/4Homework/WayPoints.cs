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

    public Rigidbody rb;

    // public int clickForce = 500;
    private bool CollisianWithTarger = false;
    float rotation = 80;
    [SerializeField] private GameObject ObjectToMove;


    private void Start()
    {
        if (rb == null)
        {
            rb = ObjectToMove.GetComponent<Rigidbody>(); // Generica Type and 
            // var anything = ObjectToMove.GetComponent<Renderer>();
        }

        StartCoroutine(MoveToWaitPoint());
        // var aything = CastomGeneticMethod<Vector2>(Vector2.zero,Vector2.one);

    }

    private void Update()
    {



        if (Input.GetMouseButtonDown(0))
        {


            ObjectToMove.transform.position = ObjectToMove.transform.position + new UnityEngine.Vector3(0, 3f, 0);


        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            CollisianWithTarger = true;



            Debug.Log("Collisias with tagget" + other.gameObject.name);
        }
        //     var Target = list;
        //     if (ObjectToMove.gameObject.name ==  ;
        //     Debug.Log("collissians " + ObjectToMove.gameObject.name);


    }


    private IEnumerator MoveToWaitPoint()
    {
        for (int i = 0; i < list.Count; i++)
        {

            var Target = list[i];
            yield return null;
            while (CollisianWithTarger == false &&
                   (Target.position - ObjectToMove.transform.position).magnitude > 0.05f)
            {

                // ObjectToMove.transform.MoveToPosition(Target);
                var VectorCube = Target.position - ObjectToMove.transform.position;
                rb.AddForce(VectorCube.normalized * 0.03f, ForceMode.Impulse);
                yield return null;

                // if ((Target.position - ObjectToMove.transform.position).sqrMagnitude > 0.05f) ;
                // }
                //
                // ObjectToMove.transform.MoveToPosition(Target);
                // }
            }

            CollisianWithTarger = false;

            // while (true)
            // {        
            //                      Endless LOOP ((
            // }
        }
    }

    // private void EndlessLoop()
    // {  1                         Endless LOOP ((
    //     EndlessLoop();
    // }

    private GenericType CastomGeneticMethod<GenericType>(GenericType a, GenericType b )
     where  GenericType :new ()
    {
        GenericType maximum = new GenericType();
        // if (a>b)
        // {
        //     maximum = a;
        // }
        // else
        // {
        //     maximum = b;
        // }

        return maximum;

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




