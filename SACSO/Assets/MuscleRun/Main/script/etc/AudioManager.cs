using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip sound1;            //爆発音
    public AudioClip sound2;            //パンチ音（素振り
    public AudioClip sound3;            //左右移動音（使ってません）
    public AudioClip sound4;            //パンチヒット音
    public AudioClip sound5;            //ウルトラマッスルモード中の掛け声
    public AudioClip sound6;            //マッチョ
    public AudioClip sound7;            //ランダムボイス１
    public AudioClip sound8;            //ランダムボイス２
    public AudioClip sound9;            //ランダムボイス３
    public AudioClip sound10;           //ランダムボイス４
    public AudioClip sound11;           //マッスルゲージMAX

    public AudioSource audioSource;     //BGM用のオーディオソース
    public AudioSource audiosource2;    //SE用のオーディオソース

    private float random;

    GameObject movesound;               
    GameObject gamemanager;
    //GameObject expsound;
    //Hitaudiocon hitflg;
    NewPlayer newplayer;
    PauseScript pausescript;
    Runaway runaway;
    //Blowaway blowaway;


    private bool sound2flg;             //素振りが重複しないためのフラグ
    private bool voiceflg;
    private bool sound11flg;

    //Playerの親からモデルを取得
    private modelChange Mc;

    //
    private float S5StartTime,S5EndTime;
    private float S6StartTime,S6EndTime;
    private bool S5flg;
    private bool S6flg;

    //int WaitTime;
        //WaitTimeR;

    void Start()
    {
        //Componentを取得
        movesound = GameObject.FindGameObjectWithTag("PlayerParent");
        gamemanager = GameObject.Find("GameManeger");                   //ゲームマネージャーを探す

        newplayer = GetPlayerModel().GetComponent<NewPlayer>();         //プレイヤー.csのコンポーネント取得
        pausescript = gamemanager.GetComponent<PauseScript>();          //ゲームマネージャーのポーズ.cs取得
        runaway = gamemanager.GetComponent<Runaway>();
        //expsound = GameObject.Find("enemy2.0");
        //hitflg = gamemanager.GetComponent<Hitaudiocon>();
        //enemymove = expsound.GetComponent<enemyMove>();

        //WaitTime = 0;
        //WaitTimeR = 0;
        S5flg = true;
    }

    void Update()
    {

        newplayer = GetPlayerModel().GetComponent<NewPlayer>();
        if (Mc.muscleup == true && voiceflg == false)
        {
            Invoke("RandomVoice", 1f);
            voiceflg = true;
        }
        if (Mc.muscleup == false) voiceflg = false;

        if (sound2flg == false)                             //一度も素振りが鳴ってなかったら
        {
            if (newplayer.PunchCon == true)                 //パンチのアニメーション中なら
            {
                sound2flg = true;                           //フラグをオンに
                audiosource2.PlayOneShot(sound2);           //一度だけ鳴らす
            }
        }
        if (newplayer.PunchCon == false) sound2flg = false; //パンチのアニメーションが終わったらフラグをオフに

        if(runaway.DushFlg == true && sound11flg == false)
        {
            audiosource2.PlayOneShot(sound11);
            sound11flg = true;
        }

        if (runaway.DushFlg == false && sound11flg == true) sound11flg = false;

        if (pausescript.pauseflg == true)                   //ポーズ中なら音も止める
        {
            audioSource.Pause();
            audiosource2.Pause();
        }

        if (pausescript.pauseflg == false)                  //ポーズが終わったら音を再生（途中で途切れたら続きから
        {
            audioSource.UnPause();
            audiosource2.UnPause();
        }

        //expsound = GameObject.Find("DamageDrum(Clone)");
        //if (expsound != null)
        //{
        //    blowaway = expsound.GetComponent<Blowaway>();
        //    if (blowaway.KillSEflg == true)
        //    {
        //        audiosource2.PlayOneShot(sound4);
        //        Invoke("expsoundplay",1.5f);
        //        Debug.Log("おぉん");
        //        blowaway.KillSEflg = false;
        //    }
        //}
    }



    //private void expsoundplay()
    //{
    //    audiosource2.PlayOneShot(sound1);
    //}
    private void RandomVoice()
    {
        random = Random.Range(1.0f,40.0f);
        
        if (random < 10) audiosource2.PlayOneShot(sound7);

        if (random > 10 && random < 20) audiosource2.PlayOneShot(sound8);

        if (random > 20 && random < 30) audiosource2.PlayOneShot(sound9);

        if (random > 30 && random < 40) audiosource2.PlayOneShot(sound10);
    }

    GameObject GetPlayerModel()
    {

        //書くね！
        //初期のプレイヤーのモデルのNewPlayerの取得
        Mc = movesound.GetComponent<modelChange>();

        return Mc.models[Mc.NowModelNum];

    }

    public void MensPlay()
    {
        if (S5flg)      //最初に入る
        {
            S5StartTime = Time.time;

            audiosource2.PlayOneShot(sound5);
            S5flg = false;
        }

        if (sound5.length + S5StartTime - 1f <= Time.time)       //終了判定
        {
            S5flg = true;
        }

        random = Random.Range(1f, 10f);

        if(S6flg && random > 9)
        {
            S6StartTime = Time.time;

            audiosource2.PlayOneShot(sound6,0.5f);
            S6flg = false;
        }

        if (sound6.length + S6StartTime <= Time.time)
        {
            S6flg = true;
        }
    }

    public void Se5Ref()
    {
        S5flg = true;
    }
}


//if (WaitTime > 0) WaitTime--;
//if (WaitTimeR > 0) WaitTimeR--;
// 攻撃音
//{
//if ((Input.GetKeyDown(KeyCode.Z)) && (WaitTime == 0))
//{
//    audiosource2.PlayOneShot(sound2);
//    WaitTime = 135;
//}

//if ((Input.GetKeyDown(KeyCode.X)) && (WaitTime == 0))
//{
//    audiosource2.PlayOneShot(sound2);
//    WaitTime = 130;
//}

//if ((Input.GetButtonDown("Fire1")) && (WaitTime == 0))
//{
//    audiosource2.PlayOneShot(sound2);
//    WaitTime = 135;
//}

//if ((Input.GetButtonDown("Fire2")) && (WaitTime == 0))
//{
//    audiosource2.PlayOneShot(sound2);
//    WaitTime = 130;
//}
//左右移動音
//if (Input.GetKeyDown("left")) audiosource2.PlayOneShot(sound3);

//if (Input.GetKeyDown("right")) audiosource2.PlayOneShot(sound3);
//}
//if(sound3flg == false)
//{
//    if (player.MoveFlg == true) audiosource2.PlayOneShot(sound3);
//    sound3flg = true;
//}
//if (player.MoveFlg == false) sound3flg = false;