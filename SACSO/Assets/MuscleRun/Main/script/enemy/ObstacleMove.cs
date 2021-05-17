using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    private Runaway runaway;
    private PlayerLife playerLife;

    private ScoreCon score;


    public GameObject explosion;

    private bool KillFlg;       //殴られた判定
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        runaway = GameObject.Find("GameManeger").GetComponent<Runaway>();
        score = GameObject.Find("GameManeger").GetComponent<ScoreCon>();
        playerLife = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<PlayerLife>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void Move()
    {
        
    }

    private void Damege()
    {
        rb = transform.GetComponent<Rigidbody>();

        transform.Rotate(270f, 0f, 0f);
        rb.AddForce(transform.forward * -800, ForceMode.Impulse);
        rb.AddForce(transform.up * -50, ForceMode.Impulse);
        rb.AddTorque(transform.right * 500);
        ExplosionSet();



        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerDet" && !runaway.DushFlg)
        {
            playerLife.Damege();
        }else if(other.name == "PlayerDet" && runaway.DushFlg)
        {
            score.AddPoint(200);
            Damege();
        }


        if (other.name == "HitDet" && !runaway.DushFlg)
        {
            playerLife.Damege();
        }
    }
    private void ExplosionSet()
    {
        GameObject obj = Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(obj, 2.5f);
    }
}
