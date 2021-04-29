using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //右幅
    const int RLane = +15;
    //左幅
    const int LLane = -15;
    //動き幅
    const float LaneWidth = 15.0f;


    [SerializeField] private float speedX;

    Animator animator;
    Vector3 PlayMove = Vector3.zero; //それぞれの座標を0で宣言する

    [SerializeField] int targetLane;

    //bool nowExecCoroutine_ = false; //コルーチンが実行中かどうか

    public bool punch = false;



    //長押し移動を防止する　　具志堅が操作
    public bool MoveFlg = false;


    //峻が書いてます
    const float MoveX = 15f;        //横の移動量
    [SerializeField] private Vector3 StartPos, EndPos;
    [SerializeField] float MoveSpeed;            //0~1で動く
    [SerializeField] private bool charMoveFlg;

    Vector3 rotatoin;

    stageSpawner spawner;


    private int Snum;





    // Start is called before the first frame update
    void Start()
    {
        //GetComponentでAnimatorを取得して変数animatorで参照します。
        animator = GetComponent<Animator>();

        spawner = GameObject.Find("StageScroll").GetComponent<stageSpawner>();
        Snum = spawner.CreatType % 3;

        charMoveFlg = false;
        targetLane = 0;


    }

    // Update is called once per frame
    void Update()
    {

        //矢印の向きに移動
        if (Input.GetKeyDown("left")) MoveLeft();
        if (Input.GetKeyDown("right")) MoveRight();
        if (Input.GetKeyDown("z")) MoveAttack();
        if (Input.GetButtonDown("Fire1")) MoveAttack();
        if (Input.GetKeyDown("x")) MoveAttack2();
        if (Input.GetButtonDown("Fire2")) MoveAttack2();

        if (targetLane > 3) targetLane = 3;
        if (targetLane < -3) targetLane = -3;

        MoveF310();


        //float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;

        //PlayMove.x = ratioX * speedX;

        //走る


        //新しい移動方法

        animator.SetBool("run", PlayMove.z >= 0);
        if (charMoveFlg)
        {
            CharMove();
        }

        //Adjustment();




    }



    void MoveF310()
    {

        ////if (Input.GetAxis("Horizontal") == 0)
        ////{


        ////    MoveFlg = false;   //具志堅が操作
        ////}
        ////else if (Input.GetAxis("Horizontal") == 1 && MoveFlg == false)
        ////{
        ////    if (/*controller.isGrounded && */targetLane < RLane) targetLane++;


        ////    MoveFlg = true;//具志堅が操作

        ////}
        ////else if (Input.GetAxis("Horizontal") == -1 && MoveFlg == false)
        ////{
        ////    if (/*controller.isGrounded && */targetLane > LLane) targetLane--;


        ////    MoveFlg = true;//具志堅が操作
        ////}


        if (Input.GetAxis("Horizontal") == 0)
        {
            MoveFlg = false;
        }
        else if (Input.GetAxis("Horizontal") == 1 && MoveFlg == false && targetLane < 3)
        { 
            MoveFlg = true;
            targetLane++;
            RotMoveDis();
        }
        else if (Input.GetAxis("Horizontal") == -1 && MoveFlg == false && targetLane > -3)
        {
            MoveFlg = true;
            targetLane--;
            RotMoveDis();
        }


    }

    public void MoveRight()
    {
        if ( targetLane < RLane) targetLane++;

    }

    public void MoveLeft()
    {
        if (targetLane > LLane) targetLane--;

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

    void RotMoveDis()
    {
        
        //Vector3[]  

        //float rx = targetLane * MoveX;

        //StartPos = transform.position;
        //EndPos = new Vector3(rx, transform.position.y, transform.position.z);

        //childGameObjectは子要素のgameObject
        GameObject obj = transform.parent.gameObject;

        rotatoin = obj.transform.localEulerAngles;
        float Yrot = rotatoin.y;

        if (spawner.CreatType % 3 == 0)
        {
        }else if(spawner.CreatType % 3 ==1)
        {
            Yrot += 240;
            Yrot %= 360;
        }else if(spawner.CreatType % 3 == 2)
        {
            Yrot += 120;
            Yrot %= 360;
        }

        //角度をラジアンに変換
        float rad = Mathf.Deg2Rad * (Yrot);
        
        //その角度のx座標+中心点を算出する
        float rx = ((Mathf.Cos(rad) * (MoveX * targetLane)) + 0);

        //その角度のy座標+中心点を算出する
        float rz = ((Mathf.Sin(rad) * (MoveX * targetLane)) + 0);


        StartPos = transform.position;


        EndPos = new Vector3(rx, transform.position.y, rz);

        MoveSpeed = 0f;
        charMoveFlg = true;

    }

    void CharMove()
    {
        MoveSpeed += Time.deltaTime * 3f;
        transform.position = Vector3.Lerp(StartPos, EndPos, MoveSpeed);

        if (MoveSpeed > 1f)
        {
            charMoveFlg = false;
            transform.position = EndPos;
            MoveSpeed = 0f;
            if (targetLane == 0) transform.position = Vector3.zero;
        }

    }

    void Adjustment()
    {

    }
}
