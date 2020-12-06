using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace YourBunny.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager  Instance;   //Pattern singleton GameManager.Intsnce -> service locator (AllServices.Get<GameManager>)
    
        private static int ScorePoint=0;
        private static bool AlredyFromSrotage = false;

        [SerializeField] private List<GameObject> ListEnemies;
    
        public Button Bomb;
        public Button Frezze;
        public Button Speed;
        public Button Damage;
        public Text ScoreText;
        public Text BestScore; 
        
        private  Save sv = new Save();
    
        public void Awake()
        {
            Instance = this;
            if (!AlredyFromSrotage && PlayerPrefs.HasKey("SV"))
            {
                AlredyFromSrotage = true;
                sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));
                ScorePoint = sv.score;
            }
        
        

        }

    


        public void ChekClick(EnemyScript other)
        {
            Debug.Log("Click to other " + other.name);
            if (other.HittsPoints>0)
            {
                other.HittsPoints--;
                other.gameObject.transform.position +=new Vector3(0f,1f,0f  ); 
            }
            else
            {
                ScorePoint+=other.ScoreForEmemies;
                ScoreText.text = "Score " + ScorePoint+ " $"; 
        
                Destroy(other.gameObject);
                RespawnEnemies();
           
            }
        


        }

        public void RespawnEnemies()
        {
            //Choose random index
            //Instantion random prefab on random place on x 
            int indexToChoose = Random.Range(0, ListEnemies.Count);
            var Spawned= Instantiate(ListEnemies[indexToChoose], new Vector3(0f,0f,10f ), Quaternion.identity);
            Vector3 randomRange = Spawned.transform.position;
            randomRange+=Vector3.right*Random.Range(-2f,3f);
            Spawned.transform.position = randomRange;
        }

    
    
    
        public void BestScoreForButton()
        {
            BestScore.text = "Best Score " + ScorePoint;
   
        }
    
    
        public void OnApplicationQuit()
        {
            JsonUtility.ToJson(sv);
            sv.score = ScorePoint;
            PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
      
        }
    
    
    
    


        private void OnDestroy()
        {
            OnApplicationQuit();
        }
    }
}