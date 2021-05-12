using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCon : MonoBehaviour
{
    Canvas canvas;//キャンバスの取得
    
    
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && canvas.gameObject.activeSelf == true)
        {
            //メインへ
            SceneManager.LoadScene("Main");
        }


    }
}
