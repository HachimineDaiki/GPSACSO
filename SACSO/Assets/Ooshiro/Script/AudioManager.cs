﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip sound1; //
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;

    public AudioSource audioSource;
    public AudioSource audiosource2;

    GameObject movesound;
    GameObject gamemanager;
    Player player;
    PauseScript pausescript;

    private bool sound3flg;

    int WaitTime;
        //WaitTimeR;

    void Start()
    {
        //Componentを取得
        // audioSource = GetComponent<AudioSource>();
        movesound = GameObject.Find("musslepants2Unity");
        gamemanager = GameObject.Find("GameManeger");
        //expsound = GameObject.Find("enemy2.0");
        player = movesound.GetComponent<Player>();
        pausescript = gamemanager.GetComponent<PauseScript>();
        //enemymove = expsound.GetComponent<enemyMove>();

        WaitTime = 0;
        //WaitTimeR = 0;
    }

    void Update()
    {

        if (WaitTime > 0) WaitTime--;
        //if (WaitTimeR > 0) WaitTimeR--;
        // 攻撃音
        {
            if ((Input.GetKeyDown(KeyCode.Z)) && (WaitTime == 0))
            {
                audiosource2.PlayOneShot(sound2);
                WaitTime = 135;
            }

            if ((Input.GetKeyDown(KeyCode.X)) && (WaitTime == 0))
            {
                audiosource2.PlayOneShot(sound2);
                WaitTime = 130;
            }

            if ((Input.GetButtonDown("Fire1")) && (WaitTime == 0))
            {
                audiosource2.PlayOneShot(sound2);
                WaitTime = 135;
            }

            if ((Input.GetButtonDown("Fire2")) && (WaitTime == 0))
            {
                audiosource2.PlayOneShot(sound2);
                WaitTime = 130;
            }
            //左右移動音
            if (Input.GetKeyDown("left")) audiosource2.PlayOneShot(sound3);

            if (Input.GetKeyDown("right")) audiosource2.PlayOneShot(sound3);
        }
        if(sound3flg == false)
        {
            if (player.MoveFlg == true) audiosource2.PlayOneShot(sound3);
            sound3flg = true;
        }
        if (player.MoveFlg == false) sound3flg = false;

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
        

        //if (enemymove.KillFlg == true)
        //{
        //    audioSource.PlayOneShot(sound4);
        //    Invoke("expsoundplay", 1.5f);
        //}
    }



    //private void expsoundplay()
    //{
    //    audioSource.PlayOneShot(sound1);
    //}
}