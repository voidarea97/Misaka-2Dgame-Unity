using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayOption : UIBase
{
    public GameObject BtnBGMOff;
    public GameObject BtnSoundOff;

    public override string ParentName()
    {
        return "UIPlay";
    }


    public void BGMOnOff(bool mute)
    {
        AudioManager.Instance.Mute = mute;
    }


    public void SoundOnOff()
    {

    }


    public void BackToSelect()
    {
        UIManager.Instance.PopAll();
        UIManager.Instance.PushUIPanel("UIBackg");
        //UIManager.Instance.PushUIPanel("PanelStart");
        //UIManager.Instance.PushUIPanel("PanelSelect");
    }

    public void Resume()
    {
        Time.timeScale = 1; //恢复游戏
        UIManager.Instance.PopUIPanel();

    }
    public override string Name
    {
        get
        {
            return "PanelPlayOption"; 
        }
    }
    public override void OnEntering()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0; //暂停游戏

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

    void Start()
    {

    }


    void Update()
    {

    }
}
