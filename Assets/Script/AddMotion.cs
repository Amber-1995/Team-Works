using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMotion : MonoBehaviour
{
    // �C���X�^���X����
    public static AddMotion instance;
    //���@�\�X�C�b�`
    public bool ClimbSwitch;
   

    // Start is called before the first frame update
    void Start()
    {
       if (instance == null)
       {
           instance = this;
       }

        Debug.Log("addmotion �N���e�X�g");
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    // �����蔻��
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�����蔻��N��");
        // �@�\�u���b�N�ƃN���C���u���b�N���ڑ������ꍇ���{�ɃN���C���@�\��ǉ�����
        if (collision.gameObject.CompareTag("ClimbBlock"))
        {
            // ���{�ɏ��@�\��ǉ�
            ClimbSwitch = true;
            Debug.Log("ClimbSwtich���I����Robo_KuNi.cs�ɑ���");
        }
    }
}
