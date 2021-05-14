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
            Vector3 rot = new Vector3(child.transform.rotation.x - 90, child.transform.localRotation.y, child.transform.rotation.z);
            Vector3 vec = child.transform.localEulerAngles;
            vec.x += 270;
            Instantiate(Doramu, child.transform.position, Quaternion.Euler(vec));
            GameObject.Destroy(child.gameObject);
        }
    }

}
