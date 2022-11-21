using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMotion : MonoBehaviour
{
    // インスタンス生成
    public static AddMotion instance;
    //上り機能スイッチ
    public bool ClimbSwitch;
   

    // Start is called before the first frame update
    void Start()
    {
       if (instance == null)
       {
           instance = this;
       }

        Debug.Log("addmotion 起動テスト");
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    // 当たり判定
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("当たり判定起動");
        // 機能ブロックとクライムブロックが接続した場合ロボにクライム機能を追加する
        if (collision.gameObject.CompareTag("ClimbBlock"))
        {
            // ロボに上り機能を追加
            ClimbSwitch = true;
            Debug.Log("ClimbSwtichをオン→Robo_KuNi.csに続く");
        }
    }
}
