using System;
using System.Collections;
using System.Collections.Generic;
using Jacovone.AssetBundleMagic;
using UnityEngine;
using UnityEngine.UI;

public class UseCountryWithSymbol : MonoBehaviour
{

    [SerializeField] private List<CountrysWithSymbol> ListCOuntry= new List<CountrysWithSymbol>();
    [SerializeField] private RawImage SetTexture;
    
    private Dictionary<string, CountrysWithSymbol> dict = new Dictionary<string, CountrysWithSymbol>();
    
    private void Awake()
    {
        foreach (var item in ListCOuntry)
        {
            if (!dict.ContainsKey(item.LenguageCode1))
            {
                dict.Add(item.LenguageCode1, item);
            }
        }
    }

    private CountrysWithSymbol findFromLenguageCode(string FindCode)
    {
        CountrysWithSymbol result = null;
        if (dict.ContainsKey(FindCode))
        {
            result = dict[FindCode];
        }
        return result;
        
    }

    private void Start()
    {
        LoadFromAssetBundles();
        loadFromResources();
        CountrysWithSymbol DebugStack = null;
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Afrikaans:
                DebugStack= findFromLenguageCode("Af");
                
                break;
            case SystemLanguage.Arabic:
                break;
            case SystemLanguage.Basque:
                break;
            case SystemLanguage.Belarusian:
                break;
            case SystemLanguage.Bulgarian:
                break;
            case SystemLanguage.Catalan:
                break;
            case SystemLanguage.Chinese:
                break;
            case SystemLanguage.Czech:
                break;
            case SystemLanguage.Danish:
                break;
            case SystemLanguage.Dutch:
                break;
            case SystemLanguage.English:
                
                break;
            case SystemLanguage.Estonian:
                break;
            case SystemLanguage.Faroese:
                break;
            case SystemLanguage.Finnish:
                break;
            case SystemLanguage.French:
                break;
            case SystemLanguage.German:
                break;
            case SystemLanguage.Greek:
                break;
            case SystemLanguage.Hebrew:
                break;
           case SystemLanguage.Icelandic:
                break;
            case SystemLanguage.Indonesian:
                break;
            case SystemLanguage.Italian:
                break;
            case SystemLanguage.Japanese:
                break;
            case SystemLanguage.Korean:
                break;
            case SystemLanguage.Latvian:
                break;
            case SystemLanguage.Lithuanian:
                break;
            case SystemLanguage.Norwegian:
                break;
            case SystemLanguage.Polish:
                break;
            case SystemLanguage.Portuguese:
                break;
            case SystemLanguage.Romanian:
                break;
            case SystemLanguage.Russian:
                DebugStack= findFromLenguageCode("Ru");
                break;
            case SystemLanguage.SerboCroatian:
                break;
            case SystemLanguage.Slovak:
                break;
            case SystemLanguage.Slovenian:
                break;
            case SystemLanguage.Spanish:
                break;
            case SystemLanguage.Swedish:
                break;
            case SystemLanguage.Thai:
                break;
            case SystemLanguage.Turkish:
                break;
            case SystemLanguage.Ukrainian:
                break;
            case SystemLanguage.Vietnamese:
                break;
            case SystemLanguage.ChineseSimplified:
                break;
            case SystemLanguage.ChineseTraditional:
                break;
            case SystemLanguage.Unknown:
                break;
            default:
               break;
        }
        
        Debug.Log("System lenguage code " + Application.systemLanguage + " foudn : " + DebugStack);
        if (DebugStack!=null)
        {
            SetTexture.texture = DebugStack.Texture;
        }
    }

    private void loadFromResources()
    {
        var NewResource = Resources.Load<CountrysWithSymbol>("Russia");

        var loadAllResourcesOfType = Resources.LoadAll<CountrysWithSymbol>("");
        if (!dict.ContainsKey(NewResource.LenguageCode1))
        {
            dict.Add(NewResource.LenguageCode1, NewResource);
        }

        if (!dict.ContainsKey(NewResource.LenguageCode1))
        {
            if (dict[NewResource.LenguageCode1]==null)
            {
                dict[NewResource.LenguageCode1] = NewResource;
            }
        }

        if (!dict.TryGetValue(NewResource.LenguageCode1, out var reult) && reult == null)
        {
            dict[NewResource.LenguageCode1] = NewResource;

        }
    }

    private void LoadFromAssetBundles()
    {
        var bundle =  AssetBundleMagic.LoadBundle("countrys");
        var bundle2 =  AssetBundleMagic.LoadBundle("countrys");
        var bundle3 =  AssetBundleMagic.LoadBundle("countrys");
        var bundle4 =  AssetBundleMagic.LoadBundle("countrys");
        var downbundle =  bundle.LoadAsset<CountrysWithSymbol>("England");
        
        
    }
}
