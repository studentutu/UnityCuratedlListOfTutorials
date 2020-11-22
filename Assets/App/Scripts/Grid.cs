using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{   [Header("Clone of cube")]
    public GameObject block;
    [Space]
    public int width = 10;
    public int height = 4;
    
    void Start()
    {
        StartCoroutine(TestCoroutine());
        
    }

    private IEnumerator TestCoroutine()
    {
        // yield return null; // 1 frame wait
        yield return new WaitForSeconds(3f); // 3 seconds wait
        // yield break; // return
        
        
        for (int y=0; y<height; ++y)
        {
            for (int x=0; x<width; ++x)
            {
                
                var objectreturnss =   Instantiate(block, new Vector3(x,y,0), Quaternion.identity);

                objectreturnss.transform.parent = this.transform;
                StartCoroutine(AnimationScale(objectreturnss));
                    
                yield return null;
            }
        }
    }

    private IEnumerator AnimationScale(GameObject GoToAnimate)
    {
        // scale from 0 to initial GoToAnimate.scale
        float initialScale = GoToAnimate.transform.localScale.x;
        float startTime = 1f;
        float timeToAnimate = startTime;

        while (timeToAnimate > 0)
        {
            GoToAnimate.transform.localScale = Vector3.one * Mathf.Lerp(0,initialScale,  (startTime - timeToAnimate));
            timeToAnimate -= Time.deltaTime;
            yield return null;
            
        }
        GoToAnimate.transform.localScale= Vector3.one * initialScale;
    }

}
