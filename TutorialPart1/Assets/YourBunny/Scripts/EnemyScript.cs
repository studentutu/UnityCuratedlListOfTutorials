using System.Collections;
using System.Collections.Generic;
using Frictionless;
using UnityEngine;
using Vuforia;
using YourBunny.Scripts;

//[DefaultExecutionOrder(-200)]
public class EnemyScript : MonoBehaviour
{

   public int HittsPoints;
   public int ScoreForEmemies;
   
   public void CheckClickOnMe()
   {
      // var any =  Resources.Load("VuforiaConfiguration") as VuforiaConfiguration;
      ServiceFactory.Resolve<GameManager>().ChekClick(this);
      // GameManager.ChekClick(this);
      
   }
   
      

}
