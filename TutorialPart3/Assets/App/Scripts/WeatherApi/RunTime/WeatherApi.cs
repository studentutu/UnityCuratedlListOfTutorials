using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace CastomApi
{
    public class WeatherApi : MonoBehaviour
    {
        [SerializeField] private string ApiKeyPass;
        [SerializeField] private string url;


        [NonSerialized] private string CashApiKey = null; // fields

        // Property
        public string StoredApiKey
        {
            get
            {
                if (string.IsNullOrEmpty(CashApiKey))
                {
                    var TestAssets = Resources.Load<TextAsset>(ApiKeyPass);
                    CashApiKey = TestAssets.text;
                }

                return CashApiKey;
            }
        }
        
        public void GetWeather(string city, System.Action OnComplite)
        {
            StartCoroutine(WaitingForRespounse(city, OnComplite));
        }

        private IEnumerator WaitingForRespounse(string city, System.Action OnComplite)
        {
            string finalurl = string.Format(url, city, StoredApiKey);
            using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(finalurl))
            {
                yield return unityWebRequest.SendWebRequest();

                if (string.IsNullOrEmpty(unityWebRequest.error))
                {
                    // no errors
                    Debug.Log(unityWebRequest.downloadHandler.text);
                    var InternalObject = WeatherApiJson.FromJsdon(unityWebRequest.downloadHandler.text);
                    Debug.Log(InternalObject.ToJson());
                }
                else
                {
                    Debug.Log(unityWebRequest.responseCode + " " + unityWebRequest.error);
                }
            }

            OnComplite.Invoke();
        }
    }

    [Serializable]
    public class WeatherApiJson
    {
        public CoordsWeather coord;
        public List<WeatherListItem> weather;

        public static WeatherApiJson FromJsdon(string Json)
        {
            return JsonUtility.FromJson<WeatherApiJson>(Json);
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
    }

    [Serializable]
    public class CoordsWeather
    {
        public float lon;
        public float lat;
    }

    [Serializable]
    public class WeatherListItem
    {
        public int id;
        public string main;
        public string description;
    }
}