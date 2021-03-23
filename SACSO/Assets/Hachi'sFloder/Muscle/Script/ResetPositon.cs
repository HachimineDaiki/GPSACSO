using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositon : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.z = 0.0f;
        transform.position = pos;

        Debug.Log("止まれェェェェ");
    }
}
