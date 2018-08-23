using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour {

    protected Rigidbody2D herorigidbody;
    protected HeroAnime heroAnime;
    protected HeroSkill heroSkill;

    //protected Transform skill1;   //技能1对应游戏gameobject的transform
    //protected Transform skill2;
    //protected Transform skill3;


    //public SkillProperty skillProperty1;


    private Vector3 rotPositive;    //x轴正向
    private Vector3 rotNegative;    //x反向

    virtual protected void Start () {
        herorigidbody = gameObject.GetComponent<Rigidbody2D>();
        heroAnime = gameObject.GetComponent<HeroAnime>();
        heroSkill = gameObject.GetComponent<HeroSkill>();

        rotPositive = new Vector3(0, 0, 0);
        rotNegative = new Vector3(0, 180, 0);
        gameObject.GetComponent<Character>().xDirection = true;
    }

    virtual protected void Update () {

	}

    virtual protected void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        if (gameObject.GetComponent<Character>().action)    //可行动
        {
            if (xAxis >= 0)
            {
                herorigidbody.velocity = new Vector2
                    (gameObject.GetComponent<Character>().speedX * xAxis, herorigidbody.velocity.y);

                if (xAxis > 0)  //向右走
                {
                    //调整身体方向
                    gameObject.transform.eulerAngles = rotPositive;
                    gameObject.GetComponent<Character>().xDirection = true;
                    //行走动画
                    heroAnime.StartRun();
                }

            }
            else    //向左走
            {
                herorigidbody.velocity = new Vector2
                    (gameObject.GetComponent<Character>().speedX * xAxis, herorigidbody.velocity.y);
                gameObject.transform.eulerAngles = rotNegative;
                gameObject.GetComponent<Character>().xDirection = false;
                heroAnime.StartRun();
            }
            //y轴移动
            if (yAxis >= 0)
            {

                herorigidbody.velocity = new Vector2
                    (herorigidbody.velocity.x, gameObject.GetComponent<Character>().speedY * yAxis);
                if (yAxis == 0)
                {
                    if(xAxis==0)
                    heroAnime.EndRun();
                }
                else
                    heroAnime.StartRun();
            }
            else
            {
                herorigidbody.velocity = new Vector2
                    (herorigidbody.velocity.x, gameObject.GetComponent<Character>().speedY * yAxis);
                heroAnime.StartRun();
            }
            //skill1
            //if (Input.GetKeyDown(KeyCode.A))    
            //{
            //    //施放
            //    CastSkill(skillProperty1);
            //    ////后摇结束后切换动画
            //    //Invoke("EndSkill1", skillProperty1.stay);
            //}
        }
    }
    //virtual protected void CastSkill(Transform skillTrans)    //施放指定技能
    //{

    //    if (skillTrans.GetComponent<SkillProperty>().flashing <= 0) //未在冷却           
    //    {
    //        skillTrans.GetComponent<SkillProperty>().flashing = skillTrans.GetComponent<SkillProperty>().flash; //重置冷却
    //        gameObject.GetComponent<Hero1Skill>().Skill
    //            (skillTrans.gameObject.GetComponent<SkillProperty>().skillName);  //施放skill
            
    //        //后摇僵直
    //        GetComponent<Character>().action = false;
    //        herorigidbody.velocity = new Vector2(0, 0);
    //        //重置后摇时间
    //        skillTrans.GetComponent<SkillProperty>().staying = skillTrans.GetComponent<SkillProperty>().stay;

    //    }
    //}
    virtual protected void CastSkill(SkillProperty skillProperty)    //施放指定技能
    {
            heroSkill.Skill
                (skillProperty);  //施放skill
    }

    ////为使用Invoke，待优化
    //void EndSkill1()
    //{
    //    heroAnime.EndSkill("Skill1");
        
    //}
}
