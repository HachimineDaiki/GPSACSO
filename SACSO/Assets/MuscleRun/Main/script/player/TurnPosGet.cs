using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPosGet : MonoBehaviour
{
    public GameObject[] TurnPos = new GameObject[4];


    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (Transform child in gameObject.transform)
        {
            TurnPos[i++] = child.gameObject;
        }
    }


    public GameObject GetPosObj(int type)
    {
        return TurnPos[type];
    }

    // Update is called once per frame

}
