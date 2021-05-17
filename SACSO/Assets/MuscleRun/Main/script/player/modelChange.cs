using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelChange : MonoBehaviour
{
    public GameObject[] models = new GameObject[9];
    // Start is called before the first frame update

    public int[] punchNum = new int[2];        //0:右パンチ1:左パンチ のヒット回数
    public int[] ArmInfo = new int[2];         //0:右手1:左手 の状態
    static int EvoTimes = 5;                    //腕の進化までの回数

    public int NowModelNum;

    /// <Summary>
    /// 殴りのタイプ 0:右手1:左手 
    /// </Summary>
    public int AttacInfo;

    /// <Summary>
    /// パンチが当たったか
    /// </Summary>
    public bool HitFlg;

    [SerializeField] private GameObject LevelUP;

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
        PatNotActive();

    }

    private void FixedUpdate()
    {

        muscleup = false;

        if (HitFlg) punchHit();


    }

    void punchHit()
    {
        if(++punchNum[AttacInfo] > EvoTimes)
        {
            punchNum[AttacInfo] = 0;
            if (++ArmInfo[AttacInfo] >= 3) ArmInfo[AttacInfo] = 2;
            PlayerChange();
        }
        HitFlg = false;
    }

    void PlayerChange()
    {
        int modelNum =( ArmInfo[0] * 3) + ArmInfo[1];
        PatActive();
        Invoke("PatNotActive", 4f);

        //モデルの差し替え
        if (modelNum != NowModelNum)
        {
            models[modelNum].SetActive(true);
            models[NowModelNum].SetActive(false);
        }

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

    void PatActive()
    {
        LevelUP.SetActive(true);
    }

    void PatNotActive()
    {
        LevelUP.SetActive(false) ;
    }
}
