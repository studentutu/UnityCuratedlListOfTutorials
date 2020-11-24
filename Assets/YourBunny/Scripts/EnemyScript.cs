using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

   public int HittsPoints;
   public int ScoreForEmemies;
   public void CheckClickOnMe()
   {
      GameManager.Instance.ChekClick(this);
      
   }
   
      

}
