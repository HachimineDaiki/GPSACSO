using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Trigger_V2 : MonoBehaviour
{
    private CameraControl cameraControl;
    private Move move;

    private void Start()
    {
        cameraControl = GameObject.Find("Camera2").GetComponent<CameraControl>();

        move = gameObject.transform.root.GetComponent<Move>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            Debug.Log("asd");

            move.MoveFlg = false;

            // step = speed * Time.deltaTime;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90f, 0), step);

            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90f, 0), step);



            // Transform値を取得する
            Vector3 position = transform.root.gameObject.transform.localPosition;
            Quaternion rotation = transform.root.gameObject.transform.localRotation;
            Vector3 scale = transform.root.gameObject.transform.localScale;

            // クォータニオン → オイラー角への変換
            Vector3 rotationAngles = rotation.eulerAngles;

            // 回転
            rotationAngles.y = rotationAngles.y + 90.0f;

            // Vector3の加算は以下のような書き方も可能
            //rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

            // オイラー角 → クォータニオンへの変換
            rotation = Quaternion.Euler(rotationAngles);

            // Transform値を設定する
            transform.root.gameObject.transform.localPosition = position;
            transform.root.gameObject.transform.localRotation = rotation;
            transform.root.gameObject.transform.localScale = scale;

            if (cameraControl.cameraflg == false)
            {
                cameraControl.cameraflg = true;
            }

        }

        if (other.CompareTag("Trigger0"))
        {
            Debug.Log("zxc");

            // step = speed * Time.deltaTime;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90f, 0), step);

            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90f, 0), step);

            move.MoveFlg = true;

            // Transform値を取得する
            Vector3 position = transform.root.gameObject.transform.localPosition;
            Quaternion rotation = transform.root.gameObject.transform.localRotation;
            Vector3 scale = transform.root.gameObject.transform.localScale;

            // クォータニオン → オイラー角への変換
            Vector3 rotationAngles = rotation.eulerAngles;

            // 回転
            rotationAngles.y = rotationAngles.y + 45.0f;

            // Vector3の加算は以下のような書き方も可能
            //rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

            // オイラー角 → クォータニオンへの変換
            rotation = Quaternion.Euler(rotationAngles);

            // Transform値を設定する
            transform.root.gameObject.transform.localPosition = position;
            transform.root.gameObject.transform.localRotation = rotation;
            transform.root.gameObject.transform.localScale = scale;



        }

        if (other.CompareTag("Trigger1"))
        {
            move.MoveFlg = false;

            // Transform値を取得する
            Vector3 position = transform.root.gameObject.transform.localPosition;
            Quaternion rotation = transform.root.gameObject.transform.localRotation;
            Vector3 scale = transform.root.gameObject.transform.localScale;

            // クォータニオン → オイラー角への変換
            Vector3 rotationAngles = rotation.eulerAngles;

            // 回転
            rotationAngles.y = rotationAngles.y + 45.0f;

            // Vector3の加算は以下のような書き方も可能
            //rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

            // オイラー角 → クォータニオンへの変換
            rotation = Quaternion.Euler(rotationAngles);

            // Transform値を設定する
            transform.root.gameObject.transform.localPosition = position;
            transform.root.gameObject.transform.localRotation = rotation;
            transform.root.gameObject.transform.localScale = scale;

            if (cameraControl.cameraflg == false)
            {
                cameraControl.cameraflg = true;
            }

        }

        if (other.CompareTag("Trigger2"))
        {
            move.MoveFlg = true;

            // Transform値を取得する
            Vector3 position = transform.root.gameObject.transform.localPosition;
            Quaternion rotation = transform.root.gameObject.transform.localRotation;
            Vector3 scale = transform.root.gameObject.transform.localScale;

            // クォータニオン → オイラー角への変換
            Vector3 rotationAngles = rotation.eulerAngles;

            // 回転
            rotationAngles.y = rotationAngles.y + 90.0f;

            // Vector3の加算は以下のような書き方も可能
            //rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

            // オイラー角 → クォータニオンへの変換
            rotation = Quaternion.Euler(rotationAngles);

            // Transform値を設定する
            transform.root.gameObject.transform.localPosition = position;
            transform.root.gameObject.transform.localRotation = rotation;
            transform.root.gameObject.transform.localScale = scale;

        }

        if (other.CompareTag("2_Trigger"))
        {
            Debug.Log("asd");

            move.MoveFlg = false;

            // step = speed * Time.deltaTime;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90f, 0), step);

            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90f, 0), step);



            // Transform値を取得する
            Vector3 position = transform.root.gameObject.transform.localPosition;
            Quaternion rotation = transform.root.gameObject.transform.localRotation;
            Vector3 scale = transform.root.gameObject.transform.localScale;

            // クォータニオン → オイラー角への変換
            Vector3 rotationAngles = rotation.eulerAngles;

            // 回転
            rotationAngles.y = rotationAngles.y + -90.0f;

            // Vector3の加算は以下のような書き方も可能
            //rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

            // オイラー角 → クォータニオンへの変換
            rotation = Quaternion.Euler(rotationAngles);

            // Transform値を設定する
            transform.root.gameObject.transform.localPosition = position;
            transform.root.gameObject.transform.localRotation = rotation;
            transform.root.gameObject.transform.localScale = scale;

            if (cameraControl.cameraflg == false)
            {
                cameraControl.cameraflg = true;
            }

        }

        if (other.CompareTag("2_Trigger0"))
        {
            Debug.Log("zxc");

            // step = speed * Time.deltaTime;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90f, 0), step);

            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90f, 0), step);

            move.MoveFlg = true;

            // Transform値を取得する
            Vector3 position = transform.root.gameObject.transform.localPosition;
            Quaternion rotation = transform.root.gameObject.transform.localRotation;
            Vector3 scale = transform.root.gameObject.transform.localScale;

            // クォータニオン → オイラー角への変換
            Vector3 rotationAngles = rotation.eulerAngles;

            // 回転
            rotationAngles.y = rotationAngles.y + -45.0f;

            // Vector3の加算は以下のような書き方も可能
            //rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

            // オイラー角 → クォータニオンへの変換
            rotation = Quaternion.Euler(rotationAngles);

            // Transform値を設定する
            transform.root.gameObject.transform.localPosition = position;
            transform.root.gameObject.transform.localRotation = rotation;
            transform.root.gameObject.transform.localScale = scale;



        }

        if (other.CompareTag("2_Trigger1"))
        {
            move.MoveFlg = false;

            // Transform値を取得する
            Vector3 position = transform.root.gameObject.transform.localPosition;
            Quaternion rotation = transform.root.gameObject.transform.localRotation;
            Vector3 scale = transform.root.gameObject.transform.localScale;

            // クォータニオン → オイラー角への変換
            Vector3 rotationAngles = rotation.eulerAngles;

            // 回転
            rotationAngles.y = rotationAngles.y + -45.0f;

            // Vector3の加算は以下のような書き方も可能
            //rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

            // オイラー角 → クォータニオンへの変換
            rotation = Quaternion.Euler(rotationAngles);

            // Transform値を設定する
            transform.root.gameObject.transform.localPosition = position;
            transform.root.gameObject.transform.localRotation = rotation;
            transform.root.gameObject.transform.localScale = scale;

            if (cameraControl.cameraflg == false)
            {
                cameraControl.cameraflg = true;
            }

        }

        if (other.CompareTag("2_Trigger2"))
        {
            move.MoveFlg = true;

            // Transform値を取得する
            Vector3 position = transform.root.gameObject.transform.localPosition;
            Quaternion rotation = transform.root.gameObject.transform.localRotation;
            Vector3 scale = transform.root.gameObject.transform.localScale;

            // クォータニオン → オイラー角への変換
            Vector3 rotationAngles = rotation.eulerAngles;

            // 回転
            rotationAngles.y = rotationAngles.y + -90.0f;

            // Vector3の加算は以下のような書き方も可能
            //rotationAngles += new Vector3(90.0f, 0.0f, 0.0f);

            // オイラー角 → クォータニオンへの変換
            rotation = Quaternion.Euler(rotationAngles);

            // Transform値を設定する
            transform.root.gameObject.transform.localPosition = position;
            transform.root.gameObject.transform.localRotation = rotation;
            transform.root.gameObject.transform.localScale = scale;

        }


        if (other.CompareTag("Ca_Trigger"))
        {
            if (cameraControl.cameraflg == true)
            {
                cameraControl.clearflg = true;

                cameraControl.cameraflg = false;
            }

        }

    }
}
