﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MainSceneCon_Proto : MonoBehaviour
{
    [SerializeField] private GameObject clearUI;

    [SerializeField] private Button YES_ClearButton;
    [SerializeField] private Button NO_ClearButton;
    [SerializeField] private GameObject SelectButton;
    [SerializeField] private ScoreCon SC;

    Button button;
    Select select;

    public bool CallOnlyOnce = false;


    // Start is called before the first frame update
    void Start()
    {
        select = GetComponent<Select>();
        YES_ClearButton.onClick.AddListener(YesButton);
        NO_ClearButton.onClick.AddListener(NoButton);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameClearCon()
    {
        select.PauseControlflg = true;
        clearUI.SetActive(!clearUI.activeSelf);
        //if(button != null)
        button = GameObject.Find("Canvas/Panel3/NO_ClearButton").GetComponent<Button>();
        button.Select();
        Time.timeScale = 0f;
    }

    private void YesButton()
    {
        select.PauseControlflg = false;
        clearUI.SetActive(!clearUI.activeSelf);
        Time.timeScale = 1f;

        SC = GameObject.Find("GameManeger").GetComponent<ScoreCon>();
        SC.ScoreSave();
        SceneManager.LoadScene("ClearScene");
    }

    private void NoButton()
    {
        button = GameObject.Find("Canvas/Panel3/YES_ClearButton").GetComponent<Button>();
        button.Select();
        select.PauseControlflg = false;
        clearUI.SetActive(!clearUI.activeSelf);
        Time.timeScale = 1f;
        CallOnlyOnce = false;
    }
}
