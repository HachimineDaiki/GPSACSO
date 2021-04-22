using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageTiming : MonoBehaviour
{
    stageSpawner spawner;
    void Start()
    {
        spawner = GameObject.Find("Stage").GetComponent<stageSpawner>();
    }

    // Update is called once per frame
    private void OnTrigge(Collider other)
    {
        //spawner.CreateFlg = true;
    }
}
