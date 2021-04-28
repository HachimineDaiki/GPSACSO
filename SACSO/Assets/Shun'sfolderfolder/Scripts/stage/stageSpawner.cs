using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject CreateObj;

    private float ScrollSpeed = 200.0f;

    [SerializeField] private float elapsedTime;

    private Vector3[] type = {
        new Vector3( 0f,0f,0f ),        //通常の床
        new Vector3( -37.5f,-120f,0f ),       //登り坂の床V2
        new Vector3( -37.5f,-60f,0f ),       //下り坂の床V2

    };

    private Vector3[] StartPos = {
        new Vector3( 0f,0f,500f ),        //通常の床
        new Vector3( -500f * (float)System.Math.Sqrt(3f),750f,-500f ),        //登坂の床
        new Vector3( 500f * (float)System.Math.Sqrt(3f),-750f,-500f ),        //下り坂の床V2
    };


    private float ChangeTime;
    [SerializeField] private static float CTime = 5f;


    public int startQuantity = 6;

    public int CreatType = 0;

    void Start()
    {
        CreatType = 0;

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
            GameObject.Destroy(obj, ((i*5.0f) + 5.0f) - i*5.0f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float apperTime = 0.5f;
        if (CreatType != 0) apperTime = 0.25f;


        elapsedTime += Time.deltaTime;
        ChangeTime += Time.deltaTime;

        childMove();
        if(elapsedTime > apperTime)
        {
            childCreate(CreatType%3);
            elapsedTime = 0;
        }

        //if(ChangeTime > CTime)
        //{
        //    if(++CreatType >= 6)
        //    {
        //        CreatType = 0;
        //    }
        //    ChangeTime = 0f;
        //}
    }

    void childCreate(int num)
    {
        Quaternion qua = Quaternion.Euler(type[num]);
        float Ypos = 0; if (CreatType >= 3) Ypos =40f;       //反転する分の高さを調整
        Vector3 CreatePosition = new Vector3(StartPos[num].x, StartPos[num].y + Ypos, StartPos[num].z);
        // プレハブからインスタンスを生成
        GameObject obj = (GameObject)Instantiate(CreateObj, CreatePosition, qua);
        // 作成したオブジェクトを子として登録
        obj.transform.parent = transform;
        obj.transform.Rotate(0,0, obj.transform.localRotation.z);
        //オブジェクトにタイプを持たせる
        obj.AddComponent<ChildType>();
        ChildType childType = obj.GetComponent<ChildType>();
        childType.Type = num;

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


            //子要素のタイプによって移動処理を変える
            if (childType.Type == 0)
            {
                child.transform.localPosition = new Vector3(x, y, z - (ScrollSpeed * Time.deltaTime));
            }
            else if (childType.Type == 1)
            {
                child.transform.localPosition = new Vector3(x + ((ScrollSpeed * Time.deltaTime) * (float)System.Math.Sqrt(3f)), y - (ScrollSpeed * 1.5f * Time.deltaTime), z + (ScrollSpeed * Time.deltaTime));
            }
            else if (childType.Type == 2)
            {
                child.transform.localPosition = new Vector3(x - ((ScrollSpeed * Time.deltaTime) * (float)System.Math.Sqrt(3f)), y + (ScrollSpeed * 1.5f * Time.deltaTime), z + (ScrollSpeed * Time.deltaTime));
            }
        }
    }


}
