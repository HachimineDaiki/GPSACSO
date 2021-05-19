using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneChange : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Doramu;
    void Start()
    {
        //parentGameObjectは親要素のgameObject
        foreach (Transform child in gameObject.transform)
        {
            Vector3 vec = child.transform.localEulerAngles;
            vec.x += 270;
            GameObject obj = Instantiate(Doramu, child.transform.position, Quaternion.Euler(vec));
            // 作成したオブジェクトを子として登録
            obj.transform.parent = child.transform;

        }
    }

}
