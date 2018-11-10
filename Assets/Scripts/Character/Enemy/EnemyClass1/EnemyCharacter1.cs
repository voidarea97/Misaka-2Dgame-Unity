using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter1 : Character {

    public Mediator mediator;   //中介类，用于场景和UI的通信
    //public UIPlay uiplay;
    //public GameObject atk;
    public string bulletPath;   //攻击子弹prefab存储路径
    private GameObject atkBulletPrefab;     //子弹prefab

    private Transform heroTransform;
    private Character heroCharacter;
    private Rigidbody2D selfRigidbody;
    private EnemyAnime anime;  

    private float searchTimeDelay;    //搜寻目标延时
    public float searchTime;
    private float atkTimeDelay;     //攻击延时
    public float atkTime;

    private Vector3 rotPositive;    //x轴正向
    private Vector3 rotNegative;    //x反向

    public override void BeHit(BulletBase bulletBase)
    {
        if(anime)
        {
            anime.TriggerBehit();
        }
        health -= bulletBase.damage;    //损失生命值等于子弹伤害

        //显示伤害数字
        //Vector2 numPos = gameObject.transform.position;
        //numPos.y += 0.6f;
        //numPos = Camera.main.WorldToScreenPoint(numPos);
        //uiplay.ShowDamage(gameObject, bulletBase.damage);
        mediator.ShowDamage(gameObject, bulletBase.damage);
    }

    protected override void Start()
    {
        name = "普通1";
        //uiplay = GameObject.Find("/UI/UIPlay").GetComponent<UIPlay>();
        mediator = GameObject.Find("/Chapters/ChapterNow/Mediator").GetComponent<Mediator>();

        base.Start();
        selfRigidbody = gameObject.GetComponent<Rigidbody2D>();
        anime = gameObject.GetComponent<EnemyAnime>();
        //加载子弹
        bulletPath = "Enemy/EnemyClass1/";
        atkBulletPrefab = Resources.Load<GameObject>(bulletPath+"AtkBullet");

        //设置攻击与搜敌延迟
        searchTimeDelay = searchTime;
        atkTimeDelay = atkTime;

        rotPositive = new Vector3(0, 0, 0);
        rotNegative = new Vector3(0, 180, 0);

        heroTransform = GameObject.FindGameObjectWithTag("Hero").transform;
        heroCharacter = heroTransform.GetComponent<Character>();
    }
    

    protected override void Update()
    {
        base.Update();
        

    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(!alive)
        {
            selfRigidbody.velocity = new Vector2(0, 0);
            Invoke("Die", 0.2f);
            return;
        }
        if (state!=0)
            action = false;
        //延时搜寻并跟随英雄
        #region
        if (action)
        {
            //heroTransform = GameObject.FindGameObjectWithTag("Hero").transform;
            //如已经到达英雄位置，停止移动
            if (Math.Abs(transform.position.x - heroTransform.position.x) < 0.1)
                selfRigidbody.velocity = new Vector2(0.001f, selfRigidbody.velocity.y); 
            //0.001使为使子弹生成后碰撞正常生效，移动物体，待优化
            if (Math.Abs(transform.position.y - heroTransform.position.y) < 0.1)
                selfRigidbody.velocity = new Vector2(selfRigidbody.velocity.x, 0.001f);

            searchTimeDelay -= Time.deltaTime;
            if (searchTimeDelay <= 0)    //每0.2秒调整方向
            {

                if (transform.position.x - heroTransform.position.x < -0.1)
                {
                    selfRigidbody.velocity = new Vector2(speedX, selfRigidbody.velocity.y);
                    //调整身体方向
                    gameObject.transform.eulerAngles = rotPositive;
                    xDirection = true;
                }
                else if (transform.position.x - heroTransform.position.x > 0.1)
                {
                    selfRigidbody.velocity = new Vector2(-speedX, selfRigidbody.velocity.y);
                    //调整身体方向
                    gameObject.transform.eulerAngles = rotNegative;
                    xDirection = false;
                }
                //else
                //    selfRigidbody.velocity = new Vector2(0, selfRigidbody.velocity.y);

                if (transform.position.y- heroTransform.position.y  < -0.1)
                {
                    selfRigidbody.velocity = new Vector2(selfRigidbody.velocity.x, speedY);
                }
                else if (transform.position.y  - heroTransform.position.y  > 0.1)
                {
                    selfRigidbody.velocity = new Vector2(selfRigidbody.velocity.x, -speedY);
                }
                //else
                //    selfRigidbody.velocity = new Vector2(selfRigidbody.velocity.x, 0);

                searchTimeDelay = searchTime;
            }

            atkTimeDelay -= Time.deltaTime;
            if(atkTimeDelay<=0)
            {
                if(Math.Abs(transform.position.x-heroTransform.position.x)<0.3
                    &&Math.Abs(transform.position.y-heroTransform.position.y)<0.3)
                {
                    Atk();
                    //攻击
                }
                atkTimeDelay = atkTime;
            }
        }
        #endregion

       
    }
    private void Atk()
    {
        GameObject atkBullet = Instantiate(atkBulletPrefab, gameObject.transform,false);
        atkBullet.GetComponent<BulletBase>().xDirection = GetComponent<Character>().xDirection;
        atkBullet.GetComponent<BulletBase>().belong = gameObject;
        atkBullet.GetComponent<BulletBase>().damage = gameObject.GetComponent<Character>().phyAtk;
        atkBullet.SetActive(true);
        anime.TriggerAtk();
    }

    private void Die()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
