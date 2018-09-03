using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour {

    protected Rigidbody2D herorigidbody;
    protected HeroAnime heroAnime;
    protected HeroSkill heroSkill;
    //public UIJoystick joystick;
    public ScrollCircle joystick;

    //protected Transform skill1;   //技能1对应游戏gameobject的transform
    //protected Transform skill2;
    //protected Transform skill3;

    protected float xAxis, yAxis;
    protected bool btn1, btn2, btn3;

    private Vector3 rotPositive;    //x轴正向
    private Vector3 rotNegative;    //x反向

    virtual protected void Start () {
        herorigidbody = gameObject.GetComponent<Rigidbody2D>();
        heroAnime = gameObject.GetComponent<HeroAnime>();
        heroSkill = gameObject.GetComponent<HeroSkill>();

        rotPositive = new Vector3(0, 0, 0);
        rotNegative = new Vector3(0, 180, 0);
        gameObject.GetComponent<Character>().xDirection = true;

        joystick = GameObject.Find("UIPlay/Control/JoystickBack").GetComponent<ScrollCircle>();

        //初始化相机位置
        Vector3 cameraPos = Camera.main.transform.position;
        cameraPos.x =gameObject.transform.position.x + 3.5f;
        Camera.main.transform.position = cameraPos;
    }

    virtual protected void Update () {

	}

    virtual protected void FixedUpdate()
    {
        //float xAxis = Input.GetAxisRaw("Horizontal");
        //float yAxis = Input.GetAxisRaw("Vertical");

        //获得摇杆按键信息
        xAxis = joystick.axisX;
        yAxis = joystick.axisY;

        btn1 = joystick.btn1;
        btn2 = joystick.btn2;
        btn3 = joystick.btn3;

        #region 
        //调整控制精度

        if (xAxis >= 0.8)
            xAxis = 1;
        else if (xAxis <= 0.2 && xAxis >= -0.2)
            xAxis = 0;
        else if (xAxis <= -0.8)
            xAxis = -1;
        
        if (yAxis >= 0.8)
            yAxis = 1;
        else if (yAxis <= 0.2 && yAxis >= -0.2)
            yAxis = 0;
        else if (yAxis <= -0.8)
            yAxis = -1;
        #endregion

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
