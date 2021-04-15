using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class catinscript : MonoBehaviour
{
   private Animator animator;
   private PartsHuge muscleplay;

    private void Start() {
        animator = GetComponent<Animator>();
        muscleplay = GameObject.Find("musslepants2Unity").GetComponent<PartsHuge>();
    }



    private void Update() {
        if (muscleplay.muscleup) {
            animator.SetTrigger("ms");
            Debug.Log("勝ったな！！");
        }
    }

}
