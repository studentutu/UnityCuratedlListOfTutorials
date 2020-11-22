using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lessons3InputPart2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ToMove;
    [SerializeField]
    private KeyCode Up;
    [SerializeField]
    private KeyCode Down;
    [SerializeField]
    private float speedOfmovingUpDown = 0.05f;
    [SerializeField] 
    private float speedMultiplayer = 0.5f;

    [SerializeField]
    private KeyCode ROTETElEFR;
    [SerializeField]
    private KeyCode ROTETERIGHT;
    [SerializeField] 
    private float RotatioMult = 0.005f;
    
    // Update is called once per frame
    private void KeyboardMovemend()
    {
        //1. Input left-right 2. Some but up-down 3. Move position object

        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        ToMove.transform.position += ToMove.transform.right * horizontal*speedMultiplayer;
        ToMove.transform.position += ToMove.transform.forward * vertical*speedMultiplayer;
        if (Input.GetKey(Up))
        {
            ToMove.transform.position += ToMove.transform.up * speedOfmovingUpDown*speedMultiplayer;
        }
        if (Input.GetKey(Down))
        {
            ToMove.transform.position += ToMove.transform.up * speedOfmovingUpDown* -1f*speedMultiplayer;
        }        
        
        if (Input.GetKey(ROTETElEFR))
        {
            ToMove.transform.rotation *= Quaternion.Euler(new Vector3(0, -15*RotatioMult, 0));
        }
        if (Input.GetKey(ROTETERIGHT))
        {
            ToMove.transform.rotation *= Quaternion.Euler(new Vector3(0, 15*RotatioMult, 0));
        }
    


    }

    void Update()
    {
        KeyboardMovemend();
        

    }
}
