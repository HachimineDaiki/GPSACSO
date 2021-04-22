using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    PauseScript pausescript;
    GameObject gamemanager;

    [SerializeField] private GameObject pauseUI;

    [SerializeField] private Button Return_To_Game;
    [SerializeField] private Button Return_To_Title;
  //  [SerializeField] private Button Volume_adjustment;
    [SerializeField] private Button End_The_Game;

    private void Start()
    {
        Return_To_Game.onClick.AddListener(ReturnGame);
        Return_To_Title.onClick.AddListener(ReturnTitle);
       // Volume_adjustment.onClick.AddListener(Volume);
        End_The_Game.onClick.AddListener(EndGame);


        gamemanager = GameObject.Find("GameManeger");
        pausescript = gamemanager.GetComponent<PauseScript>();
    }

    private void ReturnGame()
    {
        Time.timeScale = 1f;
        pausescript.pauseflg = false;
        pauseUI.SetActive(!pauseUI.activeSelf);
    }

    private void ReturnTitle()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(!pauseUI.activeSelf);
        SceneManager.LoadScene("TitleScene");
    }

    private void Volume()
    {

    }

    private void EndGame()
    {

       #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;   // UnityEditorの実行を停止する処理
       #else
        Application.Quit();                                // ゲームを終了する処理
       #endif
    }


}