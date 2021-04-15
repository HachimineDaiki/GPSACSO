using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[RequireComponent(typeof(Rigidbody))]
public class enemyMove : MonoBehaviour
{
    [SerializeField] Vector3 direction; 
    [SerializeField] private float speed =3.0f;        //敵の移動速度
    [SerializeField] private float distance;

    private Vector3[] StartPos = {
        new Vector3( 0f,0f,500f ),        //通常の床
        new Vector3( -500f * (float)System.Math.Sqrt(3f),750f,-500f ),        //登坂の床
        new Vector3( 500f * (float)System.Math.Sqrt(3f),-750f,-500f ),        //下り坂の床V2
        new Vector3( -500f * (float)System.Math.Sqrt(3f),750f,-500f ),        //登坂の床
        new Vector3( 500f * (float)System.Math.Sqrt(3f),-750f,-500f ),        //下り坂の床V2
    };

    private Vector3[] EndPos = {
        new Vector3( 0f,0f,-100f ),        //通常の床
        new Vector3(100,-86,58 ),        //登坂の床
        new Vector3( 500f * (float)System.Math.Sqrt(3f),-750f,-500f ),        //下り坂の床V2
        new Vector3(-103,-89,60 ),        //登坂の床
        new Vector3( -41,36f,24f ),        //下り坂の床V2
    };

    private Runaway runaway;
    private PlayerLife playerLife;
    private ScoreCon score;
    private PartsHuge partsHuge;

    AudioSource audioSource;

    public AudioClip sound01;
    public AudioClip sound02;

    public GameObject explosion;

    Material material;

    float Des;

    private bool KillFlg;       //殴られた判定
    Rigidbody rb;

    public int Type;




    [SerializeField] stageSpawner spawner;
    private int Snum;



    // Use this for initialization
    void Start()
    {
        //enemyaudio = gameObject.AddComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        direction = new Vector3(transform.position.x, transform.position.y, -90f);    //ターゲットの座標
        KillFlg = false;
        distance = 0f;
        speed = 5.5f;

        runaway = GameObject.Find("GameManeger").GetComponent<Runaway>();
        score = GameObject.Find("GameManeger").GetComponent<ScoreCon>();
        playerLife = GameObject.Find("musslepants2Unity").GetComponent<PlayerLife>();
        partsHuge = GameObject.Find("musslepants2Unity").GetComponent<PartsHuge>();

        Des = 0f;
        material = GetComponent<Renderer>().material;


        spawner = GameObject.Find("StageScroll").GetComponent<stageSpawner>();
        Snum = spawner.CreatType;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Snum = spawner.CreatType;

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
            distance += (Time.deltaTime / speed);
        }
        else
        {
            distance = 1f;
        }
        //transform.position = Vector3.Lerp(StartPos[Snum], EndPos[Snum], distance);
        //Debug.Log(StartPos[Snum]);


        float x = transform.localPosition.x;
        float y = transform.localPosition.y;
        float z = transform.localPosition.z;

        if (Type == 0)
        {

            transform.localPosition = new Vector3(x, y, z - (200f * Time.deltaTime));
        }
        else if(Type == 1)
        {
            transform.localPosition = new Vector3(x + ((200f * Time.deltaTime) * (float)System.Math.Sqrt(3f)), y - (200f * 1.5f * Time.deltaTime), z + (200f * Time.deltaTime));
        }
        else
        {
            transform.localPosition = new Vector3(x - ((200f * Time.deltaTime) * (float)System.Math.Sqrt(3f)), y + (200f * 1.5f * Time.deltaTime), z + (200f * Time.deltaTime));
        }
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
;           KillFlg = true;
            score.AddPoint(100);
            //Destroy(gameObject, 1.5f);
            rb.freezeRotation = false;
            partsHuge.HugeParts(partsHuge.AttackInfo);
            audioSource.PlayOneShot(sound01);
            //Debug.Break();
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
        audioSource.PlayOneShot(sound02);
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        //gameObject.SetActive(false);
        Destroy(gameObject, 2.0f);
    }
}
