using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDM_SE : MonoBehaviour
{

    [SerializeField] private AudioClip EDM;
    AudioSource audiosouce;
    private float StartTime;
    private bool flg;

    // Start is called before the first frame update
    void Start()
    {
        StartTime = 0f;
        flg = true;
        audiosouce = GameObject.Find("Main Camera").GetComponent<AudioManager>().audiosource2;
    }

    // Update is called once per frame
    void Update()
    {
        if (flg)
        {
            StartTime = Time.time;
            audiosouce.PlayOneShot(EDM, 0.1f) ;
            flg = false;
        }
        else
        {
            if(StartTime + EDM.length < Time.time + Time.deltaTime)
            {
                flg = true;
            }
        }
    }
}
