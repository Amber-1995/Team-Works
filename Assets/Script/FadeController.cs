using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeController : MonoBehaviour
{
    float fadespeed = 0.002f; //透明度が変わるスピードを管理
    float red, green, blue, alfa; //パネルの色(赤、緑、青)、不透明度を管理

    //フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeOut = false;
    //フェードイン処理の開始、完了を管理するフラグ
    public bool isFadeIn = false;
    Image fadeimage; //透明度を変更するパネルのイメージ

    void Start()
    {
        //PanelのImageコンポーネントをオンに変更
        //GetComponent<Image>().enabled = true;

        //Imageのカラーを変更。Colorの引数は（ 赤, 緑, 青, 不透明度 ）の順で指定
        //GetComponent<Image>().color = new Color(255, 0, 0, 0.5f);

        //パネルの用意する
        fadeimage = GetComponent<Image>();
        red = fadeimage.color.r;
        green = fadeimage.color.g;
        blue = fadeimage.color.b;
        alfa = fadeimage.color.a;
    }


    void Update()
    {
        if (isFadeIn)
        {
            StartfadeIn(); //フェードイン関数
        }
        if (isFadeOut)
        {
            StartfadeOut();//フェードアウト関数
        }
    }


    void StartfadeIn()
    {
        alfa -= fadespeed;        //不透明度を徐々に下げる
        SetAlpha();               //変更した不透明度パネルに反映する
        if (alfa <= 0)            //完全に透明になったら処理を抜ける
        {
            isFadeIn = false;
            fadeimage.enabled = false; //パネルの表示をオフにする
        }
    }


    void StartfadeOut()
    {
        fadeimage.enabled = true; // パネルの表示をオンにする
        alfa += fadespeed;        // 不透明度を徐々にあげる
        SetAlpha();               // 変更した透明度をパネルに反映する
        if (alfa >= 1)            // 完全に不透明になったら処理を抜ける
        {
            isFadeOut = false;
        }
    }

    void SetAlpha()
    {
        fadeimage.color = new Color(red, green, blue, alfa);
    }


}
