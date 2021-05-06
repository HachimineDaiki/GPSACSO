using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //private GameObject player;   //プレイヤー情報格納用
    //private Vector3 offset;      //相対距離取得用
    private GameObject player;
    private Vector3 prevPlayerPos;
    private Vector3 posVector;
    public float scale = 3.0f;
    public float cameraSpeed = 1.0f;

    // Use this for initialization
    void Start()
    {
       
            player = GameObject.Find("musslepants2Unity");
            prevPlayerPos = new Vector3(0, 0, -1);
        
        ////unitychanの情報を取得
        //this.player = GameObject.Find("musslepants2Unity");

        //// MainCamera(自分自身)とplayerとの相対距離を求める
        //offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 currentPlayerPos = player.transform.position;
        Vector3 backVector = (prevPlayerPos - currentPlayerPos).normalized;
        posVector = (backVector == Vector3.zero) ? posVector : backVector;
        Vector3 targetPos = currentPlayerPos + scale * posVector;
        targetPos.y = targetPos.y + 50.0f;
        this.transform.position = Vector3.Lerp(
            this.transform.position,
            targetPos,
            cameraSpeed * Time.deltaTime
        );
        this.transform.LookAt(player.transform.position);
        prevPlayerPos = player.transform.position;
        ////新しいトランスフォームの値を代入する
        //transform.position = player.transform.position + offset;

    }
}

