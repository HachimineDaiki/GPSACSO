using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[RequireComponent(typeof(Rigidbody))]
public class enemyMove : MonoBehaviour
{
    
    private PlayerLife playerLife;
    private ScoreCon score;
    private PartsHuge partsHuge;

    public GameObject Drum;      //壊れる前のドラムを入れる（具志堅
    public GameObject BreakDrum;//壊れた後のドラムを入れる

    public GameObject explosion;

    Material material;

    float Des;

    public bool KillFlg;       //殴られた判定
    Rigidbody rb;




    // Use this for initialization
    void Start()
    {
        //enemyaudio = gameObject.AddComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        KillFlg = false;

        score = GameObject.Find("GameManeger").GetComponent<ScoreCon>();
        playerLife = GameObject.Find("musslepants2Unity").GetComponent<PlayerLife>();
        partsHuge = GameObject.Find("musslepants2Unity").GetComponent<PartsHuge>();

        Des = 0f;
        material = GetComponent<Renderer>().material;

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
        Drum.SetActive(false);    //ドラムを非アクティブ（具志堅
        BreakDrum.SetActive(true);//壊れたドラムをアクティブ

        Vector3 vector3 = new Vector3(0f, 0.6f, 3.6f);
        rb.AddForce(vector3, ForceMode.Impulse);
        rb.AddTorque(Vector3.right * 3f, ForceMode.Impulse);
        //shadderBreak();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "HitDet")
        {
            Invoke("ExplosionSet",1.5f);
;           KillFlg = true;
            score.AddPoint(100);
            rb.freezeRotation = false;
            partsHuge.HugeParts(partsHuge.AttackInfo);
        }

        if (other.name == "PlayerDet")
        {
            //if (runaway.DushFlg)
            //{
            //    KillFlg = true;
            //    score.AddPoint(100);
            //    Invoke("ExplosionSet", 1.5f);
            //}
            //else
            //{
            //    playerLife.Damege();
            //}

            //いったん無敵判定なし
            playerLife.Damege();
        }
    }

    private void shadderBreak()
    {
        if (Des < 1f)
        {
            Des += Time.deltaTime / 0.5f;
        }

        if (material.HasProperty("_Destruction"))
        {
            material.SetFloat("_Destruction", Des);
        }
    }
    private void ExplosionSet()
    {
        GameObject obj = Instantiate(explosion, this.transform.position, this.transform.rotation);
        //gameObject.SetActive(false);
        Destroy(gameObject, 2.0f);
        Destroy(obj, 2.5f);
    }
}
