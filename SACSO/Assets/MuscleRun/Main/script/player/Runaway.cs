﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public class Runaway : MonoBehaviour
{
    Slider _slider;
    public bool DushFlg;
    float _hp;

    [SerializeField] private GameObject Dush;


    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        DushFlg = false;
        _hp = 0; PaticleAc();
    }

    void FixedUpdate()
    {
        
        //if (_hp > 1 && !DushFlg)
        //{
        //    DushFlg = true;
        //    Invoke("Refresh", DushTime);
        //}
        //else
        //{
        //    _hp += 0.05f * Time.deltaTime;
        //}

        if(_hp >= 1f)       //ゲージがMAXになったら
        {
            DushFlg = true;
        }
        else if(_hp <= 0)       //ゲージが0になったら
        {
            DushFlg = false;
        }

        if (DushFlg)        //tureならダッシュ状態
        {
            PaticleAc();
            _hp -= 0.1f * Time.deltaTime;
        }
        else　           　 //falseなら通常状態
        {
            ParticleNotAc();
            _hp += 0.05f * Time.deltaTime;
        }

        // HPゲージに値を設定
        _slider.value = _hp;
    }

    void Refresh()
    {
        _hp = 0f;
        DushFlg = false;
    }

    void PaticleAc()
    {
        Dush.SetActive(true);
    }

    void ParticleNotAc()
    {
        Dush.SetActive(false);
    }
}
