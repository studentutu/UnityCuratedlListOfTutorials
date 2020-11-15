using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    // 1. Points 2. Cube bitween points 3. Check if near target 4. Reaped step ->2
   [SerializeField] private Transform[] aarays;
   [SerializeField] private List<Transform> list;

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
}
