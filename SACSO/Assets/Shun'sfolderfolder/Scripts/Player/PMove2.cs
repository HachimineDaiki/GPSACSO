using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMove2 : MonoBehaviour
{
    [SerializeField] GameObject Pointparent;
    Vector3[] point = new Vector3[5];
    private int NowPos;
    private float distance;
    Vector3 Pos1, Pos2;


    // Start is called before the first frame update
    void Start()
    {
        NowPos = 0;
        distance = 0;
        PointGet();
        PointSet();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    void PointGet()
    {
        int i = 0;
        //parentGameObjectは親要素のgameObject
        foreach (Transform child in Pointparent.transform)
        {
            point[i++] = (child.transform.position);
        }
    }

    void PointSet()
    {
        Pos1 = point[NowPos];
        if(NowPos == 4) Pos2 = point[0];
        else Pos2 = point[NowPos + 1];

    }

    void Move()
    {
        float Speed = 5f;

        distance += Time.deltaTime / Speed;
        if(distance > 1f)
        {
            if (++NowPos > 4) NowPos = 0;
            distance = 0;
            PointGet();
            PointSet();
        }

        transform.position = Vector3.Lerp(Pos1, Pos2, distance);
    }
}
