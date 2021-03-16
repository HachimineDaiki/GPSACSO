using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemy;
    Vector3 RespornPosition;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RespornPosition = new Vector3(Xcreate(), enemy.transform.position.y, transform.position.z);
            Instantiate(enemy, RespornPosition,enemy.transform.rotation);
        }

    }

    private float Xcreate()
    {
        float[] PosX = {-40.0f, -12.5f, 12.5f, 40.0f};
        float DecisionX = 12.5f;

        int Range = Random.Range(0, 4);
        DecisionX = PosX[Range];
        Debug.Log(Range);

        return DecisionX;
    }
}
