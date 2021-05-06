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

        //仮％変換(筋肉の増加量が明確になったら修正して）
        rightpoint *= 50;
        leftpoint  *= 50;
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
