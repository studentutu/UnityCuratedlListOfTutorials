using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;   //Pattern singleton

    [SerializeField] private List<GameObject> ListEnemies;
    
    private void Awake()
    {
        Instance = this;

    }
    
    public Button Bomb;
    public Button Frezze;
    public Button Speed;
    public Button Damage;
    public Text ScoreText;
    private int ScorePoint=0;

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

}
