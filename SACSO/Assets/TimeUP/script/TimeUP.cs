using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeUP : MonoBehaviour
{
    const float LimitTime = 0f;       //時間制限（１２０秒）
    private float ElapsedTime;          //経過時間
    [SerializeField] GameObject TimePanel;

    [SerializeField]
    private int minute;
    [SerializeField]
    private float seconds;
    //　前のUpdateの時の秒数
    private float oldSeconds;
    //　タイマー表示用テキスト
    private Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 1;
        oldSeconds = 0f;
        ElapsedTime = 1;
        TimePanel.SetActive(false);
        timerText = GetComponentInChildren<Text>();

        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeCnt();
        if (TimePanel.activeSelf) Time.timeScale = 0f;
        else Time.timeScale = 1f;

        seconds -= Time.deltaTime;

        if (seconds <= 0f && minute > 0)
        {
            minute--;
            seconds = seconds + 60;
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = "残り" +  minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;

    }

    void TimeCnt()
    {
        //経過時間にフレームごとの時間をたす
        ElapsedTime -= Time.deltaTime;

        TimeCheck();
    }
    void TimeCheck()
    {
        if (ElapsedTime <= LimitTime)//経過時間が時間制限を超えたら
        {
            TimePanel.SetActive(true);
        }
    }
}
