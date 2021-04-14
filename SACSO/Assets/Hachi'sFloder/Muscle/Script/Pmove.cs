using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pmove : MonoBehaviour
{
    //右幅
    const int RLane = +15;
    //左幅
    const int LLane = -15;
    //動き幅
    const float LaneWidth = 15.0f;

    float lastTimeArrowkeyDown_ = 0f; //最後にスティックを傾けた時間

    [SerializeField] private float speedX;
    private float speedZ;
    [SerializeField] private float gravity;

    CharacterController controller;
    Animator animator;
    Vector3 PlayMove = Vector3.zero; //それぞれの座標を0で宣言する

    int targetLane;

    //bool nowExecCoroutine_ = false; //コルーチンが実行中かどうか

    public bool punch = false;



    //長押し移動を防止する　　具志堅が操作
    public bool MoveFlg=false;

      // Start is called before the first frame update
    void Start()
    {
        //GetComponentでCharacterControllerwp取得して変数controllseで参照します。
        controller = GetComponent<CharacterController>();
        //GetComponentでAnimatorを取得して変数animatorで参照します。
        animator = GetComponent<Animator>();

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

        if (Time.time - lastTimeArrowkeyDown_ > 0.01f)
        {
            MoveF310();
        }
    
        float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;

        PlayMove.x = ratioX * speedX;

        PlayMove.y -= gravity * Time.deltaTime;

        Vector3 globalDirection = transform.TransformDirection(PlayMove);
        controller.Move(globalDirection * Time.deltaTime);
        //走る
        animator.SetBool("run", PlayMove.z >= 0);

        //Debug.Log(Input.GetAxis("Horizontal"));
        Debug.Log(MoveFlg);

    }

 

    void MoveF310()
    {
 
            if (Input.GetAxis("Horizontal") == 0)
            {
                lastTimeArrowkeyDown_ = Time.time;

                MoveFlg = false;   //具志堅が操作
            }
            else if (Input.GetAxis("Horizontal") == 1 && MoveFlg == false)
            {
                if (/*controller.isGrounded && */targetLane < RLane) targetLane++;

                lastTimeArrowkeyDown_ = Time.time;
                MoveFlg = true;//具志堅が操作

        }
            else if (Input.GetAxis("Horizontal") == -1 && MoveFlg == false)
            {
                if (/*controller.isGrounded && */targetLane > LLane) targetLane--;

                lastTimeArrowkeyDown_ = Time.time;
                MoveFlg = true;//具志堅が操作
        }
    

    }

    public void MoveRight()
    {
        if (/*controller.isGrounded &&*/ targetLane < RLane) targetLane++;
       
    }
  
    public void MoveLeft()
    {
        if (/*controller.isGrounded &&*/ targetLane > LLane) targetLane--;
        
    }

    public void MoveAttack()
    {
        if (controller.isGrounded)
        {
        }

        animator.SetTrigger("attack");
        punch = true;
        Invoke("punchreset", 0.8f);
    }
    public void MoveAttack2()
    {
        if (controller.isGrounded)
        {
        }

        animator.SetTrigger("attack2");
        punch = true;
        Invoke("punchreset", 0.8f);
    }
    void punchreset()
    {
        punch = false;
    }
}
