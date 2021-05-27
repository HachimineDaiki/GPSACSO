using UnityEngine;
using UnityEngine.UI;

public class partsend : MonoBehaviour
{

    private int rightpoint;
    private int leftpoint;
    private Text rightPointText;
    private Text leftPointText;
    private string Evaluation;//評価用文字列
    private Text EvaluationText;

    // Start is called before the first frame update
    void Start()
    {
        rightpoint = PlayerPrefs.GetInt("rpumpup",2);
        leftpoint = PlayerPrefs.GetInt("lpumpup",2);
        Debug.Log(rightpoint);
        Debug.Log(leftpoint);

        //テキスト取得
        rightPointText = GameObject.Find("RightPoint").GetComponent<Text>();
        leftPointText = GameObject.Find("LeftPoint").GetComponent<Text>();
        EvaluationText = GameObject.Find("EvlPoint").GetComponent<Text>();

        //％変換(成長量0~2*50+パンチ量0~9*5の計算）
        rightpoint *= 50+ PlayerPrefs.GetInt("RPunchCt", 0)*5;
        leftpoint  *= 50+ PlayerPrefs.GetInt("LPunchCt", 0)*5;

        //％が150を超えてた場合150で固定する
        if (rightpoint >= 150) rightpoint = 150;
        if (leftpoint >= 150) rightpoint = 150;
    }

    // Update is called once per frame
    void Update()
    {
        //右
        rightPointText.text = "右上腕筋 :" + rightpoint.ToString()+"%";
        //左
        leftPointText.text = "左上腕筋 :" + leftpoint.ToString() +"%";

        //評価
        //同じ値の場合
        if (PlayerPrefs.GetInt("rpumpup", 0) == PlayerPrefs.GetInt("lpumpup", 0))
        {
            Evaluation = "バランスいいマッスル！！";//1の評価
            if (PlayerPrefs.GetInt("rpumpup", 0) == 0)//0の評価
            {
                Evaluation = "まだまだッスル！";
            }
            if (PlayerPrefs.GetInt("rpumpup", 0) == 2)//2の評価
            {
                Evaluation = "ハイパーウルトラマッスル！！！";
            }
        }
        else if (PlayerPrefs.GetInt("rpumpup", 0) != PlayerPrefs.GetInt("lpumpup", 0))
        {
            Evaluation = "バランスわるマッスル！";
            if(PlayerPrefs.GetInt("rpumpup", 0) == 2 || PlayerPrefs.GetInt("lpumpup", 0) == 2)
            {
                Evaluation = "かたほうマッスル！！";
            }
        }
        EvaluationText.text = Evaluation.ToString();
    }
}
