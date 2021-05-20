using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class StoryText : MonoBehaviour
{
    [SerializeField] List<string> messageList = new List<string>();//会話文リスト
    [SerializeField] Text text;
    [SerializeField] float novelSpeed;//一文字一文字の表示する速さ
    [SerializeField] float NextLineTime;  //次の行に進む時間

    public GameObject Cam1, Cam2, Cam3;  //opシーンで使われているカメラ1番目、2番目、3番目
    public GameObject OpObj,OpObj2,OpObj3;   //2シーン目のゼイバスを格納します

    int novelListIndex = 0; //現在表示中の会話文の配列
    private float time;
    private bool LineComp;

    public int SceneCnt,LineCnt;


    void Start()
    {

        LineComp = false;
        SceneCnt = 0;
        LineCnt = 0;
        StartCoroutine(Novel());
    }

    private void FixedUpdate()
    {
        if (LineComp)
        {
            NextLine();
        }

        if(LineCnt <= 7)
        {
            SceneCnt = 0;
        }
        else if(LineCnt == 8)
        {
            SceneCnt = 1;
            NextLineTime = 3.0f;
        }
        else
        {
            SceneCnt = 2;
            NextLineTime = 0.5f;
        }


        //シーン内のカメラの切り替えをする
        if (SceneCnt == 1)
        {
            Cam1.SetActive(false);
            OpObj2.SetActive(true);
        }
        else if (SceneCnt == 2)
        {

            Cam2.SetActive(false);
            OpObj3.SetActive(true);
            
        }



    }


    private IEnumerator Novel()
    {
        int messageCount = 0; //現在表示中の文字数
        text.text = ""; //テキストのリセット
        while (messageList[novelListIndex].Length > messageCount)//文字をすべて表示していない場合ループ
        {
            text.text += messageList[novelListIndex][messageCount];//一文字追加
            messageCount++;//現在の文字数
            yield return new WaitForSeconds(novelSpeed);//任意の時間待つ
        }

        novelListIndex++; //次の会話文配列
        if (novelListIndex < messageList.Count)//全ての会話を表示したか
        {
            time = Time.time;
            LineComp = true;
            LineCnt++;
            if (LineCnt >= 12)
            {
                Invoke("ToMain", 5.0f);
            }
        }
    }

    void NextLine()
    {
        if ((Time.time - time) >= NextLineTime)
        {
            StartCoroutine(Novel());
            LineComp = false;
        }

    }
    void ToMain()
    {
        //メインへ
        SceneManager.LoadScene("Main");
    }
}
