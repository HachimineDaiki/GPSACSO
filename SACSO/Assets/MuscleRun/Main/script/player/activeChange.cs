using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeChange : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject objMesh;       //オブジェクトのメッシュ
    
    public void change()
    {
        objMesh.SetActive(!objMesh.activeSelf);
    }

    public void MeshTrue()
    {
        objMesh.SetActive(true);
    }
}
