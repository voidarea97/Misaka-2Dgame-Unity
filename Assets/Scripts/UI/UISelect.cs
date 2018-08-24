using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelect : UIBase {
    public override string Name
    {
        get
        {
            return "PanelSelect";
        }
    }
    public override string ParentName()
    {
        return "UIBackg";
    }

    public void BackToStart()
    {
        UIManager.Instance.PopUIPanel();
        //UIManager.Instance.PushUIPanel("UIBackg");
    }
    public void Goto1st()
    {
        UIManager.Instance.PopAll();
        UIManager.Instance.PushUIPanel("UIPlay");
        Time.timeScale = 1;
    }
    
    public override void OnEntering()
    {
        gameObject.SetActive(true);
    }

    public override void OnExitng()
    {
        gameObject.SetActive(false);
    }

    public override void OnPausing()
    {
        gameObject.SetActive(false);
    }

    public override void OnResuming()
    {
        gameObject.SetActive(true);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
