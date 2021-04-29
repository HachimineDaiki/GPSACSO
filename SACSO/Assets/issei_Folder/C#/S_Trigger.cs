using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class S_Trigger : MonoBehaviour
{

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
            rotationAngles.y = rotationAngles.y + 135.0f;

            // Vector3の加算は以下のような書き方も可能
            //rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

            // オイラー角 → クォータニオンへの変換
            rotation = Quaternion.Euler(rotationAngles);

            // Transform値を設定する
            this.transform.localPosition = position;
            this.transform.localRotation = rotation;
            this.transform.localScale = scale;

        }


        if (other.CompareTag("Trigger0"))
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
            rotationAngles.y = rotationAngles.y + -135.0f;

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
