using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeChange : MonoBehaviour
{
    // Start is called before the first frame update

    public Image LifeImage;
    [SerializeField] private GameObject image_G;
    [SerializeField] private GameObject image_Y;
    [SerializeField] private GameObject image_R;
    private PlayerLife playerLife;
    void Start()
    {
        //LifeImage.sprite = Green;
        playerLife = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerLife.Life == 2 && image_G.activeSelf)
        {
            image_G.SetActive(!image_G.activeSelf);
        }
        if(playerLife.Life== 1 && image_Y.activeSelf)
        {
            image_Y.SetActive(!image_Y.activeSelf);
        }
        //if
        //{
        //    image_R.SetActive(!image_R.activeSelf);

        //}

    }
}
