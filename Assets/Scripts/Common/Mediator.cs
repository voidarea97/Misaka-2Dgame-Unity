using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mediator : MonoBehaviour {
    //此类用于场景角色等与UI的通信

    private UIPlay uiPlay;
    private Statistic statistic;

    #region Singleton
    private static Mediator instance;
    private Mediator() { }
    public static Mediator Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        
    }

    public void FindUIPlay()
    {
        uiPlay = GameObject.Find("/UI/UIPlay").GetComponent<UIPlay>();
    }

    public void SetUIPlay(UIPlay ui)
    {
        uiPlay = ui;
    }

    public void ShowDamage(GameObject obj, float num)
    {
        uiPlay.ShowDamage(obj, num);
    }

    public void SetAddBtn(bool b)   //设置添加按钮可见性
    {
        uiPlay.SetAddBtn(b);
    }
}
