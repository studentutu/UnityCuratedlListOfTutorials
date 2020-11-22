using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPhysics : MonoBehaviour
{
    [SerializeField]
    private GameObject ParticlesPrefabe;
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Colaided with" + other.gameObject.name);
        GameObject.Instantiate(ParticlesPrefabe, other.contacts[0].point, Quaternion.identity);
    }
}
