using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SEController : MonoBehaviour
{
    //[SerializeField] GameObject seslider;
    [SerializeField] Slider slider2;

    [SerializeField]
    private AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        //seslider = GameObject.Find("Canvas/Panel2/SESlider");
        //slider2 = seslider.GetComponent<Slider>();

        float maxvolume = 10f;
        float nowvolume = -10f;

        slider2.maxValue = maxvolume;
        slider2.value = nowvolume;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SEvol", volume);
    }
    public void Method()
    {
        Debug.Log("現在値：" + slider2.value);

        if (slider2.value >= 50)
        {
            Debug.Log("50以上です");
        }

    }

}