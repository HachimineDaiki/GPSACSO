using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Transform target;
    // float step = 1.0f;
    // float speed;


    void Start()
    {
        string objctName;

        objctName = gameObject.name;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            Debug.Log("asd");

            // step = speed * Time.deltaTime;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90f, 0), step);

            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90f, 0), step);



            // Transform値を取得する
            Vector3 position = this.transform.localPosition;
            Quaternion rotation = this.transform.localRotation;
            Vector3 scale = this.transform.localScale;

            // クォータニオン → オイラー角への変換
            Vector3 rotationAngles = rotation.eulerAngles;

            // 回転

            switch (transform.gameObject.name)
            {
                case "Torigger (0)":
                    rotationAngles.y = -45.0f;
                    break;

                case "Trigger_L (1)":
                    rotationAngles.y = -67.5f;
                    break;

                case "Trigger_L (2)":
                    rotationAngles.y = -90.0f;
                    break;

                case "Trigger_L (3)":
                    rotationAngles.y = -112.5f;
                    break;

                case "Trigger_L (4)":
                    rotationAngles.y = -135.0f;
                    break;

                case "Trigger_L (5)":
                    rotationAngles.y = -157.5f;
                    break;

                case "Trigger_L (6)":
                    rotationAngles.y = -180.0f;
                    break;

                case "Trigger_L (7)":
                    rotationAngles.y = -202.5f;
                    break;

                case "Trigger_L (8)":
                    rotationAngles.y = -225f;
                    break;

                default:
                    break;

            }

            //rotationAngles.y = rotationAngles.y + -22.5f;

            // Vector3の加算は以下のような書き方も可能
            //rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

            // オイラー角 → クォータニオンへの変換
            rotation = Quaternion.Euler(rotationAngles);

            // Transform値を設定する
            this.transform.localPosition = position;
            this.transform.localRotation = rotation;
            this.transform.localScale = scale;

        }


    }
}
