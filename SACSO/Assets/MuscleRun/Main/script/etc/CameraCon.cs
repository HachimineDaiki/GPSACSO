using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    // Start is called before the first frame update
    private float Pos;
    private float d_pos;

    Vector3 StartPos;
    Vector3 EndPos;

    private Runaway runaway;

    private PlayerLife pL; //死んだ時用に使う。

    void Start()
    {
        d_pos = 0f;
        Pos = 0f;
        StartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        EndPos = new Vector3(transform.position.x, transform.position.y + 20.0f, transform.position.z - 30.0f);

        
        pL = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<PlayerLife>();
        runaway = GameObject.Find("GameManeger").GetComponent<Runaway>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        DeathCamera();
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
    void DeathCamera() {
        if(pL.Life == 0) {
           
            
            if (d_pos >= 1.0f) {
                
            }else{
                d_pos += Time.deltaTime;
                // クォータニオン → オイラー角への変換
                Vector3 rotationAngles = transform.rotation.eulerAngles;
              rotationAngles.x += Time.deltaTime * 50;
              transform.rotation = Quaternion.Euler(rotationAngles);
            }
        }
    }

}
