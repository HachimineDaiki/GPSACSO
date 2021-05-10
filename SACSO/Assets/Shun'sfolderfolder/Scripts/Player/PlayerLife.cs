﻿/////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int Life;
    [SerializeField] private const int MaxLife = 3;
    private bool muteki;
    private float mutekiTime;

    private ScoreCon SC;//ScoreCon.scの参照　こいつの書き方が分からないので大文字にしました　許してください


    void Start()
    {
        SC = GameObject.Find("GameManeger").GetComponent<ScoreCon>();
        Life = MaxLife;
        muteki = false;
    }
    private void FixedUpdate()
    {
        MutekiCon();
    }

    // Update is called once per frame

    public void Damege()
    {
        Life--;

        //ヒットすると無敵時間を設定
        muteki = true;
        mutekiTime = 2.0f;

        if (Life <= 0)
        {
            //スコアを記録する
            SC.ScoreSave();
            //ゲームオーバーへ
            SceneManager.LoadScene("GameOver");
        }
    }

    private void MutekiCon()
    {
        if(mutekiTime > 0)
        {
            mutekiTime -= Time.deltaTime;
            if (mutekiTime <= 0) muteki = false;
        }
    }
}

/////////////////////