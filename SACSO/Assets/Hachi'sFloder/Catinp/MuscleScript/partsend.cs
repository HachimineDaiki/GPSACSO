using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partsend : MonoBehaviour
{

    private int rightpoint;
    private int leftpoint;
    // Start is called before the first frame update
    void Start()
    {
        rightpoint = PlayerPrefs.GetInt("rpumpup",0);
        leftpoint = PlayerPrefs.GetInt("lpumpup",0);
        Debug.Log(rightpoint);
        Debug.Log(leftpoint);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
