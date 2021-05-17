using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    // Start is called before the first frame update
    private float Pos;

    Vector3 StartPos;
    Vector3 EndPos;

    private Runaway runaway;

    void Start()
    {
        Pos = 0f;
        StartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        EndPos = new Vector3(transform.position.x, transform.position.y + 20.0f, transform.position.z - 30.0f);

        runaway = GameObject.Find("GameManeger").GetComponent<Runaway>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Dush();
        transform.localPosition = Vector3.Lerp(StartPos, EndPos, Pos);


    }

    void Dush()
    {
        if (runaway.DushFlg)
        {
            Pos += Time.deltaTime;
            if (Pos >= 1.0f)
            {
                Pos = 1.0f;
                Invoke("DushRelease", 3.0f);
            }
        }
        else
        {
            Pos -= Time.deltaTime;
            if (Pos <= 0f)
            {
                Pos = 0f;
            }
        }

    }


}
