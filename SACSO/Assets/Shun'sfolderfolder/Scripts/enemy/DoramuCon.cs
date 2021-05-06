using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoramuCon : MonoBehaviour
{

    private PlayerLife playerLife;
    private ScoreCon score;
    private PartsHuge partsHuge;

    public GameObject explosion;
    [SerializeField] GameObject BreakObj;

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
        playerLife = GameObject.Find("musslepants2Unity").GetComponent<PlayerLife>();
        partsHuge = GameObject.Find("musslepants2Unity").GetComponent<PartsHuge>();

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
        //Vector3 vector3 = new Vector3(0f, 0.6f, 3.6f);
        //rb.AddForce(vector3, ForceMode.Impulse);
        //rb.AddTorque(Vector3.right * 3f, ForceMode.Impulse);
        //shadderBreak();
        Instantiate(BreakObj, transform.position, BreakObj.transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "HitDet")
        {
            Invoke("ExplosionSet", 1.5f);
            KillFlg = true;
            score.AddPoint(100);
            rb.freezeRotation = false;
            partsHuge.HugeParts(partsHuge.AttackInfo);
        }

        if (other.name == "PlayerDet")
        {
            if (runaway.DushFlg)
            {
                KillFlg = true;
                score.AddPoint(100);
                Invoke("ExplosionSet", 1.5f);
            }
            else
            {
                playerLife.Damege();
            }
        }
    }

    private void ExplosionSet()
    {
        GameObject obj = Instantiate(explosion, this.transform.position, Quaternion.identity);
        //gameObject.SetActive(false);
        Destroy(gameObject, 2.0f);
        Destroy(obj, 2.5f);
    }
}
