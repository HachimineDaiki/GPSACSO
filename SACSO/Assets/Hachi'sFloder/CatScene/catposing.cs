using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class catposing : MonoBehaviour
{
    private Animator poseanimator;//ポージングに使う。
    private PartsHuge muscleplay;//マッスルのポーズ動かすために使う。


    // Start is called before the first frame update
   private void Start()
    {
        poseanimator = GetComponent<Animator>();
        muscleplay = GameObject.Find("musslepants2Unity").GetComponent<PartsHuge>();
    }

    // Update is called once per frame
   private void Update()
    {
        if (muscleplay.muscleup) {
            poseanimator.SetTrigger("mcm");
            Debug.Log("動け！動けってんだよ！");
        }

    }
}
