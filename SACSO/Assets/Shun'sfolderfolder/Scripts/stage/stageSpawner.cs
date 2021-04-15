using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject CreateObj;

    private float ScrollSpeed = 200.0f;

    private int NextRot;        //少しずつ回転させる

    [SerializeField] private float elapsedTime;
    public float[] CposX = { 0, 0, 0, 500f };
    public float[] CposY = { 0, 500f, -500, 500f };        //0:通常1:登り2:降り
    public float[] CposZ = { 500f, 500f, 500f, 0 };        //0:通常1:登り2:降り

    Vector3 TestPos = new Vector3( 500f, 500f, 0f );

    //private float[] floorType = {}

    private Vector3[] type = {
        new Vector3( 0f,0f,0f ),        //通常の床
        new Vector3( -45f,0f,0f ),        //登坂の床
        new Vector3( 45f,0f,0f ),       //下り坂の床
        new Vector3( -37.5f,-120f,0f ),       //登り坂の床V2
        new Vector3( -37.5f,-60f,0f ),       //下り坂の床V2

    };

    private Vector3[] StartPos = {
        new Vector3( 0f,0f,500f ),        //通常の床
        new Vector3( 0f,500f,500f ),        //登坂の床
        new Vector3( 0f,-500f,500f ),       //下り坂の床
        new Vector3( -500f * (float)System.Math.Sqrt(3f),750f,-500f ),        //登坂の床
        new Vector3( 500f * (float)System.Math.Sqrt(3f),-750f,-500f ),        //下り坂の床V2
    };

    private Vector3[] EndtPos = {
        new Vector3( 0f,0f,500f ),        //通常の床
        new Vector3( 0f,-200f,-200f ),        //登坂の床
        new Vector3( 0f,200f,-200f )       //下り坂の床
    };

    private float ChangeTime;
    [SerializeField] private static float CTime = 10.0f;


    public int startQuantity = 6;

    public int CreatType = 0;

    //最後に作ったオブジェクトを登録
    GameObject lastObj;

    public bool CreateFlg;
    void Start()
    {
        CreateFlg = false;

        NextRot = 0;

        elapsedTime = 0f;
        ChangeTime = 0f;

        for (int i = startQuantity; i>0; i--)
        {
            Vector3 Pos = new Vector3(0, 0, 500f + (i * -100) + 100);

            Quaternion qua = Quaternion.Euler(type[0]);

            // プレハブからインスタンスを生成
            GameObject obj = (GameObject)Instantiate(CreateObj, Pos, qua);
            // 作成したオブジェクトを子として登録
            obj.transform.parent = transform;
            //オブジェクトにタイプを持たせる
            obj.AddComponent<ChildType>();
            ChildType childType = obj.GetComponent<ChildType>();
            childType.Type = 0;

            lastObj = obj;
            GameObject.Destroy(obj, ((i*5.0f) + 5.0f) - i*5.0f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float apperTime = 0.5f;
        if (CreatType > 2) apperTime = 0.25f;


        elapsedTime += Time.deltaTime;
        ChangeTime += Time.deltaTime;

        childMove();
        if(elapsedTime > apperTime)
        {
            //Debug.Break();
            childCreate(new Vector3(0f,0f,0f), CreatType);
            elapsedTime = 0;
        }

        if(ChangeTime > CTime)
        {
            if(CreatType == 0)
            {
                CreatType = 3;
            }else if(CreatType == 3)
            {
                CreatType = 4;
            }
            else
            {
                CreatType = 0;
            }
            ChangeTime = 0f;
        }
    }

    void childCreate(Vector3 CreatePos, int num)
    {
        Quaternion qua = Quaternion.Euler(type[num]);

        //Vector3 CreatePosition = new Vector3(CposX[num], CposY[num], CposZ[num]);
        // プレハブからインスタンスを生成
        GameObject obj = (GameObject)Instantiate(CreateObj, StartPos[num], qua);
        // 作成したオブジェクトを子として登録
        obj.transform.parent = transform;
        obj.transform.Rotate(0,0, obj.transform.localRotation.z + NextRot);
        //オブジェクトにタイプを持たせる
        obj.AddComponent<ChildType>();
        ChildType childType = obj.GetComponent<ChildType>();
        childType.Type = num;


        lastObj = obj;

        NextRot += 0;//3;

        if (NextRot >= 360) NextRot = 0;

        GameObject.Destroy(obj,3.0f);
    }

    void childMove()
    {
        //parentGameObjectは親要素のgameObject
        foreach (Transform child in transform)
        {
            //子のタイプを取得
            ChildType childType = child.GetComponent<ChildType>();

            float x = child.transform.localPosition.x;
            float y = child.transform.localPosition.y;
            float z = child.transform.localPosition.z;



            if (childType.Type == 0)
            {
                child.transform.localPosition = new Vector3(x, y, z - (ScrollSpeed * Time.deltaTime));
            }
            else if (childType.Type == 1)
            {
                  child.transform.localPosition = new Vector3(x, y - (ScrollSpeed * Time.deltaTime), z - (ScrollSpeed * Time.deltaTime));
            }
            else if (childType.Type == 2)
            {
                child.transform.localPosition = new Vector3(x, y + (ScrollSpeed * Time.deltaTime), z - (ScrollSpeed * Time.deltaTime));
            }
            else if (childType.Type == 3)
            {
                child.transform.localPosition = new Vector3(x + ((ScrollSpeed * Time.deltaTime) * (float)System.Math.Sqrt(3f)), y - (ScrollSpeed * 1.5f * Time.deltaTime), z + (ScrollSpeed * Time.deltaTime));
            }
            else if (childType.Type == 4)
            {
                child.transform.localPosition = new Vector3(x - ((ScrollSpeed * Time.deltaTime) * (float)System.Math.Sqrt(3f)), y + (ScrollSpeed * 1.5f * Time.deltaTime), z + (ScrollSpeed * Time.deltaTime));
            }

            //子要素の向きで移動
            //child.transform.position -= child.transform.forward * ScrollSpeed * Time.deltaTime;
        }
    }


}
