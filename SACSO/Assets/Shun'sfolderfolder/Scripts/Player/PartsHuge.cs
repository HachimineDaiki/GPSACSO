using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsHuge : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform RightArm;
    [SerializeField] private Transform LefttArm;

    private float RightHugeRate, LeftHugeRate;

    private static float HugeRate = 0.05f;
    private static float SmallRate = 0.1f;

    Vector3 StartScale = new Vector3(1f, 1f, 1f);
    Vector3 LastScale = new Vector3(2f, 1.5f, 3f);


    void Start()
    {
        RightHugeRate = 0f;
        LeftHugeRate = 0f;


    }

    // Update is called once per frame
    void Update()
    {
        HugeTest();

        RightArm.localScale = Vector3.Lerp(StartScale, LastScale, RightHugeRate);
        LefttArm.localScale = Vector3.Lerp(StartScale, LastScale, LeftHugeRate);
    }

    public void HugeRight()
    {
        if(RightHugeRate <= 1f)
        {
            RightHugeRate += HugeRate;
        }
    }

    public void SmallRight()
    {
        if (RightHugeRate >= 0f)
        {
            RightHugeRate -= SmallRate;
        }
    }

    public void HugeLeft()
    {
        if (LeftHugeRate <= 1f)
        {
            LeftHugeRate += HugeRate;
        }
    }

    public void SmallLeft()
    {
        if (LeftHugeRate <= 0f)
        {
            LeftHugeRate -= SmallRate;
        }
    }



    /*テスト関数*/
    void HugeTest()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            HugeRight();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            HugeLeft();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            HugeRight();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            HugeLeft();
        }
    }
}
