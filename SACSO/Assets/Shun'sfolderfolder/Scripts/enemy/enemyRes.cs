using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemy;
    private enemyMove eneMove;

    private float NextappearTime = 0f;
    private float ElapsedTime = 0f;

    private float Maxsec = 5.0f;
    private float Minsec = 2.0f;

    private Vector3[] StartPos = {
        new Vector3( 0f,0f,500f ),        //通常の床
        new Vector3( -500f * (float)System.Math.Sqrt(3f),750f,-500f ),        //登坂の床
        new Vector3( 500f * (float)System.Math.Sqrt(3f),-750f,-500f ),        //下り坂の床V2
    };


    [SerializeField] stageSpawner spawner;
    private int Snum;


    Vector3 RespornPosition;
    void Start()
    {
        NextappearTime = Random.Range(Minsec, Maxsec);
        ElapsedTime = 0f;


        spawner = GameObject.Find("StageScroll").GetComponent<stageSpawner>();
        Snum = spawner.CreatType;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Snum = spawner.CreatType;
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > NextappearTime)
        {
            enemySpawn();
            ElapsedTime = 0f;
            NextappearTime = Random.Range(Minsec, Maxsec);
        }

    }

    private float Xcreate()
    {
        float DecisionX = 15f;

        int Range = Random.Range(-2, 2);

        return Range * DecisionX;
    }

    void enemySpawn()
    {
        if (Snum == 3) Snum = 1;
        else if(Snum == 4) Snum = 2;

        float Yrot = 0;

        if (spawner.CreatType % 3 == 0)
        {
        }
        else if (spawner.CreatType % 3 ==1)
        {
            Yrot = 120;
        }
        else if (spawner.CreatType % 3 == 2)
        {
            Yrot = 240;
        }

        //角度をラジアンに変換
        float rad = Mathf.Deg2Rad * (Yrot);

        float ramX = Xcreate();


        //その角度のx座標+中心点を算出する
        float rx = ((Mathf.Cos(rad) * (ramX)) + 0);

        //その角度のy座標+中心点を算出する
        float rz = ((Mathf.Sin(rad) * (ramX)) + 0);


        Vector3 Cpos = new Vector3(StartPos[Snum].x + rx, transform.position.y, StartPos[Snum].z + rz);


        RespornPosition = new Vector3(Xcreate(), enemy.transform.position.y, 520f);
        GameObject obj = Instantiate(enemy, RespornPosition, enemy.transform.rotation);
        eneMove = obj.GetComponent<enemyMove>();
        eneMove.Type = Snum;
    }
}
