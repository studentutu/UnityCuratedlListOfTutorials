using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Auth;
using UnityEngine;

public class PlayerAuth : MonoBehaviour
{
    public bool TestAuth;
    public bool TestAuthDelete;
    public UnityEngine.UI.Text LoginText;

    private void OnEnable()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                var app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}",
                    dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    private void OnValidate()
    {
        if (TestAuth)
        {
            TestAuth = false;
            TestPlayerDataSerialization();
        }

        if (TestAuthDelete)
        {
            TestAuthDelete = false;
            DeleteAuthFromDevice();
        }
    }

    private void DeleteAuthFromDevice()
    {
        var auth = FirebaseAuth.GetAuth(Firebase.FirebaseApp.DefaultInstance);
        if (auth.CurrentUser != null && !string.IsNullOrEmpty(auth.CurrentUser.UserId))
        {
            auth.SignOut();
            Debug.Log("Sing Out");
        }
    }

    private async void TestPlayerDataSerialization()
    {
        var auth = FirebaseAuth.GetAuth(Firebase.FirebaseApp.DefaultInstance);
        if (auth.CurrentUser == null || string.IsNullOrEmpty(auth.CurrentUser.UserId))
        {
            var taskToWait = auth.SignInWithEmailAndPasswordAsync(LoginText.text, LoginText.text);
            FirebaseUser findUser = null;
            try
            {
                findUser = await taskToWait;
            }
            catch (Exception e)
            {
                findUser = await auth.CreateUserWithEmailAndPasswordAsync(LoginText.text, LoginText.text);
            }
            finally
            {
                var AW = findUser.UserId;
                Debug.Log("Auth from firebase = " + AW);
            }
        }

        var awaitFor = await AsynctedFunction();
    }

    private async Task<string> AsynctedFunction()
    {
        await Task.Delay(20000);
        return "any";
    }
}