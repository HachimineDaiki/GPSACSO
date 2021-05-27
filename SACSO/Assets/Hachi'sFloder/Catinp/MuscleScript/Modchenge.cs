using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modchenge : MonoBehaviour
{
    public GameObject[] Cmodels = new GameObject[9];//クリア画面のゼイバス君をぶち込む

    public int[] ClearArm = new int[2];//クリア時の 右腕:0 左腕:1

    public int NowModelNum; //現在のモデル

    private int rightarm;
    private int leftarm;
    //Start is called before the first frame update
    void Start() {
      rightarm = PlayerPrefs.GetInt("rpumpup",0);
      leftarm = PlayerPrefs.GetInt("lpumpup",0);

        int modelfact = 0; //モデルアクティブ
        foreach (Transform child in gameObject.transform) {
            if (child.tag == "Player") {
                Cmodels[modelfact] = child.gameObject;
                if (modelfact++ != 0) child.gameObject.SetActive(false); //非アクティブにする。
                //Debug.Log("modelfact");
            }
            if (modelfact > 9) break;
        }

        NowModelNum = 0;

        modchenge();　//腕大きくします。（モデルを変えます）

    }

    // Update is called once per frame
    void Update() { }
    
    
    

    void modchenge() {
        
        //int modelNum = rightarm + leftarm;

        /*Debug.Log(rightarm);
        Debug.Log(leftarm);*/



        if (rightarm == 0 && leftarm == 0) {
            Cmodels[0].SetActive(true);
            //Cmodels[NowModelNum].SetActive(false);
        }
        else if (rightarm == 1 && leftarm == 0) {
            Cmodels[1].SetActive(true);
            Cmodels[NowModelNum].SetActive(false);
        }
        else if (rightarm == 2 && leftarm == 0) {
            Cmodels[2].SetActive(true);
            Cmodels[NowModelNum].SetActive(false);
        }
        else if (rightarm == 1 && leftarm == 1) {
            Cmodels[3].SetActive(true);
            Cmodels[NowModelNum].SetActive(false);
        }
        else if (rightarm == 1 && leftarm == 1) {
            Cmodels[4].SetActive(true);
            Cmodels[NowModelNum].SetActive(false);
        }
        else if (rightarm == 1 && leftarm == 2) {
            Cmodels[5].SetActive(true);
            Cmodels[NowModelNum].SetActive(false);
        }
        else if (rightarm == 0 && leftarm == 2) {
            Cmodels[6].SetActive(true);
            Cmodels[NowModelNum].SetActive(false);
        }
        else if (rightarm == 1 && leftarm == 2) {
            Cmodels[7].SetActive(true);
           Cmodels[NowModelNum].SetActive(false);
        }
        else if (rightarm == 2 && leftarm == 2) {
            Cmodels[8].SetActive(true);
            Cmodels[NowModelNum].SetActive(false);
        }

        //NowModelNum = modelNum;

    }
}
