using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpwnerV2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject CreateObj;

    private float ScrollSpeed = 200.0f;

    [SerializeField] private float elapsedTime;


    private Vector3[] type = {          //床の角度
        new Vector3( 0f,0f,0f ),        //登坂

    };

    private Vector3[] StartPos = {      //床の出現する場所
        new Vector3( 0f,0f,500f),        //登坂
    };

    private float ChangeTime;
    //[SerializeField] private static float CTime = 5f;


    public int startQuantity = 6;       //初めに作成するステージの数

    public int CreatType = 0;       //ステージの向きのタイプ

    void Start()
    {
        CreatType = 0;

        elapsedTime = 0f;
        ChangeTime = 0f;


        //最初に足場を作る
        for (int i = startQuantity; i > 0; i--)
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

            GameObject.Destroy(obj, ((i * 5.0f) + 5.0f) - i * 5.0f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float apperTime = 0.5f;     //ステージの出現時間(0.5秒)
        if (CreatType != 0) apperTime = 0.25f;


        elapsedTime += Time.deltaTime;      //ステージの出現時間
        ChangeTime += Time.deltaTime;       //向きの変更時間

        childMove();
        if (elapsedTime > apperTime)
        {
            childCreate(CreatType % 3);
            elapsedTime = 0;
        }

        //いったん平面だけで走らせる
        //if (ChangeTime > CTime)
        //{
        //    if (++CreatType >= 1)
        //    {
        //        CreatType = 0;
        //    }
        //    ChangeTime = 0f;
        //}
    }

    void childCreate(int num)
    {
        Quaternion qua = Quaternion.Euler(type[num]);
        float Ypos = 0; if (CreatType >= 3) Ypos = 40f;       //反転する分の高さを調整
        Vector3 CreatePosition = new Vector3(StartPos[num].x, StartPos[num].y + Ypos, StartPos[num].z);
        // プレハブからインスタンスを生成
        GameObject obj = (GameObject)Instantiate(CreateObj, CreatePosition, qua);
        // 作成したオブジェクトを子として登録
        obj.transform.parent = transform;
        obj.transform.Rotate(0, 0, obj.transform.localRotation.z);
        //オブジェクトにタイプを持たせる
        obj.AddComponent<ChildType>();
        ChildType childType = obj.GetComponent<ChildType>();
        childType.Type = num;


        GameObject.Destroy(obj, 3.0f);
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
