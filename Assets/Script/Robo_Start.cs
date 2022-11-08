using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo_Start : MonoBehaviour
{
    /*
    //ステートの実行を管理するクラス
    public class StateProcessor
    {
        //ステート本体
        private Robo_Start _State;
        public Robo_Start State
        {
            set { _State = value; }
            get { return _State; }
        }

        // 実行ブリッジ
        public void Execute()
        {
            State.Execute();
        }

    }

    //ステートのクラス
    public abstract class Robo_Start6
    {
        //デリゲート
        public delegate void executeState();
        public executeState execDelegate;

        //実行処理
        public virtual void Execute()
        {
            if (execDelegate != null)
            {
                execDelegate();
            }
        }

        //ステート名を取得するメソッド
        public abstract string getStateName();
    }

    // 以下状態クラス

    //  運ぶ
    public class TextStateDefault : TextState
    {
        public override string getStateName()
        {
            return "State:Default";
        }
    }

    //  登る
    public class TextStateA : TextState
    {
        public override string getStateName()
        {
            return "State:A";
        }
    }

    //  破壊
    public class TextStateB : TextState
    {
        public override string getStateName()
        {
            return "State:B";
        }

        public override void Execute()
        {
            Debug.Log("特別な処理がある場合は子が処理してもよい");
            if (execDelegate != null)
            {
                execDelegate();
            }
        }
    }
    */
}
