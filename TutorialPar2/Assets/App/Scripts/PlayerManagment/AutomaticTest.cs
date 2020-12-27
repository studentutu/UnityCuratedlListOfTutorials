using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;

public class AutomaticTest : MonoBehaviour
{
   public bool Test;

   private void OnValidate()
   {
      if (Test)
      {
         Test = false;
         TestPlayerDataSerialization();
      }
      
   }

   private void TestPlayerDataSerialization()
   {
      PlayerData anibeni=new PlayerData();
      anibeni.Name = "Bogdan";
      anibeni.Age = 24;
      anibeni.MaxScore = 100;
      Debug.Log(anibeni.PlayerDataToJSON());
   }
   
   
}

