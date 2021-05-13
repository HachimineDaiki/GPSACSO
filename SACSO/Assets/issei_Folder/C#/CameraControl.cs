using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject g_player;   //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用
    private GameObject player;
    private Vector3 prevPlayerPos;
    private Vector3 posVector;
    public float scale = 3.0f;
    public float cameraSpeed = 1.0f;
    public float angle = 80.0f;

    public bool cameraflg = false;
    public bool clearflg = false;

    // Use this for initialization
    void Start()
    {
       
         player = GameObject.FindGameObjectWithTag("PlayerParent");
         prevPlayerPos = new Vector3(0, 0, -1);

        //unitychanの情報を取得
        this.g_player = GameObject.FindGameObjectWithTag("PlayerParent");

        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - g_player.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(clearflg == true)
        {
            //unitychanの情報を取得
            this.g_player = GameObject.FindGameObjectWithTag("PlayerParent");

            // MainCamera(自分自身)とplayerとの相対距離を求める
            offset = transform.position - g_player.transform.position;

            clearflg = false;
        }

        if (cameraflg == true)
        {
            Vector3 currentPlayerPos = player.transform.position;
            Vector3 backVector = (prevPlayerPos - currentPlayerPos).normalized;
            posVector = (backVector == Vector3.zero) ? posVector : backVector;
            Vector3 targetPos = currentPlayerPos + scale * posVector;
            targetPos.y = targetPos.y + angle;
            this.transform.position = Vector3.Lerp(
                this.transform.position,
                targetPos,
                cameraSpeed * Time.deltaTime
            );
            this.transform.LookAt(player.transform.position);
            prevPlayerPos = player.transform.position;
        } else 
        {
            //新しいトランスフォームの値を代入する
            transform.position = g_player.transform.position + offset;
        }

    }
}

