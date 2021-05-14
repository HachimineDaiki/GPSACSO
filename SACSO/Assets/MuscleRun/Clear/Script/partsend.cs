using UnityEngine;
using UnityEngine.UI;

public class partsend : MonoBehaviour
{

    private int rightpoint;
    private int leftpoint;
    private Text rightPointText;
    private Text leftPointText;

    // Start is called before the first frame update
    void Start()
    {
        rightpoint = PlayerPrefs.GetInt("rpumpup",0);
        leftpoint = PlayerPrefs.GetInt("lpumpup",0);
        Debug.Log(rightpoint);
        Debug.Log(leftpoint);

        //テキスト取得
        rightPointText = GameObject.Find("RightPoint").GetComponent<Text>();
        leftPointText = GameObject.Find("LeftPoint").GetComponent<Text>();

        //％変換(成長量0~2*50+パンチ量0~4*10の計算）
        rightpoint *= 50+ PlayerPrefs.GetInt("RPunchCt", 0)*10;
        leftpoint  *= 50+ PlayerPrefs.GetInt("LPunchCt", 0)*10;
    }

    // Update is called once per frame
    void Update()
    {
        //右
        rightPointText.text = "Right :" + rightpoint.ToString()+"%";
        //左
        leftPointText.text = "Left :" + leftpoint.ToString() +"%";
    }
}
