using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//transform.forward // 前
//-transform.forward // 後ろ

//transform.right // 右
//-transform.right // 左

//transform.up // 上
//-transform.up // 下


public class Move : MonoBehaviour
{

    [SerializeField] float Speed = 50.0f;

    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 2500.0f;

    //int型を変数targetLaneで宣言します。
    int targetLane;

    //長押し移動を防止する　
    public bool MoveFlg = false;


    private void Start()
    {
        targetLane = 0;
    }

    private void FixedUpdate()
    {
        Vector3 velocity = gameObject.transform.forward * Speed;
        gameObject.transform.position += velocity * Time.deltaTime;
        if (Input.GetAxis("Horizontal") == 0)
        {
            MoveFlg = false;
        }
        else
        if (Input.GetAxis("Horizontal") == 1 || Input.GetKeyDown("right"))
        {
            MoveToRight();
        }
        else
        if (Input.GetAxis("Horizontal") == -1 || Input.GetKeyDown("left"))
        {
            MoveToLeft();
        }
    }


public void MoveToRight()
    {
        if (targetLane != MaxLane && MoveFlg == false)
        {
            MoveFlg = true;
            transform.position += transform.right * LaneWidth * Time.deltaTime;
            Debug.Log("targetLane");
            targetLane += 1;
        }
    }

    public void MoveToLeft()
    {
        if (targetLane != MinLane && MoveFlg == false)
        {
            MoveFlg = true;
            transform.position -= transform.right * LaneWidth * Time.deltaTime;
            Debug.Log("targetLane");
            targetLane -= 1;
        }
    }

}