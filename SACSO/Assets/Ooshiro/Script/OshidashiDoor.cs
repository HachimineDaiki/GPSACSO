using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OshidashiDoor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //if()ドアステータスを見るところ
        if (other.gameObject.tag == "Player"){//(今は仮にPlayer  //そのうちエネミーを入れるところ
            //this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
            //エネミーの吹き飛ばし処理を書くところ
        }
    }
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player"){
    //        this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
    //    }
    //}Exit処理いる？いらなくね？
}