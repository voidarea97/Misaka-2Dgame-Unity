using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //加载资源
        UIManager.Instance.LoadResouce("UIBackg");
        UIManager.Instance.LoadResouce("UIPlay");
        UIManager.Instance.LoadResouce("PanelStart");
        UIManager.Instance.LoadResouce("PanelOption");
        UIManager.Instance.LoadResouce("PanelSelect");
        UIManager.Instance.LoadResouce("PanelPlayOption");
        UIManager.Instance.LoadResouce("PanelEnd");
        //入栈初始背景UI
        UIManager.Instance.PushUIPanel("UIBackg");

    }

    // Update is called once per frame
    void Update () {
		
	}
}
