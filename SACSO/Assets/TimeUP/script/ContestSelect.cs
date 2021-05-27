using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ContestSelect : MonoBehaviour
{
    [SerializeField] GameObject[] YesObj = new GameObject[3];
    private int selectObj = 0;
    private bool CheckFlg;      //二重押防止
    private float PushTime;     //ボタン時間制限

    // Start is called before the first frame update
    void Start()
    {
        selectObj = 0;
        EventSystem.current.SetSelectedGameObject(YesObj[0]);
        YesObj[0].GetComponent<Button>().Select();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (!CheckFlg) selectNum();
        //else Prevention();
        EventSystem.current.SetSelectedGameObject(YesObj[selectObj]);
    }

    void selectNum()
    {
        if (Input.GetAxis("Horizontal") > 0.5)
        {
            selectObj++;
            CheckFlg = true;
            PushTime = 0.3f;
        }
        else if (Input.GetAxis("Horizontal") < -0.5)
        {
            selectObj--;
            CheckFlg = true;
            PushTime = 0.3f;
        }

        if (selectObj >= YesObj.Length) selectObj = YesObj.Length - 1;
        else if (selectObj <= 0) selectObj = 0;
    }

    void Prevention()
    {
        PushTime -= Time.deltaTime;

        if (PushTime < 0) CheckFlg = false;
        if (Input.GetAxis("Horizontal") < 0.2 && Input.GetAxis("Horizontal") > -0.2) CheckFlg = false;
    }

    public void OnClick()
    {
        Time.timeScale = 1f;
        ScoreCon SC = GameObject.Find("GameManeger").GetComponent<ScoreCon>();
        SC.ScoreSave();
        SceneManager.LoadScene("ClearScene");
    }
}
