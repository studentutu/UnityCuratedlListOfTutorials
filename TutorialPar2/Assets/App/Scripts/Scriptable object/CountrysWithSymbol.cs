using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(CountrysWithSymbol), menuName = "ScriptableObjects/CountrysWithSymbol", order = 1)]
public class CountrysWithSymbol : ScriptableObject
{
    [SerializeField] private Texture countrysTexture;
    [SerializeField] private string lenguageCode;

    public string LenguageCode1 => lenguageCode;

    public Texture Texture
    {
        get
        {
            return countrysTexture;
        }
    }
}
