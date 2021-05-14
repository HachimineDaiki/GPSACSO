using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class partspoint : MonoBehaviour
{
    private modelChange rpom;
    private modelChange lpom;

    int pl=0;//右腕に対する点数
    int pr=0;//左腕に対する点数

    // Start is called before the first frame update
    void Start()
    {
        pl = 1;
        pr = 1;
        rpom = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<modelChange>();
        lpom = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<modelChange>();
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

        PlayerPrefs.SetInt("rpumpup", rpom.ArmInfo[0]);
        PlayerPrefs.SetInt("lpumpup",rpom.ArmInfo[1]);

        PlayerPrefs.SetInt("RPunchCt", rpom.punchNum[0]);
        PlayerPrefs.SetInt("LPunchCt", rpom.punchNum[1]);
        PlayerPrefs.Save();
    }
}
