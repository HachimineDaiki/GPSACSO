using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelChange : MonoBehaviour
{
    private GameObject[] models = new GameObject[9];
    // Start is called before the first frame update

    private int[] punchNum = new int[2];        //0:右パンチ1:左パンチ のヒット回数
    private int[] ArmInfo = new int[2];         //0:右手1:左手 の状態
    static int EvoTimes = 5;                    //腕の進化までの回数

    private int NowModelNum;

    /// <Summary>
    /// 殴りのタイプ 0:右手1:左手 
    /// </Summary>
    public int AttacInfo;

    /// <Summary>
    /// パンチが当たったか
    /// </Summary>
    public bool HitFlg;


    public bool muscleup;//カットイン（catinscript用のフラグ）
    public bool plt; //筋肉点数用フラグ
    public bool prt; //筋肉点数用フラグ

    void Start()
    {
        int i = 0;
        foreach (Transform child in gameObject.transform)
        {
            if(child.tag == "Player")
            {
                models[i] = child.gameObject;
                if (i++ != 0) child.gameObject.SetActive(false);
            }
            if (i >= 9) break;
        }
        punchNum[0] = 0;
        punchNum[1] = 0;

        ArmInfo[0] = 0;     //右手
        ArmInfo[1] = 0;     //左手

        NowModelNum = 0;   //今のモデルの要素番号:初期値０

        HitFlg = false;
    }

    private void FixedUpdate()
    {
        if (HitFlg) punchHit();
    }

    void punchHit()
    {
        if(++punchNum[AttacInfo] > EvoTimes)
        {
            ArmInfo[AttacInfo]++;
            PlayerChange();
        }
        HitFlg = false;
    }

    void PlayerChange()
    {
        int modelNum = ArmInfo[0] + ArmInfo[1] * 3;

        //モデルの差し替え
        models[modelNum].SetActive(true);
        models[NowModelNum].SetActive(false);

        //今のモデルの要素番号
        NowModelNum = modelNum;


        //カットイン用
        if(AttacInfo == 0)
        {
            muscleup = true;
            prt = true;
        }
        else
        {
            muscleup = true;
            plt = true;
        }

    }
}
