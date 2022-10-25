using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeController : MonoBehaviour
{
    float fadespeed = 0.002f; //�����x���ς��X�s�[�h���Ǘ�
    float red, green, blue, alfa; //�p�l���̐F(�ԁA�΁A��)�A�s�����x���Ǘ�

    //�t�F�[�h�A�E�g�����̊J�n�A�������Ǘ�����t���O
    public bool isFadeOut = false;
    //�t�F�[�h�C�������̊J�n�A�������Ǘ�����t���O
    public bool isFadeIn = false;
    Image fadeimage; //�����x��ύX����p�l���̃C���[�W

    void Start()
    {
        //Panel��Image�R���|�[�l���g���I���ɕύX
        //GetComponent<Image>().enabled = true;

        //Image�̃J���[��ύX�BColor�̈����́i ��, ��, ��, �s�����x �j�̏��Ŏw��
        //GetComponent<Image>().color = new Color(255, 0, 0, 0.5f);

        //�p�l���̗p�ӂ���
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
            StartfadeIn(); //�t�F�[�h�C���֐�
        }
        if (isFadeOut)
        {
            StartfadeOut();//�t�F�[�h�A�E�g�֐�
        }
    }


    void StartfadeIn()
    {
        alfa -= fadespeed;        //�s�����x�����X�ɉ�����
        SetAlpha();               //�ύX�����s�����x�p�l���ɔ��f����
        if (alfa <= 0)            //���S�ɓ����ɂȂ����珈���𔲂���
        {
            isFadeIn = false;
            fadeimage.enabled = false; //�p�l���̕\�����I�t�ɂ���
        }
    }


    void StartfadeOut()
    {
        fadeimage.enabled = true; // �p�l���̕\�����I���ɂ���
        alfa += fadespeed;        // �s�����x�����X�ɂ�����
        SetAlpha();               // �ύX���������x���p�l���ɔ��f����
        if (alfa >= 1)            // ���S�ɕs�����ɂȂ����珈���𔲂���
        {
            isFadeOut = false;
        }
    }

    void SetAlpha()
    {
        fadeimage.color = new Color(red, green, blue, alfa);
    }


}
