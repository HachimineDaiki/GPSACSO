using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watchCon : MonoBehaviour
{
    [SerializeField]private GameObject stage;

    stageSpawner spawner;

    private bool ChageTim;
    private float RotSpeed;
    private int OldType,NewType;

    private float[] SXrot = { 0, -10f, 10f };       //X軸の向き

    private float[] SYrot = { 0, -120, 120 };

    Vector3 StartRot,EndRot;


    // Start is called before the first frame update
    void Start()
    {
        spawner = stage.GetComponent<stageSpawner>();
        RotSpeed = 0;
        OldType = spawner.CreatType % 3;
        NewType = spawner.CreatType % 3;
        ChageTim = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NewType = spawner.CreatType;

        Check();

        if (ChageTim)
        {
            Rotation();
        }


        OldType = spawner.CreatType;
    }

    void Check()
    {
        float ZrotS = 0f;
        float ZrotE = 0f;
        if (NewType >= 3) ZrotE = 180f;
        if (OldType >= 3) ZrotS = 180f;

        if (OldType != NewType)
        {
            ChageTim = true;
            StartRot = new Vector3(SXrot[OldType % 3], SYrot[OldType % 3], ZrotS);
            EndRot = new Vector3(SXrot[NewType % 3],SYrot[NewType % 3], ZrotE);
        }

       
    }

    void Rotation()
    {
        RotSpeed += Time.deltaTime / 3f;

        transform.rotation = Quaternion.Slerp(Quaternion.Euler(StartRot), Quaternion.Euler(EndRot), RotSpeed);


        if (RotSpeed > 1f)
        {
            RotSpeed = 0f;
            ChageTim = false;
            transform.rotation = Quaternion.Euler(EndRot);
        }
    }

}
