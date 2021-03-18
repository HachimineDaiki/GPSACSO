using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    public int Life;
    [SerializeField] private const int MaxLife = 3;


    void Start()
    {
        Life = MaxLife;
    }

    // Update is called once per frame
    
    public void Damege()
    {
        Life--;
        if(Life <= 0)
        {
            //ゲームオーバーへ

        }
    }
}
