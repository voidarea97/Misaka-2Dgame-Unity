using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWin : UIBase {
    public override string ParentName()
    {
        return "UIPlay";
    }

    public override string Name
    {
        get
        {
            return "PanelWin";
        }
    }

    public void Next()
    {
        //获取当前Chapter编号
        int num = gameObject.GetComponent<UnloadChapter>().chapterNow.GetComponent<Chapter>().num;
        //卸载当前，加载下一Chapter
        gameObject.GetComponent<UnloadChapter>().Unload();
        gameObject.GetComponent<LoadChapter>().Load(num+1);
        Time.timeScale = 1;
        UIManager.Instance.PopUIPanel();

    }

    public void Select()
    {
        gameObject.GetComponent<UnloadChapter>().Unload();
        UIManager.Instance.PopAll();
        UIManager.Instance.PushUIPanel("UIBackg");
        UIManager.Instance.PushUIPanel("PanelSelect");
    }

    public override void OnEntering()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public override void OnExitng()
    {
        gameObject.SetActive(false);
        //Time.timeScale = 1; //恢复游戏
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
