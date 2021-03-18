using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scorePointText;//数字用
    public Text score;//スコアの文字用（後で画像に差し替え推奨）
    public int point = 0;
    // Update is called once per frame
    void ScoreUpdate()
    {
        scorePointText.text = point.ToString("000000");
    }
}
