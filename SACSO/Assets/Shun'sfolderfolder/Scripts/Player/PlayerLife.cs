using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    public int Life;
    [SerializeField] private const int MaxLife = 3;


    void Start()
    {
        Life = MaxLife;
    }
    private void Update()
    {
        if(transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    // Update is called once per frame

    public void Damege()
    {
        Life--;
        if(Life <= 0)
        {
            //ゲームオーバーへ
            SceneManager.LoadScene("GameOver");
        }
    }
}
