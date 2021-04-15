///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    private int scorePoint;//スコア用変数
    private Text scorePointText;//スコアのテキスト

    // Start is called before the first frame update
    void Start()
    {
        //スコアのテキスト取得
        scorePointText = GameObject.Find("ScorePointText").GetComponent<Text>();
        //スコア取得
        scorePoint = PlayerPrefs.GetInt("Score", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scorePointText.text = scorePoint.ToString("000000");
    }
}

//////////////////////////////////