using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSkill : MonoBehaviour {

    protected HeroAnime heroAnime;
    protected Rigidbody2D herorigidbody;
    public GameObject gloableBullet;
    //public SkillProperty skillProperty1;
    //public SkillProperty skillProperty2;
    //public SkillProperty skillProperty3;

    protected Dictionary<string, GameObject> skillDict
        = new Dictionary<string, GameObject>();  //技能子弹名称与其预制体对应字典

    public string ResourcesDir = "Hero/Hero1Skill";  //资源路径


    public void Skill(SkillProperty skillProperty)
    {

        if (skillProperty.flashing <= 0) //未在冷却           
        {
            skillProperty.flashing = skillProperty.flash; //重置冷却
            {
                //技能动画
                heroAnime.StartSkill(skillProperty.skillName);
                //产生技能子弹               
                GameObject skillBullet = Instantiate(skillDict[skillProperty.skillName + "Bullet"],
                    gameObject.transform.position, transform.rotation);
                if(skillBullet.GetComponent<BulletBase>().kind == 1)
                    skillBullet.transform.SetParent(gloableBullet.transform, true);
                else
                    skillBullet.transform.SetParent(gameObject.transform, true);
                //确定方向
                //float x = -1;
                //if (gameObject.GetComponent<Character>().xDirection)
                //    x = 1;
                //skill1Bullet.GetComponent<BulletBase>().direction = new Vector2(x, 0);
                skillBullet.GetComponent<BulletBase>().xDirection = GetComponent<Character>().xDirection;
                skillBullet.GetComponent<BulletBase>().belong = gameObject;
                //确定子弹技能伤害
                skillBullet.GetComponent<BulletBase>().damage = skillProperty.damage;
            }

            //后摇僵直
            GetComponent<Character>().action = false;
            herorigidbody.velocity = new Vector2(0, 0);
            //重置后摇时间
            skillProperty.staying = skillProperty.stay;

            //延时结束技能动画
            StartCoroutine(SkillAnimeEnd(skillProperty.skillName,skillProperty.animeTime));
        }

    }


    virtual protected void Start()
    {
        heroAnime = gameObject.GetComponent<HeroAnime>();
        herorigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    virtual protected void Update()
    {

    }

    protected void LoadResouce(string name)    //加载资源
    {
        string Path = ResourcesDir + "/" + name;
        GameObject Object = Resources.Load<GameObject>(Path);
        if (Object)
            skillDict.Add(name, Object);
    }

    protected IEnumerator SkillAnimeEnd(string name, float time) //延时结束技能动画
    {
        for(float i=time;i>=0;i-=Time.deltaTime)
        yield return 0;
        heroAnime.EndSkill(name);

    }
}
