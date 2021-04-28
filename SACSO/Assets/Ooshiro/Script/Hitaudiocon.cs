using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitaudiocon : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public bool Hitflg;

    GameObject expsound;
    enemyMove enemymove;
    void Start()
    {
        Hitflg = false;
    }

    // Update is called once per frame
    public void Update()
    {
        
        expsound = GameObject.Find("enemy2.0(Clone)");
        if(expsound != null)
        {
            enemymove = expsound.GetComponent<enemyMove>();
            if (enemymove.KillFlg == true)
            {
                Hitflg = true;
            }
        }
    }
}
