using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticTest : MonoBehaviour
{
   public bool Test;
   public bool TestDataBase;
   public bool TestDataBaseGET;
   
   [SerializeField]
   private PlayerDataBase PiBiDi ;

   private const string keyString = "Key";
   private string UserGUid
   {
      get
      {
         userguid= PlayerPrefs.GetString(keyString);
         if (string.IsNullOrEmpty(userguid))
         {
            userguid = System.Guid.NewGuid().ToString();
            SaveKeyToPlayerPrefs(userguid);
         }
         return userguid;
      }
   }
   private string userguid = null;
   
   
   private void OnValidate()
   {
      
      if (TestDataBase)
      {
         TestDataBase = false;
         PiBiDi.SavePlayerToDataBase(TestPlayerDataSerialization(), UserGUid);
      }
      if (Test)
      {
         Test = false;
         TestPlayerDataSerialization();
      }
      if (TestDataBaseGET)
      {
         TestDataBaseGET = false;
          PiBiDi.RealFromDataBase(UserGUid);
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

   private void SaveKeyToPlayerPrefs(string key)
   {
      PlayerPrefs.SetString(keyString, key);
      PlayerPrefs.Save();
   }
}

