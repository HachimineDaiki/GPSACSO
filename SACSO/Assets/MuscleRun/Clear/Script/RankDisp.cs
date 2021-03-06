﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankDisp : MonoBehaviour
{
    //各ランクのイメージ取得
    private Image rank_C;
    private Image rank_B;
    private Image rank_A;
    private Image rank_S;
    //スコア用変数
    private int ScorePoint;
    private int SCOREMAX = 30000;
    [SerializeField] private Text ScoerText;
    //スコア用フラグ
    private bool scoreMaxFlg;

    // Start is called before the first frame update
    void Start()
    {
        //スコア用変数の加算処理　上から順にスコア+右筋肉スコア+左筋肉スコア
        ScorePoint = 
            PlayerPrefs.GetInt("Score",   0) + 
            (PlayerPrefs.GetInt("rpumpup", 0) * 5000 + PlayerPrefs.GetInt("RPunchCt", 0) * 100) +
            (PlayerPrefs.GetInt("lpumpup", 0) * 5000 + PlayerPrefs.GetInt("LPunchCt", 0) * 100);
        Debug.Log(ScorePoint);

        if (ScorePoint >= 100000) ScorePoint = 99999;

        //画像読み込み
        rank_A = GameObject.Find("Image(A)").GetComponent<Image>();
        rank_B = GameObject.Find("Image(B)").GetComponent<Image>();
        rank_C = GameObject.Find("Image(C)").GetComponent<Image>();
        rank_S = GameObject.Find("Image(S)").GetComponent<Image>();

        //一度全ての画像を非表示にする
        rank_A.gameObject.SetActive(false);
        rank_B.gameObject.SetActive(false);
        rank_C.gameObject.SetActive(false);
        rank_S.gameObject.SetActive(false);

        ScoerText.text = ScorePoint.ToString("00000") + "点";

        scoreMaxFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        int rp,lp;
        rp = (PlayerPrefs.GetInt("rpumpup", 0) * 50 + PlayerPrefs.GetInt("RPunchCt", 0) * 10);
        lp = (PlayerPrefs.GetInt("lpumpup", 0) * 50 + PlayerPrefs.GetInt("LPunchCt", 0) * 10);
        //腕が片方だけムキムキ（2段階）の場合、点数の幅を増やす
        if ( (rp - lp >= 100 || lp - rp >= 100) && scoreMaxFlg == false)
        {
            ScorePoint -= 5000;
            scoreMaxFlg = true;
        }
        //点数のランク確認
        if(ScorePoint >= SCOREMAX)
        {
            rank_S.gameObject.SetActive(true);
        }
        else if(ScorePoint >= SCOREMAX *0.7)
        {
            rank_A.gameObject.SetActive(true);
        }
        else if (ScorePoint >= SCOREMAX *0.5)
        {
            rank_B.gameObject.SetActive(true);
        }
        else
        {
            rank_C.gameObject.SetActive(true);
        }
    }
}
