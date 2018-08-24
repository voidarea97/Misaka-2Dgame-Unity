using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UIManager : MonoBehaviour {

    //单例模式
    private static UIManager _instance;
    public static UIManager Instance
    {
        get{
            return _instance;
        }
    }
    private Stack<UIBase> UIStack = new Stack<UIBase>();    //UI栈
    private Dictionary<string, GameObject> UIDict=new Dictionary<string, GameObject>(); //已加载资源目录
    private Dictionary<string, UIBase> currUIDict=new Dictionary<string, UIBase>(); //  已创建UI目录

    private Transform UIParent;
    public string ResourcesDir = "UI";  //资源路径

    //private void LoadUIResouces()
    //{
    //    string path = Application.dataPath + "/Resources/" + ResourcesDir;
    //    DirectoryInfo folder = new DirectoryInfo(path);
    //    foreach (FileInfo file in folder.GetFiles("*.Prefab"))
    //    {
    //        int index = file.Name.LastIndexOf(".");
    //        string UIName = file.Name.Substring(0, index);
    //        string UIPath = ResourcesDir + "/" + UIName;
    //        GameObject UIObject = Resources.Load<GameObject>(UIPath);
    //        UIDict.Add(UIName, UIObject);
    //    }
    //}

    public void PushUIPanel(string UIName)  //UI入栈
    {
        
        if(UIStack.Count>0) //栈不为空
        {
            if (UIStack.Peek().Name == UIName)
                return;
            UIBase OldTopUI = UIStack.Peek();
            OldTopUI.OnPausing();
        }
        UIBase NewTopUI = GetUIBase(UIName);
        NewTopUI.OnEntering();
        UIStack.Push(NewTopUI);

    }

    public void PopUIPanel()    //UI出栈
    {
        if(UIStack.Count==0)
        {
            return;
        }
        UIBase oldTopUI = UIStack.Pop();
        oldTopUI.OnExitng();
        if (UIStack.Count>0)
        {
            UIStack.Peek().OnResuming();
        }
    }
    public void PopAll()
    {
        while (UIStack.Count > 0)
        {
            UIBase oldTopUI = UIStack.Pop();
            oldTopUI.OnExitng();
            if(UIStack.Count>0)
                UIStack.Peek().OnResuming();
        }
        return;
    }
    private UIBase GetUIBase(string UIName)
    {
        foreach(var name in currUIDict.Keys)    //该UI面板已创建
        {
            if(name==UIName)
            {
                return currUIDict[name];
            }
        }

        //从Prefab创建UI面板
        GameObject UIPrefab = UIDict[UIName];
        GameObject UIObject = GameObject.Instantiate<GameObject>(UIPrefab);

        UIBase uiBase = UIObject.GetComponent<UIBase>();
        if (uiBase.ParentName() != "")
        {
            UIParent = (GameObject.Find(uiBase.ParentName())).transform;

            UIObject.transform.SetParent(UIParent, false);
        }

        UIObject.name = UIName;
        
        
        currUIDict.Add(UIName, uiBase);
        return uiBase;
    }

    public void LoadResouce(string name)    //加载资源
    {
        string UIPath = ResourcesDir + "/" + name;
        GameObject UIObject = Resources.Load<GameObject>(UIPath);
        if(UIObject)
            UIDict.Add(name, UIObject);
    }

	// Use this for initialization
	void Awake ()
    {
        _instance = this;
        //LoadUIResouces();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
