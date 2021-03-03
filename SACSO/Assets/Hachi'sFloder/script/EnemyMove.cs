using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMove : MonoBehaviour
{
    public float length = 1.0f;//移動する振幅
    public float speed = 1.0f;//移動するスピード、大きくすると早くなる
    private Vector3 startPos; //ゲーム開始時のポジションを入れる変数

    public bool negative = false;
   // public bool direction = false;
    private Rigidbody rB;

    // Start is called before the first frame update
    void Start()
    {

        startPos = this.transform.position;//ゲーム開始時の位置

        rB = GetComponent<Rigidbody>();

        if (negative == true)
        {
            speed = -speed;
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            length -= 0.3f;
            //Debug.Log("当たっています");
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
            rB.MovePosition(new Vector3((Mathf.Sin((Time.time) * speed) * length + startPos.x), startPos.y, startPos.z));

    }
}
