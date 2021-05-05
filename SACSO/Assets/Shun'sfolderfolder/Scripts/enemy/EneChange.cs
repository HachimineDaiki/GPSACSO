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
            Instantiate(Doramu, child.transform.position, Doramu.transform.rotation);
            GameObject.Destroy(child.gameObject);
        }
    }

}
