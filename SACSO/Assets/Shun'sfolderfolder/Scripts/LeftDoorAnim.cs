using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorAnim : MonoBehaviour
{
    //　ドアのアニメーター
    private Animator animator;
    private bool NextState;

    void Start()
    {
        // 親のAnimatorを取得
        animator = transform.parent.GetComponent<Animator>();
        NextState = true;
    }

    /// <summary>
    /// 自動ドア検知エリアに入った時
    /// </summary>
    /// <param name="other"></param>
	private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // アニメーションパラメータをNextStateにする。(ドアを開閉する) true:開く false:閉まる
            animator.SetBool("Open", NextState);

            //次のステートに変更
            if (NextState) NextState = false;
            else NextState = true;
        }
        
    }


}
