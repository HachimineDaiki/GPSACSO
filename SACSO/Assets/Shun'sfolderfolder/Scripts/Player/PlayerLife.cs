/////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int Life;
    [SerializeField] private const int MaxLife = 3;

    private ScoreCon SC;//ScoreCon.scの参照　こいつの書き方が分からないので大文字にしました　許してください


    void Start()
    {
        SC = GameObject.Find("GameManeger").GetComponent<ScoreCon>();
        Life = MaxLife;
    }
    private void FixedUpdate()
    {
        if (transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    // Update is called once per frame

    public void Damege()
    {
        Life--;
        if (Life <= 0)
        {
            //スコアを記録する
            SC.ScoreSave();
            //ゲームオーバーへ
            SceneManager.LoadScene("GameOver");
        }
    }
}

/////////////////////