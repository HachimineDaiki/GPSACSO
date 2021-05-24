using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UI使うときに必要
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;

    Button button;

    bool isCalledOnce = false;

    void Start()
    {
    }

    void Update()
    {
        if (pauseUI.activeSelf)
        {
            if (isCalledOnce == false)
            {
                button = GameObject.Find("Canvas/Panel/SelectButton/Return_To_Title").GetComponent<Button>();
                button.Select();
                button = GameObject.Find("Canvas/Panel/SelectButton/Return_To_Game").GetComponent<Button>();
                //ボタンが選択された状態になる
                button.Select();
                isCalledOnce = true;
            }

        }

        if (pauseUI.activeSelf == false && isCalledOnce == true)
        {
            isCalledOnce = false;
        }
    }
}