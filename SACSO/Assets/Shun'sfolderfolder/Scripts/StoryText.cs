using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour
{
    [SerializeField] List<string> messageList = new List<string>();//会話文リスト
    [SerializeField] Text text;
    [SerializeField] float novelSpeed;//一文字一文字の表示する速さ
    [SerializeField] float NextLineTime;  //次の行に進む時間
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
}
