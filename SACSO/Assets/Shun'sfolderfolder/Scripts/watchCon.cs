using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watchCon : MonoBehaviour
{
    [SerializeField]private GameObject stage;

    stageSpawner spawner;

    [SerializeField] private bool ChageTim;
    [SerializeField] private float RotSpeed;
    private int OldType,NewType;
    private int num;


    private float[] SYrot = { 120, 0, -120 };
    private float[] Yrot = { 0, -120, 120 };

    [SerializeField] Vector3 StartRot,EndRot;


    // Start is called before the first frame update
    void Start()
    {
        spawner = stage.GetComponent<stageSpawner>();
        RotSpeed = 0;
        OldType = spawner.CreatType;
        NewType = spawner.CreatType;
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
        if (NewType == 0)
        {
            num = 0;
        }
        else if (NewType == 3)
        {
            num = 1;
        }
        else
        {
            num = 2;
        }

        if (OldType != NewType)
        {
            ChageTim = true;
            StartRot = new Vector3(transform.rotation.x, SYrot[num], transform.rotation.z);
            EndRot = new Vector3(transform.rotation.x,Yrot[num], transform.rotation.z);
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
        }
    }

}
