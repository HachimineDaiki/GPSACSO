using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class PauseScript : MonoBehaviour
{
 [SerializeField]
    private GameObject pauseUI;

    Select select;
    //AudioSource audiosource;
    public bool pauseflg;

    [SerializeField] GameObject TimeUPPnel;
    private void Start() {
        //audiosource = GetComponent<AudioSource>();
        select = GetComponent<Select>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("q") || Input.GetKeyDown("joystick button 7")) && select.PauseControlflg == false)
        {
            if (TimeUPPnel.activeSelf) return;

            //　ポーズUIのアクティブ、非アクティブを切り替え
            pauseUI.SetActive(!pauseUI.activeSelf);

            //　ポーズUIが表示されてる時は停止
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
                pauseflg = true;
                //audiosource.Pause();
                
                //　ポーズUIが表示されてなければ通常通り進行
            }
            else
            {
                Time.timeScale = 1f;
                pauseflg = false;
                //audiosource.UnPause();
            }
        }




    }


//    [SerializeField]
//    //    ポーズした時に表示するUIのプレハブ
//    private GameObject pauseUIPrefab;
//    //   ポーズUIのインスタンス
//    private GameObject pauseUIInstance;


//    //    Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown("q"))
//        {
//            if (pauseUIInstance == null)
//            {
//                pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
//                Time.timeScale = 0f;
//            }
//            else
//            {
//                Destroy(pauseUIInstance);
//                Time.timeScale = 1f;
//            }
//        }
//    }
//}

//private void Update()
//{
//   // ポーズする

//    if (GameObject.Find("TutoSys"))
//    {
//        if (Input.GetButtonDown("Pause") && GameObject.Find("TutoSys").GetComponent<PlayTutorial>().tutoNum == 99)
//            Time.timeScale = 1 - Time.timeScale;
//    }
//    else
//    {
//        if (Input.GetButtonDown("Pause"))
//            Time.timeScale = 1 - Time.timeScale;
//    }

//}
//}

//　ポーズした時に表示するUI


}
