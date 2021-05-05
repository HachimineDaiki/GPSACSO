using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muscleobject : MonoBehaviour
{   
    private static PartsHuge prt;
    private static PartsHuge plt;
    
    // Update is called once per frame
    void Start()
    {
       prt = GameObject.Find("musslepants2Unity").GetComponent<PartsHuge>();
       plt = GameObject.Find("musslepants2Unity").GetComponent<PartsHuge>();

       muspoint();
    }
    void muspoint() {
        Debug.Log("prt");
        Debug.Log("plt");
    }
}
