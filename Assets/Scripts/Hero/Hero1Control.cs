using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1Control : HeroControl {

    public SkillProperty skillProperty1;
    public SkillProperty skillProperty2;
    public SkillProperty skillProperty3;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (btn1||Input.GetKeyDown(KeyCode.A))
        {
            //施放
            CastSkill(skillProperty1);
            joystick.btn1 = false;
        }
    }

}
