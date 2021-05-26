using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeUP : MonoBehaviour
{
    const float LimitTime = 120f;       //時間制限（１２０秒）
    private float ElapsedTime;          //経過時間
    [SerializeField]GameObject TimePanel;


    // Start is called before the first frame update
    void Start()
    {
        ElapsedTime = 0;
        TimePanel.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeCnt();
        if (TimePanel.activeSelf) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }

    void TimeCnt()
    {
        //経過時間にフレームごとの時間をたす
        ElapsedTime += Time.deltaTime;

        TimeCheck();
    }
    void TimeCheck()
    {
        if(ElapsedTime >= LimitTime)//経過時間が時間制限を超えたら
        {
            TimePanel.SetActive(true);
        }
    }
}
