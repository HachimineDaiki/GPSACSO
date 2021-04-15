using System.Collections;
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

    AudioSource audioSource;

    GameObject movesound;
    GameObject expsound;
    Player player;
    enemyMove enemymove;

    private bool sound3flg;

    int WaitTime;
        //WaitTimeR;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        movesound = GameObject.Find("musslepants2Unity");
        //expsound = GameObject.Find("enemy2.0");
        player = movesound.GetComponent<Player>();
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
                audioSource.PlayOneShot(sound2);
                WaitTime = 135;
            }

            if ((Input.GetKeyDown(KeyCode.X)) && (WaitTime == 0))
            {
                audioSource.PlayOneShot(sound2);
                WaitTime = 130;
            }

            if ((Input.GetButtonDown("Fire1")) && (WaitTime == 0))
            {
                audioSource.PlayOneShot(sound2);
                WaitTime = 135;
            }

            if ((Input.GetButtonDown("Fire2")) && (WaitTime == 0))
            {
                audioSource.PlayOneShot(sound2);
                WaitTime = 130;
            }
            //左右移動音
            if (Input.GetKeyDown("left")) audioSource.PlayOneShot(sound3);

            if (Input.GetKeyDown("right")) audioSource.PlayOneShot(sound3);
        }
        if(sound3flg == false)
        {
            if (player.MoveFlg == true) audioSource.PlayOneShot(sound3);
            sound3flg = true;
        }
        if (player.MoveFlg == false) sound3flg = false;

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