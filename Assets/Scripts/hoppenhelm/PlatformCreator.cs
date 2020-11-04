using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    public GameObject MiddlePlatformPre;
    public GameObject LeftPlatformPre;
    public GameObject RightPlatformPre;


    public int platformCount;

    private List<GameObject> allPlatforms = new List<GameObject>();
    void Start()
    {
        GameObject newLeftPlatform = null;
        GameObject newRightPlatform = null;
        GameObject newMiddlePlatform = null;

        for (int i = 0; i < platformCount; i++)
        {
            if(i==0)
            {
               newLeftPlatform= Instantiate(LeftPlatformPre, new Vector3(i - 7, 0, 0), Quaternion.identity);
                allPlatforms.Add(newLeftPlatform);
            }
            else if(i== platformCount - 1)
            {
                newRightPlatform= Instantiate(RightPlatformPre, new Vector3(i - 7, 0, 0), Quaternion.identity);
                allPlatforms.Add(newRightPlatform);
            }
            else
            {
                newMiddlePlatform = Instantiate(MiddlePlatformPre, new Vector3(i - 7, 0, 0), Quaternion.identity);
                allPlatforms.Add(newMiddlePlatform);
            }

        }
        GameObject newMap = new GameObject("Platform1");
        newMap.transform.position = Vector3.zero;
        for (int i = 0; i < allPlatforms.Count; i++)
        {
            allPlatforms[i].transform.parent = newMap.transform;
        }
    }
}
