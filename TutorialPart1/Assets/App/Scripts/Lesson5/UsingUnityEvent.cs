using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UsingUnityEvent : MonoBehaviour
{
    public MyClass MyClassVar=new MyClass();
    public UnityEvent CastomEvent;
    
    [Serializable]
    public class  MyClass : UnityEvent<GameObject,float>
    {
    }


    public void ExampleUseEvent(GameObject Geo, float ExampleFloat)
    {
    }

}
