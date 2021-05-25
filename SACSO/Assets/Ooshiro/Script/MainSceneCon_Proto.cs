using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MainSceneCon_Proto : MonoBehaviour
{
    [SerializeField] private GameObject clearUI;        //クリア画面（会場へ向かうか否か）UI

    [SerializeField] private Button YES_ClearButton;    //はい
    [SerializeField] private Button NO_ClearButton;     //いいえ
    //[SerializeField] private GameObject SelectButton;   
    [SerializeField] private ScoreCon SC;

    Button button;
    Select select;

    public bool CallOnlyOnce = false;                   //一度だけ呼び出しフラグ


    // Start is called before the first frame update
    void Start()
    {
        select = GetComponent<Select>();                //Select.cs取得
        YES_ClearButton.onClick.AddListener(YesButton); //YESボタンを押した時の処理
        NO_ClearButton.onClick.AddListener(NoButton);   //NOボタンを押したときの処理
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameClearCon()
    {
        select.PauseControlflg = true;                      //止めてる間ポーズが押せないように
        clearUI.SetActive(!clearUI.activeSelf);             //クリアUI表示
        //if(button != null)
        button = GameObject.Find("Canvas/Panel3/NO_ClearButton").GetComponent<Button>();    //NOボタンのコンポーネント取得
        button.Select();                                    //NOを選択状態に
        Time.timeScale = 0f;                                //時間を止める
    }

    private void YesButton()
    {
        select.PauseControlflg = false;                     //ポーズできるように
        clearUI.SetActive(!clearUI.activeSelf);             //クリアUIを非表示に
        Time.timeScale = 1f;                                //時間を動かす

        SC = GameObject.Find("GameManeger").GetComponent<ScoreCon>();
        SC.ScoreSave();
        SceneManager.LoadScene("ClearScene");               //クリアシーン読み込み
    }

    private void NoButton()
    {
        button = GameObject.Find("Canvas/Panel3/YES_ClearButton").GetComponent<Button>();   //YESボタンのコンポーネント取得
        button.Select();                                                                    //YESボタンを選択状態にする（２週目にNOボタンを選ぶ時のための初期化のようなもの）
        select.PauseControlflg = false;                     //ポーズできるように
        clearUI.SetActive(!clearUI.activeSelf);             //クリアUIを非表示に
        Time.timeScale = 1f;                                //時間を動かす
        CallOnlyOnce = false;                               //何これ？
    }
}
