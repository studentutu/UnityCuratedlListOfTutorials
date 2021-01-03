using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;

public class AutomaticTest : MonoBehaviour
{
   public bool Test;
   public bool TestDataBase;
   public bool TestDataBaseGET;
   
   [SerializeField]
   private PlayerDataBase PiBiDi ;

      private void OnValidate()
   {
      if (TestDataBase)
      {
         TestDataBase = false;
         PiBiDi.SavePlayerToDataBase(TestPlayerDataSerialization(), "Bohdan101");
      }
      if (Test)
      {
         Test = false;
         TestPlayerDataSerialization();
      }
      if (TestDataBaseGET)
      {
         TestDataBaseGET = false;
          PiBiDi.RealFromDataBase("Bohdan101");
      }
      
   }

   private string  TestPlayerDataSerialization()
   {
      PlayerData anibeni=new PlayerData();
      anibeni.Name = "Bogdan";
      anibeni.Age = 24;
      anibeni.MaxScore = 100;
      Debug.Log(anibeni.PlayerDataToJSON());
      return anibeni.PlayerDataToJSON();
   }
   
   
}

