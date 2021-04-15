using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCon : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;

    public Text Scoretext;
    void Start()
    {
        score = 0;
        Scoretext.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddPoint(int Point)
    {
        score += 100;
        Scoretext.text = "Score :" + score;
    }

    //スコアを記憶する
    public void ScoreSave()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
}
