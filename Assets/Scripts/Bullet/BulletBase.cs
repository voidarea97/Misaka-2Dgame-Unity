using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour {

    private Rigidbody2D bulletRigidbody;


    public float speedX;
    public float speedY;
    public int kind;    //0:近战    1:飞行    2：
    public float damage;
    public float survivalTime;  //生存时间
    public float survivalCollision; //可碰撞次数
    public bool xDirection;

    public bool noDestroy; //设置active而非销毁对象

    public float slowTime;  //减速时间
    public float paralyseTime;  //麻痹时间

    public Vector2 direction;

    public GameObject belong;   //所属


	void Start () {
        bulletRigidbody = gameObject.GetComponent<Rigidbody2D>();
        if (!xDirection)
            speedX = -speedX;
        if(bulletRigidbody)
        bulletRigidbody.velocity = new Vector2(speedX, speedY); //初始化子弹速度与方向
    }
	
	void Update () {
		
	}

    virtual protected void FixedUpdate()
    {
        survivalTime -= Time.deltaTime;
        //bulletRigidbody.velocity = new Vector2(speedX, speedY);
        if (survivalCollision<=0||survivalTime<=0)   //子弹碰撞次数或生存时间耗尽，销毁子弹
        {
            gameObject.SetActive(false);
            if(!noDestroy)
            Destroy(gameObject);
        }
        
    }
}
