using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_DoramuCon : MonoBehaviour
{

    private PlayerLife playerLife;
    private ScoreCon score;
    private modelChange Mc;

    [SerializeField] GameObject BreakObj;          //こわれたオブジェクトのモデル
    [SerializeField] GameObject Flare;           //当たったときのエフェクト

    public bool KillFlg;       //殴られた判定
    Rigidbody rb;

    private Runaway runaway;

    // Use this for initialization
    void Start()
    {
        //enemyaudio = gameObject.AddComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        KillFlg = false;

        runaway = GameObject.Find("GameManeger").GetComponent<Runaway>();
        score = GameObject.Find("GameManeger").GetComponent<ScoreCon>();
        playerLife = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<PlayerLife>();
        Mc = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<modelChange>();

    }
    private void Damege()
    {
        // クォータニオン → オイラー角への変換
        Vector3 rotationAngles = transform.rotation.eulerAngles;
        rotationAngles.x -= 90;

        //吹っ飛ぶ
        var pos = (transform.TransformPoint(transform.localPosition.x,
                                            transform.localPosition.y + 15,
                                            transform.localPosition.z));
       
        Instantiate(BreakObj, transform.position, transform.rotation);
        Instantiate(Flare, pos, Quaternion.Euler(rotationAngles));
        KillFlg = false;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!KillFlg)       //倒されていない状態のときのみ
        {
            if (other.CompareTag("AttackDet"))
            {
                //プレイヤーの攻撃の当たり判定
                KillFlg = true;
                score.AddPoint(500);
                rb.freezeRotation = false;
                Mc.HitFlg = true;
                Mc.BonusHit = true;
                Damege();
            }

            if (other.name == "PlayerDet")
            {
                //プレイヤーの当たり判定
                if (runaway.DushFlg)    //無敵中
                {
                    KillFlg = true;
                    score.AddPoint(500);
                    Damege();
                }
                else
                {
                    playerLife.Damege();
                }
                if (playerLife.Life == 0)
                {
                    // クォータニオン → オイラー角への変換
                    Vector3 rotationAngles = transform.rotation.eulerAngles;
                    rotationAngles.x -= 90;

                    var pos = (transform.TransformPoint(transform.localPosition.x,
                                                        transform.localPosition.y + 15,
                                                        transform.localPosition.z));

                    Instantiate(BreakObj, transform.position, transform.rotation);
                    Instantiate(Flare, pos, Quaternion.Euler(rotationAngles));
                    KillFlg = false;
                    this.gameObject.SetActive(false);
                }
            }
        }
        
    }
}
