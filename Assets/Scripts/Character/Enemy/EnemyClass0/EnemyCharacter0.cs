using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter0 : Character {

    //public Mediator mediator;   //中介类，用于场景和UI的通信
    
    public override void BeHit(BulletBase bulletBase)
    {
        
        //health -= bulletBase.damage;    //损失生命值等于子弹伤害

        //显示伤害数字
        //uiplay.ShowDamage(gameObject, bulletBase.damage);
        Mediator.Instance.ShowDamage(gameObject, bulletBase.damage);
    }

    protected override void Start () {

        //mediator = GameObject.Find("/Chapters/ChapterNow/Mediator").GetComponent<Mediator>();
        name = "木桩";
    }
	
	// Update is called once per frame
	protected override void Update () {
		
	}
}
