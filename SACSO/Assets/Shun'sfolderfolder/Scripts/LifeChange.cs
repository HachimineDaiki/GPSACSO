using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeChange : MonoBehaviour
{
    // Start is called before the first frame update

    public Image LifeImage;
    [SerializeField] private Sprite Green, Yellow, Red;
    private PlayerLife playerLife;
    void Start()
    {
        LifeImage.sprite = Green;
        playerLife = GameObject.Find("musslepants2Unity").GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLife.Life == 3)
        {

            LifeImage.sprite = Green;
        }
        else if(playerLife.Life== 2)
        {

            LifeImage.sprite = Yellow;
        }
        else
        {
            LifeImage.sprite = Red;

        }

    }
}
