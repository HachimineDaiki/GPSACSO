using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eneRepop : MonoBehaviour
{
    // Start is called before the first frame update
    private bool CreateFlg;
    void Start()
    {
        CreateFlg = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!transform.GetChild(0).gameObject.activeSelf && CreateFlg)
        {
            Invoke("childacitive", 5.0f);
            CreateFlg = false;
        }
    }

    void childacitive()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        CreateFlg = true;
    }
}
