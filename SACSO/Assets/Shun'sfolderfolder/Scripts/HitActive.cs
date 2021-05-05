using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitActive : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject HitDetect;
    private NewPlayer play;

    [SerializeField] private const float AttackTime = 0.5f;

    void Start()
    {
        HitDetect.SetActive(false);

        play = gameObject.GetComponent<NewPlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
