using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Gun : MonoBehaviour
{
    // 1. Input click mouse 2. If click we fire bullet 3. When bullets hits its is destroyed 

    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Gun2;
    [SerializeField] private List<Transform> PrefabBullet;

        private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < 200; i++)
            {
            var RandomBullet = PrefabBullet[Random.Range(0, PrefabBullet.Count)];
            var instantionBullet=GameObject.Instantiate(RandomBullet);
            instantionBullet.transform.forward= Random.insideUnitSphere*5f;
                
            }
            
            
        }
        
        
        
    }
}
