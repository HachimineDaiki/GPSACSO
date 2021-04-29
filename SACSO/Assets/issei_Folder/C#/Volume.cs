using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Volume: MonoBehaviour
{
  //  [SerializeField] private Button ;

    Slider VolumeSlider;

    // Use this for initialization
    void Start()
    {

        VolumeSlider = GameObject.Find("Volume_Slider").GetComponent<Slider>();

        float maxHp = 100f;
        float nowHp = 100f;


        //スライダーの最大値の設定
        VolumeSlider.maxValue = maxHp;

        //スライダーの現在値の設定
        VolumeSlider.value = nowHp;


    }

    // Update is called once per frame
    void Update()
    {
        //if ()
        {

        }
    }


}
