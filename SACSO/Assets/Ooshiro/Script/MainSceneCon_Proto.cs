using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainSceneCon_Proto : MonoBehaviour
{
    [SerializeField] private GameObject clearUI;

    [SerializeField] private Button YES_ClearButton;
    [SerializeField] private Button NO_ClearButton;

    Button button;
    Select select;

    // Start is called before the first frame update
    void Start()
    {
        select = GetComponent<Select>();

        YES_ClearButton.onClick.AddListener(YesButton);
        YES_ClearButton.onClick.AddListener(NoButton);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("GameClearCon", 5f);
    }

    private void GameClearCon()
    {
        select.PauseControlflg = true;
        clearUI.SetActive(!clearUI.activeSelf);
        button = GameObject.Find("Canvas/Panel3/YES_ClearButton").GetComponent<Button>();
        button.Select();
        Time.timeScale = 0f;
    }

    private void YesButton()
    {
        SceneManager.LoadScene("ClearScene");
        select.PauseControlflg = false;
        clearUI.SetActive(!clearUI.activeSelf);
    }

    private void NoButton()
    {
        clearUI.SetActive(!clearUI.activeSelf);
        Time.timeScale = 1f;

    }
}
