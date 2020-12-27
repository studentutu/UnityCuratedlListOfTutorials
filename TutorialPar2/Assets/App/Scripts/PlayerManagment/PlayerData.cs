using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string Name;
    public int Age;
    public int MaxScore;

    
    
    public string PlayerDataToJSON()
    {

        return JsonUtility.ToJson(this);
    }
    
    
    
    public PlayerData PlayerDataFromJSON(string JSON)
    {

        return JsonUtility.FromJson<PlayerData>(JSON);
    }


}
