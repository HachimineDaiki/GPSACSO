using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScore : MonoBehaviour
{
    private int scorePoint;//スコア用変数
    private Text scorePointText;//スコアのテキスト
    private int rightpoint;
    private int leftpoint;

    // Start is called before the first frame update
    void Start()
    {
        //スコアのテキスト取得
        scorePointText = GameObject.Find("ClearScore").GetComponent<Text>();
        //通常スコア
        scorePoint = PlayerPrefs.GetInt("Score", 0);
        //筋肉のスコア
        rightpoint = PlayerPrefs.GetInt("rpumpup", 0)*500;
        leftpoint = PlayerPrefs.GetInt("lpumpup", 0)*500;

        scorePoint += rightpoint + leftpoint;
    }

    // Update is called once per frame
    void Update()
    {
        scorePointText.text = "SCORE :"+scorePoint.ToString("000000");
    }
}
