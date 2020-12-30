using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class CalculButton : MonoBehaviour
{
    public Text label;

    public RectTransform rectTransform
    {
        get
        {
            if (_rectTransform == null)
            
                _rectTransform = GetComponent<RectTransform>();
                return _rectTransform;
            
        }
    } private RectTransform _rectTransform;

    public Manager calcManager
    {
        get
        {
            if (_calcManager == null)
                _calcManager = GetComponentInChildren<Manager>();
            return _calcManager;
        }
    }

    private static Manager _calcManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onTapped()
    {
        Debug.Log("Tapped: " + label.text);
        calcManager.buttonTapped(label.text[0]);
    }
}
