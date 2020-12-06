using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YourBunny.Scripts;

public class MainManu : MonoBehaviour
{
  
   public Button play;
   public Button Settings;
   public Button Store;
   public Button Exit;
   public Text BestScore;
   

   [Header("Pannels")]
   
   public GameObject SettingsPannel;
   public GameObject StorePannel;


   private void Awake()
   {
   

   }


   private void OnEnable()
   {
      Settings.onClick.AddListener(OnSettingsClick);
      Store.onClick.AddListener(OnStoreClick);
      var sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));
      BestScore.text = sv.score.ToString();

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



   public void OnStoreClick()
   {
      StorePannel.SetActive(true);
   }

   


}

