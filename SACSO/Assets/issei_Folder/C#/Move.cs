using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] float Speed = 50.0f;

    private void Update()
    {
        Vector3 velocity = gameObject.transform.forward * Speed;
        gameObject.transform.position += velocity * Time.deltaTime;

    }
}