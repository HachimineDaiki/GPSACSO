using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{

    Animator animator;
    Vector3 PlayMove = Vector3.zero; //それぞれの座標を0で宣言する


    //bool nowExecCoroutine_ = false; //コルーチンが実行中かどうか

    public bool punch = false;



    //長押し移動を防止する　　具志堅が操作
    public bool MoveFlg = false;


    //峻が書いてます
    const float MoveX = 15f;        //横の移動量

    // Start is called before the first frame update
    void Start()
    {
        //GetComponentでAnimatorを取得して変数animatorで参照します。
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //矢印の向きに移動
        if (Input.GetKeyDown("z")) MoveAttack();
        if (Input.GetKeyDown("x")) MoveAttack2();


        if (Input.GetButton("Fire1"))
        {
            Debug.Log("A");
            MoveAttack();
        }
        if (Input.GetButton("Fire2"))
        {
            Debug.Log("B");
            MoveAttack2();
        }

        MoveF310();

        animator.SetBool("run", PlayMove.z >= 0);


    }



    void MoveF310()
    {

        if (Input.GetAxis("Horizontal") == 0)
        {
            //長押し防止
            //MoveFlg = false;
        }
        else if (Input.GetAxis("Horizontal") == 1 && MoveFlg == false)
        {
            //右に移動
            //MoveFlg = true;
            //targetLane++;
            //RotMoveDis();
        }
        else if (Input.GetAxis("Horizontal") == -1 && MoveFlg == false)
        {
            //左に移動
            //MoveFlg = true;
            //targetLane--;
            //RotMoveDis();
        }


    }

    public void MoveAttack()
    {

        animator.SetTrigger("attack");
        punch = true;
        Invoke("punchreset", 0.8f);
    }
    public void MoveAttack2()
    {

        animator.SetTrigger("attack2");
        punch = true;
        Invoke("punchreset", 0.8f);
    }
    void punchreset()
    {
        punch = false;
    }

}
