using System.Collections;
using System.Collections.Generic;
using Frictionless;
using UnityEngine;
using YourBunny.Scripts;

public class EnemyScript : MonoBehaviour
{

   public int HittsPoints;
   public int ScoreForEmemies;
   
   public void CheckClickOnMe()
   {
      
      ServiceFactory.Resolve<GameManager>().ChekClick(this);
      // GameManager.ChekClick(this);
      
   }
   
      

}
