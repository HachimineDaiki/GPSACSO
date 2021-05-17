using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMove : MonoBehaviour
{

    [SerializeField] float Speed = 50.0f;
    private bool moveflg = true;

    //基準点
    Vector3 RefPos;
    private float Depthdistance;

    //曲がる場所を格納
    private GameObject Turn;

    private int TurnNum;


    //左右の移動の割合
    /// <summary>
    /// -100f~100fの範囲　移動量
    /// </summary>
    private float Sidedistance;
    const float Max = 100f;
    const float Min = -100f;

    //道を曲がるのcheck
    private bool TurnCheck;
    private float TurnTime;     //曲がる時間

    private Vector3 StartP , EndP;
    private Quaternion StartRot, EndRot;

    private float NowDis, OldDis;

    //長押し移動を防止する　
    public bool MoveFlg = false;

    public Runaway runaway;
    float DushSpeed;

    float AdjustmentTime;
    bool AdjustmentFlg;

    private float DisTime;      //距離によって曲がる時間を変える




    private void Start()
    {
        Sidedistance = 0f;
        Depthdistance = 0f;

        TurnCheck = false;

        Turn = GameObject.Find("TurnObj");
        TurnNum = 0;

        OldDis = Mathf.Infinity;

        DushSpeed = 1f;
        AdjustmentTime = 0f;
        DisTime = 0f;
        AdjustmentFlg = false;
    }

    private void FixedUpdate()
    {
        if (!TurnCheck && !AdjustmentFlg)
        {
            Advance();      //前に進む
            RLMove();       //左右移動 

            // クォータニオン → オイラー角への変換
            Vector3 rotationAngles = transform.rotation.eulerAngles;
            float rad = (rotationAngles.y) * Mathf.Deg2Rad;
            float test = (360 - rotationAngles.y) * Mathf.Deg2Rad;


            //最終的な移動の場所
            transform.position = new Vector3(RefPos.x + ((Sidedistance * Mathf.Cos(test)) + (Depthdistance * Mathf.Sin(rad))),
                                             transform.position.y,
                                             RefPos.z + ((Sidedistance * Mathf.Sin(test)) + (Depthdistance * Mathf.Cos(rad))));


            PosCheck();

        }
        else if(TurnCheck)
        {
            TurnMove();     //道を曲がる
        }
        else
        {
            AdjustmentPos();        //道を曲がった後の調整
        }
        ChildStop();    //子要素のゼイバスくんの移動の削除

        Dush();
        
    }

    void NowPosGet()
    {
        //奥行きの移動量をリセット
        Depthdistance = 0f;

        // クォータニオン → オイラー角への変換
        Vector3 rotationAngles = transform.rotation.eulerAngles;
        float test = (360 - rotationAngles.y) * Mathf.Deg2Rad;

        //基準位置の更新
        Vector3 OriginPoint = new Vector3(transform.position.x - (Sidedistance * Mathf.Cos(test)),
                                         transform.position.y,
                                         transform.position.z - (Sidedistance * Mathf.Sin(test)));

        if (TurnNum == 0)
        {
            OriginPoint = new Vector3(0,
                                         transform.position.y,
                                         transform.position.z - (Sidedistance * Mathf.Sin(test)));
        }
        else if(TurnNum == 2)
        {
            TurnPosGet PosGet = Turn.gameObject.GetComponent<TurnPosGet>();

            OriginPoint = new Vector3(transform.position.x - (Sidedistance * Mathf.Cos(test)),
                                      transform.position.y,
                                      (PosGet.TurnPos[TurnNum -1].transform.position.z + PosGet.TurnPos[TurnNum].transform.position.z) / 2);

        }

        RefPos = OriginPoint;
        StartP = transform.position;
        EndP = RefPos;



    }

    void Advance()
    {
        Vector3 velocity = gameObject.transform.forward * Speed;
        //gameObject.transform.position += velocity * Time.deltaTime;
        Depthdistance += Mathf.Abs(Speed * DushSpeed * Time.deltaTime);


    }

    void RLMove()
    {
        if (moveflg == true)
        {
            if (Input.GetAxis("Horizontal") > 0 && Sidedistance < Max)
            {
                Sidedistance += Time.deltaTime * 100;
            }
            if (Input.GetAxis("Horizontal") < 0 && Sidedistance > Min)
            {
                Sidedistance -= Time.deltaTime * 100;
            }
        }

        if (Sidedistance > Max) Sidedistance = Max;
        else if (Sidedistance < Min) Sidedistance = Min;


       

    }

    void TurnMove()
    {

        if (TurnNum / 2 == 0)
        {
            if ((TurnTime += Time.deltaTime * 135f / DisTime) > (TurnNum + 1) * 135f) TurnTime = (TurnNum + 1) * 135f;
            // クォータニオン → オイラー角への変換
            float rad = (135f - TurnTime) * Mathf.Deg2Rad;
            //基準点とプレイヤーの座標の距離の取得
            float distance = Vector3.Distance(Get(), StartP);

            transform.position = new Vector3(Get().x + (distance * Mathf.Cos(rad)),
                                        gameObject.transform.position.y,
                                        Get().z + (distance * Mathf.Sin(rad)));

            transform.rotation = Quaternion.Lerp(StartRot, EndRot, TurnTime / ((TurnNum + 1) * 135f));


            if (TurnTime / ((TurnNum + 1) * 135f) > 0.7f)
            { 
                if (++TurnNum >= 4) TurnNum = 0;
                TurnTime = TurnNum  * 135f;

                //基準点の更新
                NowPosGet();


                NowDis = Vector3.Distance(Get(), gameObject.transform.position);
                OldDis = Mathf.Infinity;
                //曲がりの終わり
                TurnCheck = false;
                AdjustmentFlg = true;
            }
        }
        else
        {
            int type = Mathf.Abs(TurnNum - 3) % 3;      //2を1に　3を0に

            if ((TurnTime -= Time.deltaTime * 135f / DisTime) < (type) * 135f) TurnTime = (type) * 135f;
            // クォータニオン → オイラー角への変換
            float rad = (405 -  TurnTime) * Mathf.Deg2Rad;
            //基準点とプレイヤーの座標の距離の取得
            float distance = Vector3.Distance(Get(), StartP);

            transform.position = new Vector3(Get().x + (distance * Mathf.Cos(rad)),
                                        gameObject.transform.position.y,
                                        Get().z + (distance * Mathf.Sin(rad)));

            transform.rotation = Quaternion.Lerp(StartRot, EndRot, Mathf.Abs((TurnTime - (type * 135)) - 135) / 135);


            if (Mathf.Abs((TurnTime - (type * 135)) - 135) / 135 >= 0.7f)
            {
                if (++TurnNum >= 4) TurnNum = 0;
                TurnTime = type * 135f;

                //基準点の更新
                NowPosGet();


                NowDis = Vector3.Distance(Get(), gameObject.transform.position);
                OldDis = Mathf.Infinity;
                //曲がりの終わり
                TurnCheck = false;
                AdjustmentFlg = true;
            }
        }
       
    }

    void ChildStop()
    {
        //子要素のモデルの座標を0に
        foreach (Transform child in gameObject.transform)
        {
            if (child.CompareTag("Player"))
            {
                child.transform.localPosition = Vector3.zero;
            }
        }
    }

    void PosCheck()
    {
        // クォータニオン → オイラー角への変換
        Vector3 rotationAngles = transform.rotation.eulerAngles;
        float rad = (rotationAngles.y) * Mathf.Deg2Rad;
        float test = (360 - rotationAngles.y) * Mathf.Deg2Rad;


        //最終的な移動の場所
        Vector3 PPos = new Vector3(RefPos.x + (Depthdistance * Mathf.Sin(rad)),
                                         transform.position.y,
                                         RefPos.z + (Depthdistance * Mathf.Cos(rad)));

        NowDis = Vector3.Distance(Get(), PPos);

        if (NowDis > OldDis)      //領域を超えたら
        {

            if (TurnNum / 2 == 0) Rotplus();
            else Rotminus();


            StartP = gameObject.transform.position;

            DisTime = Mathf.Abs(Sidedistance - 100) / 100;
            if (TurnNum >= 2) DisTime = Mathf.Abs(DisTime - 2);
            DisTime += 0.1f;
            TurnTime = rotationAngles.y;
            TurnCheck = true;
        }
        OldDis = Vector3.Distance(Get(), PPos);
    }

    Vector3 Get()
    {
        //曲がる位置の座標を取得
        TurnPosGet PosGet = Turn.gameObject.GetComponent<TurnPosGet>();
        return (PosGet.TurnPos[TurnNum].transform.position);
    }

    void Rotplus()
    {
        StartRot = transform.rotation;

        // クォータニオン → オイラー角への変換
        Vector3 rotationAngles = transform.rotation.eulerAngles;
        rotationAngles.y += 135;
        // オイラー角 → クォータニオンへの変換
        EndRot = Quaternion.Euler(rotationAngles);

    }
    void Rotminus()
    {
        StartRot = transform.rotation;
        // クォータニオン → オイラー角への変換
        Vector3 rotationAngles = transform.rotation.eulerAngles;
        rotationAngles.y -= 135;
        // オイラー角 → クォータニオンへの変換
        EndRot = Quaternion.Euler(rotationAngles);
    }

    void Dush()
    {
        if (runaway.DushFlg)DushSpeed = 1.5f;
        else DushSpeed = 1f;
    }

    void AdjustmentPos()
    {
        transform.position =  Vector3.Lerp(StartP, EndP, AdjustmentTime);

        transform.rotation = Quaternion.Lerp(StartRot, EndRot, 0.7f + (AdjustmentTime * 0.3f));

        if ((AdjustmentTime += Time.deltaTime * 3f) > 1f)
        {
            AdjustmentFlg = false;
            AdjustmentTime = 0f;

            int Roty = 0;
            Roty += (TurnNum % 2) * 135;
            if (TurnNum == 2) Roty = 270;

            transform.rotation = Quaternion.Euler(new Vector3(0, Roty, 0));
        }

    }
}
