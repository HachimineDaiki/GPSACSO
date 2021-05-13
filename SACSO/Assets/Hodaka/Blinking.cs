using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    [SerializeField] GameObject text;
    private float nextTime;
    public float interval=0.8F;

    // Update is called once per frame
    private void Start()
    {
        nextTime = Time.time;
    }

    void Update()
    {
        if(Time.time > nextTime)
        {
            float alpha = text.GetComponent<CanvasRenderer>().GetAlpha();
            if (alpha == 1.0f)
                text.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
            else
                text.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
            nextTime += interval;
        }
    }
}
