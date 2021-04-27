using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    PauseScript pausescript;
    GameObject gamemanager;

    public bool PauseControlflg;

    [SerializeField] public GameObject pauseUI;
    [SerializeField] public GameObject volumeUI;
    [SerializeField] public GameObject BGMSlider;
    [SerializeField] public GameObject SESlider;

    [SerializeField] private Button Return_To_Game;
    [SerializeField] private Button Return_To_Title;
    [SerializeField] private Button Volume_adjustment;
    [SerializeField] private Button End_The_Game;
    [SerializeField] private Button Return;

    bool isCalledOnceVolume = false;
    Button Return_Button;
    private void Start()
    {
        Return_To_Game.onClick.AddListener(ReturnGame);
        Return_To_Title.onClick.AddListener(ReturnTitle);
        Volume_adjustment.onClick.AddListener(Volume);
        Return.onClick.AddListener(ReturnScreen);
        End_The_Game.onClick.AddListener(EndGame);

        PauseControlflg = false;
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

    public void Volume()
    {
        PauseControlflg = true;
        volumeUI.SetActive(!volumeUI.activeSelf);
        pauseUI.SetActive(!pauseUI.activeSelf);
        //button.VolumeSelect();
        if (!pauseUI.activeSelf)
        {
            if (isCalledOnceVolume == false)
            {
                Return_Button = GameObject.Find("/Canvas/Panel2/Return_Button").GetComponent<Button>(); //ボタンが選択された状態になる
                Return_Button.Select();
                isCalledOnceVolume = true;

            }

        }

        if (pauseUI.activeSelf == false && isCalledOnceVolume == true)
        {
            isCalledOnceVolume = false;
        }
    }

    private void EndGame()
    {

       #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;   // UnityEditorの実行を停止する処理
       #else
        Application.Quit();                                // ゲームを終了する処理
       #endif
    }

    public void ReturnScreen()
    {
        volumeUI.SetActive(!volumeUI.activeSelf);
        pauseUI.SetActive(!pauseUI.activeSelf);
        PauseControlflg = false;
    }

    //void selectBGM()
    //{
    //    button = GameObject.Find("Canvas/Panel2/Return").GetComponent<Button>();
    //}

}