using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CastomApi;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class WeatherTest
    {
        private WeatherApi SetupTest()
        {
            var newObject = new GameObject();
            var api =  newObject.AddComponent<WeatherApi>();
            var apiOriginal = Resources.Load<WeatherApi>(nameof(WeatherApi));
            var tpJson = JsonUtility.ToJson(apiOriginal);
            JsonUtility.FromJsonOverwrite(tpJson, api);
            
            return api;
        }

        // A Test behaves as an ordinary method
        [Test]
        public void WeatherTest2SimplePasses()
        {
           var TestObject =  SetupTest();
           Assert.IsNotNull(TestObject.StoredApiKey);
           
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator WeatherTest2WithEnumeratorPasses()
        {
            var testObject = SetupTest();
            bool cheking = false;
            testObject.GetWeather("London", () =>
            {
                cheking = true;
            });
            while (!cheking)
            {
                yield return null;
                
            }

            LogAssert.Expect(LogType.Log, new Regex("[0-1000]*"));

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
        }
    }
}
