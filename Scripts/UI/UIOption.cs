using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOption : UIBase {

    public GameObject BtnBGMOff;
    public GameObject BtnSoundOff;

    public override string ParentName()
    {
        return "UIBackg";
    }


    public void BGMOnOff(bool mute)
    {
        AudioManager.Instance.Mute=mute;
    }


    public void SoundOnOff()
    {
        
    }


    public void BackToStart()
    {
        UIManager.Instance.PopUIPanel();
    }
    public override string Name
    {
        get
        {
            return "PanelOption";
        }
    }
    public override void OnEntering()
    {
        //GetComponent<Canvas>().worldCamera = Camera.main;
        gameObject.SetActive(true);

        //设置音乐开关初始状态
        if (AudioManager.Instance.Mute)
        {
            BtnBGMOff.SetActive(true);
        }
        else
        {
            BtnBGMOff.SetActive(false);
        }
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
