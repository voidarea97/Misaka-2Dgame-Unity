using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlay : UIBase {

    public GameObject damageNumPrefab;

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

    public void ShowDamage(GameObject pos, float num)      //显示伤害数字
    {
        GameObject damageNum = Instantiate(damageNumPrefab,pos.transform.position,gameObject.transform.rotation);
        damageNum.transform.SetParent(gameObject.transform);
        damageNum.transform.localScale = new Vector3(1, 1, 1);

        damageNum.GetComponent<DamageNumFollow>().Getcharacter(pos);

        damageNum.GetComponent<Text>().text = num.ToString();
        StartCoroutine(DestroyDamageNum(damageNum));
    }

    protected IEnumerator DestroyDamageNum(GameObject damNum) //延时销毁伤害数字
    {
        for (float i = 1.5f; i >= 0; i -= Time.deltaTime)
            yield return 0;
        Destroy(damNum);
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

    void Awake () {
		damageNumPrefab= Resources.Load<GameObject>("UI/Components/DamageNum");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
