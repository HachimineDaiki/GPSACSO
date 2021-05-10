using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitaudiocon : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public bool Hitflg;

    GameObject expsound;
    Blowaway blowaway;
    void Start()
    {
        Hitflg = false;
    }

    // Update is called once per frame
    public void Update()
    {
        
        expsound = GameObject.Find("DamageDrum(Clone)");
        if(expsound != null)
        {
            blowaway = expsound.GetComponent<Blowaway>();
            if (blowaway.KillSEflg == true)
            {
                Hitflg = true;
            }
        }
    }
}
