using UnityEngine;
using System.Collections;
//using TextState;
//using UniRx;
using UnityEngine.UI;
using System;

public class Robo_Controller : MonoBehaviour
{
    /*
    //変更前のステート名
    private string _beforeStateName;

    //ステート
    public StateProcessor StateProcessor = new StateProcessor();           //プロセッサー
    public TextStateDefault StateDefault = new TextStateDefault();
    public TextStateA StateA = new TextStateA();
    public TextStateB StateB = new TextStateB();

    // Use this for initialization
    void Start()
    {

        //DefaultState
        StateProcessor.State = StateDefault;
        StateDefault.execDelegate = Default;
        StateA.execDelegate = A;
        StateB.execDelegate = B;

    }

    // Update is called once per frame
    void Update()
    {

        //ステートの値が変更されたら実行処理を行う
        if (StateProcessor.State == null)
        {
            return;
        }

        if (StateProcessor.State.getStateName() != _beforeStateName)
        {
            Debug.Log(" Now State:" + StateProcessor.State.getStateName());
            _beforeStateName = StateProcessor.State.getStateName();
            StateProcessor.Execute();
        }

    }

    public void Default()
    {
        gameObject.transform.GetComponent<Text>().text = "初期状態です";
        //１秒後にStateAに状態遷移
        Observable
            .Timer(TimeSpan.FromSeconds(1))
            .Subscribe(x => StateProcessor.State = StateA);
    }

    public void A()
    {
        gameObject.transform.GetComponent<Text>().text = "StateAです";
        //１秒後にStateBに状態遷移
        Observable
            .Timer(TimeSpan.FromSeconds(1))
            .Subscribe(x => StateProcessor.State = StateB);
    }

    public void B()
    {
        gameObject.transform.GetComponent<Text>().text = "StateBです";
        //１秒後にDefaultに状態遷移
        Observable
            .Timer(TimeSpan.FromSeconds(1))
            .Subscribe(x => StateProcessor.State = StateDefault);

    }
    */
}
