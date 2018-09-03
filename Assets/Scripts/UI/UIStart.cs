using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIStart : UIBase {

    public GameObject btnStart;
    public GameObject btnOption;

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
        btnOption.GetComponent<Button>().enabled = false;
        btnStart.GetComponent<Button>().enabled = false;
        //gameObject.SetActive(false);
    }

    public override void OnResuming()
    {
        btnOption.GetComponent<Button>().enabled = true;
        btnStart.GetComponent<Button>().enabled = true;
        gameObject.SetActive(true);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
