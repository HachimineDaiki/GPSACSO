using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitActive : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject HitDetect;
    float HitTime;      //攻撃有効時間

    [SerializeField] private const float AttackTime = 0.5f;

    void Start()
    {
        HitDetect.SetActive(false);
        HitTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(HitTime <= 0f)
        {
            HitAct();
        }
        Timer();
        ChangeActive();

    }

    void HitAct()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            HitDetect.SetActive(true);
            HitTime = AttackTime;
        }
    }

    void Timer()
    {
        if(HitTime > 0f)
        {
            HitTime -= Time.deltaTime;

        }
    }

    void ChangeActive()
    {
        if(HitTime > 0f) HitDetect.SetActive(true);
        else HitDetect.SetActive(false);
    }
}
