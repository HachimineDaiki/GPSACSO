﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;

    public AudioSource audioSource;
    public AudioSource audiosource2;

    GameObject movesound;
    GameObject gamemanager;
    Hitaudiocon hitflg;
    NewPlayer newplayer;
    PauseScript pausescript;

    private bool sound2flg;

    //Playerの親からモデルを取得
    private modelChange Mc;

    //int WaitTime;
        //WaitTimeR;

    void Start()
    {
        //Componentを取得
        movesound = GameObject.FindGameObjectWithTag("PlayerParent");

        newplayer = GetPlayerModel().GetComponent<NewPlayer>();


        gamemanager = GameObject.Find("GameManeger");
        //expsound = GameObject.Find("enemy2.0");
        pausescript = gamemanager.GetComponent<PauseScript>();
        hitflg = gamemanager.GetComponent<Hitaudiocon>();
        //enemymove = expsound.GetComponent<enemyMove>();

        //WaitTime = 0;
        //WaitTimeR = 0;
    }

    void Update()
    {

        newplayer = GetPlayerModel().GetComponent<NewPlayer>();
        if (newplayer.punch == true && sound2flg == false)
        {
            sound2flg = true;
            audiosource2.PlayOneShot(sound2);
        }
        if (newplayer.punch == false && sound2flg == true) sound2flg = false;

        if (pausescript.pauseflg == true)
        {
            audioSource.Pause();
            audiosource2.Pause();
        }

        if (pausescript.pauseflg == false)
        {
            audioSource.UnPause();
            audiosource2.UnPause();
        }

        if (hitflg.Hitflg == true)
        {
            hitflg.Hitflg = false;
            audiosource2.PlayOneShot(sound4);
            Invoke("expsoundplay", 1.5f);
        }
    }



    private void expsoundplay()
    {
        audiosource2.PlayOneShot(sound1);
    }

    GameObject GetPlayerModel()
    {

        //書くね！
        //初期のプレイヤーのモデルのNewPlayerの取得
        Mc = movesound.GetComponent<modelChange>();

        return Mc.models[Mc.NowModelNum];

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