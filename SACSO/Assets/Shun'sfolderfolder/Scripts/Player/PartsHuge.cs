using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsHuge : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform RightArm;
    [SerializeField] private Transform LefttArm;

    private float RightHugeRate, LeftHugeRate;

    private static float HugeRate = 0.34f;
    private static float SmallRate = 0.05f;

    Vector3 StartScale = new Vector3(1f, 1f, 1f);
    Vector3 LastScale = new Vector3(3f, 1f, 3f);

    public int AttackInfo = 0;      //0:ラン1:右パンチ2:左パンチ
    private float AttackGracetime = 0;

    private int[] HugeType = { 0, 0 };

    private int NextEv = 5;

    void Start()
    {
        RightHugeRate = 0f;
        LeftHugeRate = 0f;

        AttackInfo = 0;
        AttackGracetime = 0f;
        HugeType[0] = 0;
        HugeType[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //HugeTest();
        AttackTime();

        RightArm.localScale = Vector3.Lerp(StartScale, LastScale, RightHugeRate);
        LefttArm.localScale = Vector3.Lerp(StartScale, LastScale, LeftHugeRate);
    }

    public void HugeRight()
    {
        if(RightHugeRate < 1f)
        {
            RightHugeRate += HugeRate;
            if (RightHugeRate > 1f) RightHugeRate = 1f;
        }
    }

    public void SmallRight()
    {
        if (RightHugeRate > 0f)
        {
            RightHugeRate -= SmallRate;
            if (RightHugeRate < 0f) RightHugeRate = 0f;
        }
    }

    public void HugeLeft()
    {
        if (LeftHugeRate < 1f)
        {
            LeftHugeRate += HugeRate;
            if (LeftHugeRate > 1f) LeftHugeRate = 1f;
        }
    }

    public void SmallLeft()
    {
        if (LeftHugeRate < 0f)
        {
            LeftHugeRate -= SmallRate;
            if (LeftHugeRate < 0f) LeftHugeRate = 0f;
        }
    }



    /*テスト関数*/
    void HugeTest()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AttackInfo = 1;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            AttackInfo = 2;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            AttackInfo = 1;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            AttackInfo = 2;
        }
    }

    void AttackTime()
    {
        if(AttackGracetime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                AttackInfo = 1;
                AttackGracetime = 0.4f;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                AttackInfo = 2;
                AttackGracetime = 0.4f;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                AttackInfo = 1;
                AttackGracetime = 0.4f;
            }
            if (Input.GetButtonDown("Fire2"))
            {
                AttackInfo = 2;
                AttackGracetime = 0.4f;
            }
        }

        if(AttackGracetime > 0)
        {
            AttackGracetime -= Time.deltaTime;
            if (AttackGracetime < 0) AttackGracetime = 0;
        }
        
    }

    public void HugeParts(int type)        //1:右パンチ2:左パンチ
    {
        //if(type == 1)
        //{
        //    if(HugeType[type-1]++ >= 10)
        //    {
        //        HugeRight();
        //        HugeType[type - 1] = 0;
        //    }
        //}else if(type == 2)
        //{
        //    if (HugeType[type - 1]++ >= 10)
        //    {
        //        HugeLeft();
        //        HugeType[type - 1] = 0;
        //    }
        //}

        if (HugeType[type - 1]++ >= NextEv)
        {
            if (type == 1)
            {
                HugeRight();
            }
            else if(type == 2)
            {
                HugeLeft();
            }
                HugeType[type - 1] = 0;
        }
    }
}
