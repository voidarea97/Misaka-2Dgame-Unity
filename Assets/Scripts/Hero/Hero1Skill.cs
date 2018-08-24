using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1Skill : HeroSkill {

    public SkillProperty skillProperty1;
    public SkillProperty skillProperty2;
    public SkillProperty skillProperty3;

    protected override void Start()
    {
        base.Start();
        //加载技能子弹
        LoadResouce("Skill1Bullet");
        LoadResouce("Skill2Bullet");
        LoadResouce("Skill3Bullet");
    }

    protected override void Update()
    {
        base.Update();
    }

}
