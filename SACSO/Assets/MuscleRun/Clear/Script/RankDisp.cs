using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        //スコア用変数の加算処理　上から順にスコア+右筋肉スコア+左筋肉スコア
        ScorePoint = 
            PlayerPrefs.GetInt("Score",   0) + 
            PlayerPrefs.GetInt("rpumpup", 0) * 500 + PlayerPrefs.GetInt("RPunchCt", 0) * 100 +
            PlayerPrefs.GetInt("lpumpup", 0) * 500 + PlayerPrefs.GetInt("LPunchCt", 0) * 100;

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
    }

    // Update is called once per frame
    void Update()
    {
        //スコアで評価分岐
        if(ScorePoint >= SCOREMAX)
        {
            rank_S.gameObject.SetActive(true);
        }
        else if(ScorePoint >= SCOREMAX *0.8)
        {
            rank_A.gameObject.SetActive(true);
        }
        else if (ScorePoint >= SCOREMAX *0.65)
        {
            rank_B.gameObject.SetActive(true);
        }
        else
        {
            rank_C.gameObject.SetActive(true);
        }
    }
}
