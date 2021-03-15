using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed = 50.0f;
    Vector3 Oldposition;
    Vector3 Newposition;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        Oldposition = transform.position;
        Newposition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Newposition = transform.position;
        float x = 1.0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))        //左移動
        {
            x = -1 * speed;
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))      //右移動
        {
            x = speed;
        }


        //float x = Input.GetAxis("Horizontal") * speed;
        //float z = Input.GetAxis("Vertical") * speed;

        rb.AddForce(x, 0, 0);

        Oldposition = transform.position;
    }

    void jump()
    {
        if(Oldposition.y == Newposition.y)
        {
            rb.AddForce(0, 10f, 0,ForceMode.Impulse);
        }
    }


}
