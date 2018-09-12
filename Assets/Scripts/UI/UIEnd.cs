using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnd : UIBase {

    public GameObject hero;

    public override string ParentName()
    {
        return "UIPlay";
    }

    public override string Name
    {
        get
        {
            return "PanelEnd";
        }
    }

    public void Continue()
    {
        hero.GetComponent<Character>().health = hero.GetComponent<Character>().defaultHealth;
        hero.GetComponent<Character>().alive = true;
        hero.GetComponent<Character>().immune = true;
        Time.timeScale = 1;
        Invoke("CancelImmune", 1.0f);   //1s后取消免疫状态
        UIManager.Instance.PopUIPanel();
        
    }

    public void Exit()
    {

        UIManager.Instance.PopAll();
        UIManager.Instance.PushUIPanel("UIBackg");
        //UIManager.Instance.PushUIPanel("PanelStart");
    }

    public override void OnEntering()
    {
        gameObject.SetActive(true);
        hero = GameObject.FindWithTag("Hero");
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
        hero = GameObject.FindWithTag("Hero");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CancelImmune()
    {
        hero.GetComponent<Character>().immune = false;
    }
}
