using UnityEngine;
using System.Collections;
using TextState;
using UniRx;
using UnityEngine.UI;
using System;

public class Robo_Controller : MonoBehaviour
{
    //�ύX�O�̃X�e�[�g��
    private string _beforeStateName;

    //�X�e�[�g
    public StateProcessor StateProcessor = new StateProcessor();           //�v���Z�b�T�[
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

        //�X�e�[�g�̒l���ύX���ꂽ����s�������s��
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
        gameObject.transform.GetComponent<Text>().text = "������Ԃł�";
        //�P�b���StateA�ɏ�ԑJ��
        Observable
            .Timer(TimeSpan.FromSeconds(1))
            .Subscribe(x => StateProcessor.State = StateA);
    }

    public void A()
    {
        gameObject.transform.GetComponent<Text>().text = "StateA�ł�";
        //�P�b���StateB�ɏ�ԑJ��
        Observable
            .Timer(TimeSpan.FromSeconds(1))
            .Subscribe(x => StateProcessor.State = StateB);
    }

    public void B()
    {
        gameObject.transform.GetComponent<Text>().text = "StateB�ł�";
        //�P�b���Default�ɏ�ԑJ��
        Observable
            .Timer(TimeSpan.FromSeconds(1))
            .Subscribe(x => StateProcessor.State = StateDefault);

    }
}
