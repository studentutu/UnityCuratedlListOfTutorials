using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveBeetvinBounds : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ToMove;
    public GameObject TargetClampXLeft;
    public GameObject TargetClampXRigth;
    public GameObject TargetClampUp;
    public GameObject TargetClampDown;

    public float SpeedMultiplayer = 0.5f;
    //Position beetween asdw 
    //clap range betweemn position 
    // If
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        var localHorizontal = Input.GetAxis("Horizontal");
        var localVertical = Input.GetAxis("Vertical");

        ToMove.transform.position += Vector3.right * localHorizontal*SpeedMultiplayer;
        ToMove.transform.position += Vector3.up * localVertical*SpeedMultiplayer;

      var  clampX = Mathf.Clamp(ToMove.transform.position.x, TargetClampXLeft.transform.position.x,
          TargetClampXRigth.transform.position.x);
      // ToMove.transform.position=new Vector3(clampX,ToMove.transform.position.y,ToMove.transform.position.z);
        //Mathf.Clamp
      
        var  clampy = Mathf.Clamp(ToMove.transform.position.y, TargetClampDown.transform.position.y,
            TargetClampUp.transform.position.y);
        ToMove.transform.position=new Vector3(clampX,clampy,ToMove.transform.position.z);


    }
}
