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
    [SerializeField] float speed = 10.0f;
    private bool moveflg = true;


    //長押し移動を防止する　
    public bool MoveFlg = false;


    private void Start()
    {
       
    }

    private void FixedUpdate()
    {
        Vector3 velocity = gameObject.transform.forward * Speed;
        gameObject.transform.position += velocity * Time.deltaTime;

        if (moveflg == true)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
        }

        foreach (Transform child in gameObject.transform)
        {
            child.transform.localPosition = Vector3.zero;
        }
    }
}
