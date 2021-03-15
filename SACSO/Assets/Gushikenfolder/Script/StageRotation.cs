using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRotation : MonoBehaviour
{
    //キャラクターの指定をできるようにする
    public Transform character;

    //ステージチップの配列
    public GameObject[] stageTips;


    //ゲーム開始時のポジション
    private Vector3 startPos;  

    //移動するスピード
    public float speed=2.0f;



    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        transform.position = new Vector3(startPos.x, startPos.y, startPos.z -= 5);
    }


}
