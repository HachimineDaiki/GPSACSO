using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_DoramuCreate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Doramu;     //作成するオブジェクトのprefab
    private GameObject CreateObj;       //作成したオブジェクト保存用変数
    private GameObject[] Cpos = new GameObject[5];
    private bool CreateFlg;     
    private int CreNum;         //作成したオブジェクトの要素番号   

    void Start()
    {
        int i = 0;
        //parentGameObjectは親要素のgameObject
        foreach (Transform child in gameObject.transform)       //子要素を変数に格納
        {
            Cpos[i++] = child.gameObject;
        }

        CreateFlg = true;

        DoramuCreate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckObj();
        DoramuCreate();
    }

    void CheckObj()
    {
        if(CreateObj == null)       //破壊されたら
        {
            CreateFlg = true;
        }
    }

    int RandomNum()         //乱数作成
    {
        int value = Random.Range(0, Cpos.Length);

        return value;
    }

    void DoramuCreate()
    {
        if (CreateFlg)
        {
            int Num = RandomNum();

            while (CreNum == Num)
            {
                Num = RandomNum();     //同じ数ならもう一度乱数作成
            }

            CreNum = Num;

            Vector3 vec = Cpos[CreNum].transform.localEulerAngles;
            vec.x += 270;
            CreateObj = Instantiate(Doramu, Cpos[CreNum].transform.position, Quaternion.Euler(vec));
            // 作成したオブジェクトを子として登録
            CreateObj.transform.parent = this.transform;

            CreateFlg = false;
        }
    }
}
