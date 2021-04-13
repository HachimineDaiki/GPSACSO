using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class enemyMove : MonoBehaviour
{
    Vector3 direction; 
    [SerializeField] private float speed =3.0f;        //敵の移動速度
    [SerializeField] private float distance;
    [SerializeField] private Vector3 StartPosition;

    private Runaway runaway;
    private PlayerLife playerLife;
    private ScoreCon score;
    private PartsHuge partsHuge;
    //private AudioSource enemyaudio;

    //public AudioClip sound01;
    //public AudioClip sound02;

    public GameObject explosion;

    Material material;

    float Des;

    private bool KillFlg;       //殴られた判定
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        //enemyaudio = gameObject.AddComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        direction = new Vector3(transform.position.x, transform.position.y, -90f);    //ターゲットの座標
        KillFlg = false;
        distance = 0f;
        StartPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speed = Random.Range(2.0f, 5.5f);

        runaway = GameObject.Find("GameManeger").GetComponent<Runaway>();
        score = GameObject.Find("GameManeger").GetComponent<ScoreCon>();
        playerLife = GameObject.Find("musslepants2Unity").GetComponent<PlayerLife>();
        partsHuge = GameObject.Find("musslepants2Unity").GetComponent<PartsHuge>();

        Des = 0f;
        material = GetComponent<Renderer>().material;

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
        if (runaway.DushFlg) Dushspd = 2.5f;

        if (distance <= 1f)
        {
            distance += (Time.deltaTime / speed ) * Dushspd;
        }
        else
        {
           distance = 1f;
        }
        transform.position = Vector3.Lerp(StartPosition, direction, distance);
        if (distance >= 1.0f) Destroy(gameObject);
        
    }

    private void Damege()
    {
        Vector3 vector3 = new Vector3(0f, 0.6f, 3.6f);
        rb.AddForce(vector3, ForceMode.Impulse);
        rb.AddTorque(Vector3.right * 3f, ForceMode.Impulse);
        //shadderBreak();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "HitDet")
        {
            //Instantiate(explosion, this.transform.position, Quaternion.identity);
            Invoke("ExplosionSet",1.5f);
;            KillFlg = true;
            score.AddPoint(100);
            Destroy(gameObject, 1.5f);
            rb.freezeRotation = false;
            partsHuge.HugeParts(partsHuge.AttackInfo);
            //Debug.Break();
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
        //enemyaudio.PlayOneShot(sound01);
        Instantiate(explosion, this.transform.position, Quaternion.identity);
    }
}
