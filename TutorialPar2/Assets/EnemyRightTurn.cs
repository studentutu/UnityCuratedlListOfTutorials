using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyRightTurn : MonoBehaviour
{
    public Collider MainCollider;
    public Collider[] AllColliders;
    public Rigidbody rb;
    public Animator Animator;
    public void Awake()
    {
        
        AllColliders = GetComponentsInChildren<Collider>(false);
        DoRagdoll(false);
        
    }

    

     public void DoRagdoll(bool isRagdoll)
     {
        rb.Sleep();
         foreach (var col in AllColliders  )
         {
             col.enabled = isRagdoll;
             MainCollider.enabled = !isRagdoll;
             rb.useGravity = !isRagdoll;
             Animator.enabled = !isRagdoll;
    
         }

         MainCollider.enabled = !isRagdoll;
     }

     private void OnCollisionEnter(Collision other)
     {
         DoRagdoll(true);
         var WorldPosistion=other.contacts[0].point;
         rb.AddForceAtPosition(other.impulse, WorldPosistion);
     }

     // [Header("Reference")] 
    // [SerializeField] private Animator animator = null;
    //
    // private Rigidbody[] ragdollBodies;
    // private Collider[] ragdollColliders;
    //
    // private void Start()
    // {
    //     ragdollBodies = GetComponentsInChildren<Rigidbody>();
    //     ragdollColliders = GetComponentsInChildren<Collider>();
    //     ToggleRagDoll(false);
    //     //Invoke(nameof(Die), 2f);
    // }
    //
    // private async void Die()
    // {
    //     await Task.Delay(1000);
    //     foreach (Rigidbody rb in ragdollBodies)
    //         
    //     {
    //         rb.AddExplosionForce(1f, new Vector3(1f,1f,1f),1f, 1f, ForceMode.Impulse );
    //     }
    // }
    //
    // private void ToggleRagDoll(bool state)
    // {
    //     animator.enabled = !state;
    //     foreach (Rigidbody rb in ragdollBodies)
    //     {
    //         rb.isKinematic = state;
    //     }
    //
    //     foreach (Collider collider in ragdollColliders)
    //     {
    //         collider.enabled = state; 
    //     }
    //
    // }
}





