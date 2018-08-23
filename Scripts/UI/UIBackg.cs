using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBackg : UIBase {


    public override string Name
    {
        get
        {
            return "UIBackg";
        }
    }

    public override string ParentName()
    {
        return "UI";
    }

    public override void OnEntering()
    {
        gameObject.SetActive(true);
        GetComponent<Canvas>().worldCamera = Camera.main;
        UIManager.Instance.PushUIPanel("PanelStart");
        AudioManager.Instance.PlayBGM("BGM");
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
