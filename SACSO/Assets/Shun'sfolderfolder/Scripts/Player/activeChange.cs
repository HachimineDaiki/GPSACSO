using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeChange : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject objMesh;       //オブジェクトのメッシュ
    
    void change()
    {
        objMesh.SetActive(!objMesh.activeSelf);
    }

    void MeshTrue()
    {
        objMesh.SetActive(true);
    }
}
