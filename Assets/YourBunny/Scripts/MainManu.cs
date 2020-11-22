using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManu : MonoBehaviour
{
  
   public Button play;
   public Button Settings;
   public Button Store;
   public Button Exit;

   [Header("Pannels")]
   
   public GameObject SettingsPannel;
   public GameObject StorePannel;
   
   
   private void OnEnable()
   {
      Settings.onClick.AddListener(OnSettingsClick);
      Store.onClick.AddListener(OnStoreClick);

   }
   

   private void OnDisable()
   {
      Settings.onClick.RemoveListener(OnSettingsClick);
      Store.onClick.RemoveListener(OnStoreClick);
      
   }

   private void OnSettingsClick()
   {
      SettingsPannel.SetActive(true);
   }

   
   private void OnStoreClick()
   {
      StorePannel.SetActive(true);
   }
}

