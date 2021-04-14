using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;

    AudioSource audioSource;

    int WaitTime;
        //WaitTimeR;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

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
    }
}