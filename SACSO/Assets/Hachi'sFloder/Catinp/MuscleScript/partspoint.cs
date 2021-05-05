using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class partspoint : MonoBehaviour
{
    private PartsHuge rpom;
    private PartsHuge lpom;

    int pl=0;//右腕に対する点数
    int pr=0;//左腕に対する点数

    // Start is called before the first frame update
    void Start()
    {
        pl = 1;
        pr = 1;
        rpom = GameObject.Find("musslepants2Unity").GetComponent<PartsHuge>();
        lpom = GameObject.Find("musslepants2Unity").GetComponent<PartsHuge>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rpom.prt) {
            pr += 1;
        }
        else if(lpom.plt){
            pl += 1;
        }
        
        PlayerPrefs.SetInt("rpumpup",pr);
        PlayerPrefs.SetInt("lpumpup",pl);
        PlayerPrefs.Save();
    }
}
