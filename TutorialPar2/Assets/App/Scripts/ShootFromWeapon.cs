using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFromWeapon : MonoBehaviour
{

    [SerializeField] private Rigidbody CloneObjetc;
    [SerializeField] private float Impulse;
    [SerializeField] private float TimeToLive;
    public void InstantiedShoot(Transform Position)
    {
        var PosObj = GameObject.Instantiate(CloneObjetc);
        PosObj.transform.position = Position.position;
        PosObj.transform.rotation = Position.rotation;
        PosObj.AddForce(PosObj.transform.forward*Impulse, ForceMode.Impulse) ;
        Destroy(PosObj.gameObject , TimeToLive);
    }
}
