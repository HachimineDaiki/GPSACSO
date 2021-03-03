using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody rB;
    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rB.AddForce(x * speed, 0, z * speed, ForceMode.Impulse);
    }
}