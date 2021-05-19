using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class BGMController : MonoBehaviour
{
    //[SerializeField] GameObject bgmslider;
    [SerializeField] Slider slider;

    [SerializeField]
    private AudioMixer audioMixer;

    void Start()
    {
        
        //bgmslider = GameObject.Find("Canvas/Panel2/BGMSlider");
        //slider = bgmslider.GetComponent<Slider>();

        float maxvolume = 20f;
        float nowvolume = -5f;


        //スライダーの最大値の設定
        slider.maxValue = maxvolume;

        //スライダーの現在値の設定
        slider.value = nowvolume;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGMvol", volume);
    }

    public void Method()
    {
        Debug.Log("現在値：" + slider.value);

        if (slider.value >= 50)
        {
            Debug.Log("50以上です");
        }

    }

}