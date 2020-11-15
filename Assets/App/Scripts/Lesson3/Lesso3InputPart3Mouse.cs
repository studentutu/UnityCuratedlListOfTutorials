using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesso3InputPart3Mouse : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] 
    private float speedMultiplayer = 0.5f;
    [SerializeField]
    private GameObject ToMove;

    private Vector2? PreviousPosition = null;
    
    private void MomentWithMouse()
    {
        //Input.mouseScrollDelta   
        //Homework   Bound - clampPositions values   Same 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        ToMove.transform.position += ToMove.transform.right * horizontal*speedMultiplayer;
        ToMove.transform.position += ToMove.transform.forward * vertical*speedMultiplayer;
        var currentPos = (Vector2)Input.mousePosition;
        if (PreviousPosition == null)
        {
            PreviousPosition = currentPos;
            return;
            
        }

        // Rotation with mouse -> delta mouse poisition x -> HorRotatt y-> Vertical
            
            var MouseDeltaReal = currentPos - PreviousPosition.Value;
            var MouseDeltaRealv2 =new Vector2(MouseDeltaReal.x, Mathf.Clamp(MouseDeltaReal.y,-45f, 45f )); 

            //Debug.Log(MouseDeltaReal);
            PreviousPosition = currentPos;
            ToMove.transform.rotation *= Quaternion.Euler(new Vector3(MouseDeltaRealv2.x, MouseDeltaRealv2.y,0));
    }

    // Update is called once per frame
    void Update()
    {
     MomentWithMouse();   
    }
}
