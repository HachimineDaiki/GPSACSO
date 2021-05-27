using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreanime : MonoBehaviour
{
    private Animator clearanime;

    private int ScorePoint;
    private int SCOREMAX = 30000;
    // Start is called before the first frame update
    private bool scoreMaxFlg;
    void Start()
    {
        clearanime = GetComponent<Animator>();
        ScorePoint =
           PlayerPrefs.GetInt("Score", 0) +
           (PlayerPrefs.GetInt("rpumpup", 0) * 5000 + PlayerPrefs.GetInt("RPunchCt", 0) * 100) +
           (PlayerPrefs.GetInt("lpumpup", 0) * 5000 + PlayerPrefs.GetInt("LPunchCt", 0) * 100);

        scoreMaxFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        int rp, lp;
        rp = (PlayerPrefs.GetInt("rpumpup", 0) * 50 + PlayerPrefs.GetInt("RPunchCt", 0) * 10);
        lp = (PlayerPrefs.GetInt("lpumpup", 0) * 50 + PlayerPrefs.GetInt("LPunchCt", 0) * 10);
        //腕が片方だけムキムキ（2段階）の場合、点数の幅を増やす
        if ((rp - lp >= 100 || lp - rp >= 100) && scoreMaxFlg == false)
        {
            ScorePoint -= 5000;
            scoreMaxFlg = true;
        }
        //スコアで評価分岐
        if (ScorePoint >= SCOREMAX)
        {
            clearanime.SetTrigger("S");
        }
        else if (ScorePoint >= SCOREMAX * 0.7)
        {
            clearanime.SetTrigger("A");
        }
        else if (ScorePoint >= SCOREMAX * 0.5)
        {
            clearanime.SetTrigger("B");
        }
        else
        {
            clearanime.SetTrigger("C");
        }
    }
}
