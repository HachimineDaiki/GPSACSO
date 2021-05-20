using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCon : MonoBehaviour
{
    [SerializeField] Canvas canvas;//キャンバスの取得


    // Start is called before the first frame update
    void Start()
    {
        //キャンバスの取得（TitleAnimationの割り込みで取得できなくなるので
        //SerializeFieldで取得します
        //canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {
        //Yボタンが押されてて、textが表示されている場合
        if (Input.GetKeyDown("joystick button 3") && canvas.gameObject.activeSelf == true)
        {
            //ストーリシーンへ
            SceneManager.LoadScene("OpeningScene");
        }
        //何かのキーが押されてて、textが表示されている場合
        else if (Input.anyKeyDown && canvas.gameObject.activeSelf == true)
        {
            //メインへ
            SceneManager.LoadScene("Main");
        }


    }
}
