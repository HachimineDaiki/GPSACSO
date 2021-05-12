using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    private Runaway runaway;
    private PlayerLife playerLife;


    private bool KillFlg;       //殴られた判定
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        runaway = GameObject.Find("GameManeger").GetComponent<Runaway>();
        playerLife = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<PlayerLife>();

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

        Vector3 vector3 = new Vector3(0f, 1.2f, 1.4f);
        rb.AddForce(vector3, ForceMode.Impulse);
        rb.AddTorque(Vector3.right * 3f, ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerDet" && !runaway.DushFlg)
        {
            playerLife.Damege();
        }

        if (other.name == "HitDet" && !runaway.DushFlg)
        {
            playerLife.Damege();
        }
    }
}
