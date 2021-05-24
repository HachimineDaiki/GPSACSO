using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoramuCon : MonoBehaviour
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

    // Update is called once per frame
    void FixedUpdate()
    {


        if (!KillFlg)
        {
            Move();
        }
        else
        {
            Damege();
        }
    }

    private void Move()
    {

    }

    private void Damege()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AttackDet"))
        {
            KillFlg = true;
            score.AddPoint(100);
            rb.freezeRotation = false;
            Mc.HitFlg = true;
        }

        if (other.name == "PlayerDet")
        {
            if (runaway.DushFlg)
            {
                KillFlg = true;
                score.AddPoint(100);
            }
            else
            {
                playerLife.Damege();
            }
        }
    }
}
