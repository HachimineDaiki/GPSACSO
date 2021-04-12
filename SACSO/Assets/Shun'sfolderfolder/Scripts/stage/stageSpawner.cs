using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject CreateObj;

    [SerializeField] private float ScrollSpeed = 1.0f;

    private int NextRot;        //少しずつ回転させる

    //最後に作ったオブジェクトを登録
    GameObject lastObj;

    public bool CreateFlg;
    void Start()
    {
        CreateFlg = false;

        NextRot = 0;

        for (int i =5; i>0; i--)
        {
            Vector3 Pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + (i * -100));

            // プレハブからインスタンスを生成
            GameObject obj = (GameObject)Instantiate(CreateObj, Pos, transform.rotation);
            // 作成したオブジェクトを子として登録
            obj.transform.parent = transform;

            lastObj = obj;
            GameObject.Destroy(obj, 30.0f - i*5.0f);



        }
    }

    // Update is called once per frame
    void Update()
    {
        childMove();
        if(lastObj.transform.localPosition.z <= -100f)
        {
            childCreate(gameObject.transform.position);
        }
    }

    void childCreate(Vector3 CreatePos)
    {
        // プレハブからインスタンスを生成
        GameObject obj = (GameObject)Instantiate(CreateObj, CreatePos, transform.rotation);
        // 作成したオブジェクトを子として登録
        obj.transform.parent = transform;
        obj.transform.Rotate(0,0, obj.transform.localRotation.z + NextRot);


        lastObj = obj;

        NextRot += 0;//3;

        if (NextRot >= 360) NextRot = 0;

        GameObject.Destroy(obj,5.0f);
    }

    void childMove()
    {
        //parentGameObjectは親要素のgameObject
        foreach (Transform child in transform)
        {
            float x = child.transform.position.x;
            float y = child.transform.position.y;
            float z = child.transform.position.z;

            Vector3 newPos = new Vector3(x, y, z - (ScrollSpeed + Time.deltaTime));

            child.transform.position = newPos;
        }
    }


}
