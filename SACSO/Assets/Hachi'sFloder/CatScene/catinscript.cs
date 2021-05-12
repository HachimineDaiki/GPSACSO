using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class catinscript : MonoBehaviour
{
   private Animator animator;
   private modelChange Mc;

    private void Start() {
        animator = GetComponent<Animator>();
        Mc = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<modelChange>();
    }



    private void Update() {
        if (Mc.muscleup) {
            animator.SetTrigger("ms");
            Debug.Log("勝ったな！！");
        }
    }

}
