using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemy;

    [SerializeField] private float NextappearTime = 0f;
    [SerializeField] private float ElapsedTime = 0f;

    public float Maxsec = 5.0f;
    public float Minsec = 2.0f;


    Vector3 RespornPosition;
    void Start()
    {
        NextappearTime = Random.Range(Minsec, Maxsec);
    }

    // Update is called once per frame
    void Update()
    {
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
        float[] PosX = {-40.0f, -12.5f, 12.5f, 40.0f};
        float DecisionX = 12.5f;

        int Range = Random.Range(0, 4);
        DecisionX = PosX[Range];

        return DecisionX;
    }

    void enemySpawn()
    {
        RespornPosition = new Vector3(Xcreate(), enemy.transform.position.y, transform.position.z);
        Instantiate(enemy, RespornPosition, enemy.transform.rotation);
    }
}
