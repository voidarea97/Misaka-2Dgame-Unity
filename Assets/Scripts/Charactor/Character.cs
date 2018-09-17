using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//角色属性基类
public class Character : MonoBehaviour {

    public UnityEvent die;

    public bool alive;
    public float health;
    public float defaultHealth;
    public bool immune; //免疫伤害
    public float phyAtk;    //物理攻击力
    public float magAtk;    //魔法攻击力
    public float speedX;
    public float speedY;
    public int kind;   //0:hero    101-199:enemy    201-299:weapon

    public bool xDirection; //角色x轴朝向  1：右

    public int state;   //异常状态
    public bool action;  //可行动

    virtual public void BeHit(BulletBase bulletBase) { }   //被击中

    public float halfy =0;

    virtual protected void Start () {
        //alive = 1;
        //设置底部偏移位置
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer)
        {
            halfy = spriteRenderer.bounds.size.y * 0.5f;
        }
        
	}
	
	virtual protected void Update () {

	}
    virtual protected void FixedUpdate()
    {
        //根据sprite底部y轴位置设定z轴位置，实现层次遮挡效果

        gameObject.transform.position = 
            new Vector3(transform.position.x, transform.position.y, (transform.position.y-halfy) / 3.0f);
        if (alive && health <= 0)
        {
            alive = false;
            die.Invoke();
        }
    }
}
