using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class TitleAnimation : MonoBehaviour
{
    [SerializeField] Canvas canvas;//canvasの取得
    [SerializeField] Canvas animationCanvas;//Animationcanvasの取得
    [SerializeField] GameObject titleRed;
    [SerializeField] Image titleBlue;
    [SerializeField] Image titleGreen;
    [SerializeField] Image titleMusleRunRogo;
    private float elapsedTime;
    private string elapsedAnimation;
    Animation RedAnim;
    Animation GreenAnim;
    Animation BlueAnim;
    Animation TitleAnim;

    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);//canvasの非表示
        animationCanvas.gameObject.SetActive(true);//animationCanvasを表示

        //アニメーションの取得
        RedAnim = titleRed.GetComponent<Animation>();
        GreenAnim = titleGreen.GetComponent<Animation>();
        BlueAnim = titleBlue.GetComponent<Animation>();
        TitleAnim = titleMusleRunRogo.GetComponent<Animation>();

        elapsedAnimation = "Green";
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;//経過時間
        if (!(canvas.gameObject.activeSelf))
        {
            Animation();//タイトルのアニメーション再生
        }
    }

    void Animation()
    {

        //ボタンが何か押されたらアニメーションを高速化する
        if (Input.anyKeyDown)
        {
            elapsedAnimation = "Title";
            BlueAnim.Play();
            RedAnim.Play();
            elapsedTime = 1.0f;
        }
        //elapsedTime
        if (elapsedTime > 2.0 && elapsedAnimation == "End")
        {
            canvasActiv();
        }

        if (elapsedTime > 0 && elapsedAnimation == "Green")
        {
            GreenAnim.Play();
            elapsedAnimation = "Blue";
        }
        else if (elapsedTime > 0.5 && elapsedAnimation == "Blue")
        {
            BlueAnim.Play();
            elapsedAnimation = "Red";
        }
        else if (elapsedTime > 1 && elapsedAnimation == "Red")
        {
            RedAnim.Play();
            elapsedAnimation = "Title";
        }
        else if (elapsedTime > 1.5 && elapsedAnimation == "Title")
        {
            TitleAnim.Play();
            elapsedAnimation = "End";
        }
    }

    void canvasActiv()//canvasをアクティブにする
    {
        canvas.gameObject.SetActive(true);//canvasの表示
        //animationCanvas.gameObject.SetActive(false);//animationCanvasの非表示
    }
}
