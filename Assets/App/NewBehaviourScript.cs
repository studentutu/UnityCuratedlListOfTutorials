using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
