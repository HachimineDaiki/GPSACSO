using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] private float speed = 3.0f;        //敵の移動速度
    [SerializeField] private float distance;
    [SerializeField] private Vector3 StartPosition;

    private Runaway runaway;
    private PlayerLife playerLife;


    private bool KillFlg;       //殴られた判定
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = new Vector3(transform.position.x, transform.position.y, -90f);    //ターゲットの座標
        KillFlg = false;
        distance = 0f;
        StartPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speed = Random.Range(2.0f, 5.5f);

        runaway = GameObject.Find("GameManeger").GetComponent<Runaway>();
        playerLife = GameObject.Find("MuscleHuman").GetComponent<PlayerLife>();

    }

    // Update is called once per frame
    void Update()
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
        float Dushspd = 1.0f;
        if (runaway.DushFlg) Dushspd = 3.0f;

        if (distance <= 1f)
        {
            distance += (Time.deltaTime / speed) * Dushspd;
        }
        else
        {
            distance = 1f;
        }
        transform.position = Vector3.Lerp(StartPosition, direction, distance);
        transform.Rotate(Vector3.right * 5.0f, Space.World);
        if (distance >= 1.0f) Destroy(gameObject);

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
