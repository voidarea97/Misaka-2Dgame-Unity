using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyAdder : UIBase {

    private CharacterGenerator generator;
    private Dictionary<int, string> nameDic;

    private int enemyClass; //num:0
    private float atk;      //1
    private float health;   //2
    private float speedX;   //3
    private float speedY;   //4

    //private float[] values;
    

    public Text textEnemyClass;
    public Text textAtk;
    public Text textHealth;
    public Text textSpeedX;
    public Text textSpeedY;

    public override string ParentName()
    {
        return "UIPlay";
    }
    public override string Name
    {
        get
        {
            return "PanelEnemyAdder";
        }
    }

    public void ChangeClass(int values)
    {
        enemyClass += values;
        enemyClass = (enemyClass + 2) % 2;
        textEnemyClass.text = nameDic[enemyClass];
    }
    public void ChangeAtk(float values)
    {
        atk += values;
        if (atk < 0.01f)
            atk = 0;
        else
            atk = (float)Math.Round(atk, 2);
        textAtk.text = atk.ToString();
    }

    public void ChangeHealth(float values)
    {
        health += values;
        if (health < 0.01f)
            health = 0;
        else
            health = (float)Math.Round(health, 2);
        textHealth.text = health.ToString();
    }
    public void ChangeSpeedX(float values)
    {
        speedX += values;
        if (speedX < 0.01)
            speedX = 0;
        else
            speedX = (float)Math.Round(speedX, 2);
        textSpeedX.text = speedX.ToString();
    }
    public void ChangeSpeedY(float values)
    {
        speedY += values;
        if (speedY < 0.01)
            speedY = 0;
        else
            speedY = (float)Math.Round(speedY, 2);
        textSpeedY.text = speedY.ToString();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        UIManager.Instance.PopUIPanel();
    }

    public void GenerateEnemy()
    {
        generator.Generate(enemyClass, atk, 0, health, speedX, speedY);
    }

    public override void OnEntering()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
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
    
    void Start () {

        generator = GameObject.FindWithTag("Generator").GetComponent<CharacterGenerator>();
        nameDic = new Dictionary<int, string>();
        nameDic.Add(0, "木桩");
        nameDic.Add(1, "普通1");
        
        enemyClass = 0;
        atk = 10;
        health = 50;
        speedX = 1;
        speedY = 0.5f;
        textEnemyClass.text = nameDic[enemyClass];
        textAtk.text = atk.ToString();
        textHealth.text = health.ToString();
        textSpeedX.text = speedX.ToString();
        textSpeedY.text = speedY.ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
