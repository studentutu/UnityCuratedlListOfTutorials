using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boosts : MonoBehaviour
{  
    
    private int BombPoints=3;
    public void BombBoost(EnemyScript other)
    {
        Debug.Log("Yes");
        other.HittsPoints=other.HittsPoints-BombPoints;
        


    }
}
