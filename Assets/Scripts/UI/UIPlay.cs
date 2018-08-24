using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlay : UIBase {

    public override string Name
    {
        get
        {
            return "UIPlay";
        }
    }

    public override string ParentName()
    {
        return "UI";
    }

    public void BackToStart()
    {
        UIManager.Instance.PopUIPanel();
        UIManager.Instance.PushUIPanel("Backg");

    }
    public void PlayOption()
    {
        UIManager.Instance.PushUIPanel("PanelPlayOption");
    }
    public void GoToSelect()
    {
        UIManager.Instance.PushUIPanel("PanelSelect");
    }


    public override void OnEntering()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        gameObject.SetActive(true);
    }

    public override void OnExitng()
    {
        gameObject.SetActive(false);
    }

    public override void OnPausing()
    {
        //gameObject.SetActive(false);
    }

    public override void OnResuming()
    {
        //gameObject.SetActive(true);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
