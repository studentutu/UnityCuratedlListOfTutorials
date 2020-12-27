using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRightTurn : MonoBehaviour
{
    //-public Collider MainCollider;
    //public Collider[] AllColliders;

    //public void Awake()
    //{
    //    MainCollider = GetComponent<Collider>();
    //    AllColliders = GetComponentsInChildren<Collider>(false);
    //    DoRagdoll(false);
        
    //}

    

     //public void DoRagdoll(bool isRagdoll)
     //{
     //  
     //    foreach (var col in AllColliders  )
     //    {
     //        col.enabled = isRagdoll;
     //        MainCollider.enabled = !isRagdoll;
     //        GetComponent<Rigidbody>().useGravity = !isRagdoll;
     //        //GetComponent<Animator>().enabled = !isRagdoll;

        // }
    // }
    [Header("Reference")] 
    [SerializeField] private Animator animator = null;

    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;

    private void Start()
    {
        ragdollBodies = GetComponentInChildren<Rigidbody[]>();
        ragdollColliders = GetComponentInChildren<Collider[]>();
        ToggleRagDoll(true);
        Invoke(nameof(Die), 2f);
    }

    private void Die()
    {
        foreach (Rigidbody rb in ragdollBodies)
            
        {
            rb.AddExplosionForce(1f, new Vector3(1f,1f,1f),1f, 1f, ForceMode.Impulse );
        }
    }

    private void ToggleRagDoll(bool state)
    {
        animator.enabled = !state;
        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = state;
        }

        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = state; 
        }

    }
}





