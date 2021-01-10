using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using UnityEngine;

public class PlayerDataBase : MonoBehaviour
{
    private bool Avialable = false;
    private System.Action Clousure = null;
    
    private async Task<bool> OnCheckDatabse()
    {
        var waitFor = 
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync();
            
        await waitFor;

        if (waitFor == null || waitFor.IsFaulted || waitFor.IsCanceled)
        {
            Avialable = false;
            return false;
        }
            var dependencyStatus = waitFor.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                var app = Firebase.FirebaseApp.DefaultInstance;
                Avialable = true;
                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}",
                    dependencyStatus));
                Avialable = false; 
                // Firebase Unity SDK is not safe to use here.
            }

            return true;
    }
   
   public async void SavePlayerToDataBase(string DataTosave, string key)
   {
       Clousure = () =>
       {
           FirebaseDatabase.DefaultInstance.RootReference.Child(key).SetRawJsonValueAsync(DataTosave);
       };
        
       await OnCheckDatabse();
       if (Avialable)
       {
           Send();
       }
   }

   private void Send()
   {
       Clousure?.Invoke();
   }
   


   public async Task<string> RealFromDataBase(string key)
   {
       await OnCheckDatabse();
       if (Avialable)
       {
           var anything = FirebaseDatabase.DefaultInstance.RootReference.Child(key).GetValueAsync();
           await anything;
           
           if (anything == null || anything.IsFaulted || anything.IsCanceled)
           {
               return null;
           }

           var returnJSONValue = anything.Result.GetRawJsonValue();
           Debug.Log("Key " +" " +  key +  " " + returnJSONValue);
           return returnJSONValue;
       }

       return null;
   }


}
