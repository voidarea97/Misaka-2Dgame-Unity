using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStart : UIBase {

    public override string ParentName()
    {
        return "UIBackg";
    }

    public void GoToOption()
    {
        UIManager.Instance.PushUIPanel("PanelOption");
    }
    public void GoToSelect()
    {
        UIManager.Instance.PushUIPanel("PanelSelect");
    }

    public override string Name
    {
        get
        {
            return "PanelStart";
        }
    }
    public override void OnEntering()
    {
        //GetComponent<Canvas>().worldCamera = Camera.main;
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
