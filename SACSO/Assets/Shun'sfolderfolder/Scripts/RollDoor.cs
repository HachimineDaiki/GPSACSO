using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDoor : MonoBehaviour
{
    [SerializeField]DoorType type;
    [SerializeField]DoorStatus doorstatus;
    private int Cnt;
    [SerializeField]private float Movequantity;

    [SerializeField]float time;

    float distance = 90f;       //回転量

    private bool active;
    // Use this for initialization
    void Start()
    {
        List<GameObject> list = ChildGet.GetAll(gameObject);
        foreach (GameObject obj in list)
        {
            if(obj.transform.localPosition.x > 0f)
            {
                type = DoorType.Left;
            }
            else
            {
                type = DoorType.Right;
            }
        }
        //ローテーションのYを左開きなら減算/右開きなら加算
        if (type == DoorType.Left)
        {
            distance *= -1;
        }

        if (doorstatus == DoorStatus.Open)
        {
            distance *= -1;
        }
        doorstatus = DoorStatus.Close;
        active = false;
        Cnt = 0;
        Movequantity = 0;
        time = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!active) active = true;
        }
        if (active) RotationD(type);
        float angle = Mathf.LerpAngle(transform.rotation.y, distance, time);
        transform.eulerAngles = new Vector3(0, angle, 0);
    }

    void RotationD(DoorType type)
    {


        if (doorstatus == DoorStatus.Open)
        {
            //distance *= -1;
            time -= Time.deltaTime * 2;
        }
        else
        {
            time += Time.deltaTime * 2;
        }
        //Debug.Log(time);
        //Vector3 vector3 = new Vector3(transform.rotation.x, transform.rotation.y + ( distance / 10), transform.rotation.z);
        //transform.Rotate(vector3);

        Movequantity += Mathf.Abs(distance / 10);
        //if(Movequantity >= 90f)
        if(time >= 1f || time <= 0)
        {
            if(time > 1f)
            {
                time = 1f;
            }
            if(time < 0)
            {
                time = 0;
            }
            active = false;
            Movequantity = 0;
            if (doorstatus == DoorStatus.Close)
            {
                doorstatus = DoorStatus.Open;
            }
            else
            {
                doorstatus = DoorStatus.Close;
            }

        }

    }
}
