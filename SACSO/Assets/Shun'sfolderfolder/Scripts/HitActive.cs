using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitActive : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject HitDetect;
    float HitTime;      //攻撃有効時間
    private Pmove play;

    [SerializeField] private const float AttackTime = 0.5f;

    void Start()
    {
        HitDetect.SetActive(false);
        HitTime = 0f;

        play = GameObject.Find("MuscleHuman").GetComponent<Pmove>();
    }

    // Update is called once per frame
    void Update()
    {
        HitAct();
    }

    void HitAct()
    {
        if (play.punch)
        {
            HitDetect.SetActive(true);
        }
        else
        {
            HitDetect.SetActive(false);
        }
    }
}
