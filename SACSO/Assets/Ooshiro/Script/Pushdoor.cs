using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pushdoor : MonoBehaviour
{
    private void PushEnemy()
    {
        //エネミーの吹き飛ばし処理を書くところ
    }
    private void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){//(今は仮にPlayer  //そのうちエネミーを入れるところ
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
        }
    }
    
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player"){
    //        this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
    //    }
    //}Exit処理いる？いらなくね？
}