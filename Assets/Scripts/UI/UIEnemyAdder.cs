using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyAdder : UIBase {

    private int enemyClass; //num:0
    private float atk;      //1
    private float health;   //2
    private float speedX;   //3
    private float speedY;   //4

    private float[] values;
    //private float[]

    public Text textEnemyClass;
    public Text textAtk;
    public Text textHealth;
    public Text textSpeedX;
    public Text textSpeedY;

    public override string ParentName()
    {
        return "UIPlay";
    }

    public void ChangeValue(bool plus,int num)
    {

    }

    // Use this for initialization
    void Start () {
		values=new float[5];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
