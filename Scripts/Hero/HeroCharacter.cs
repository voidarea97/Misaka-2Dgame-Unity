using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacter : Character {

    private HeroAnime heroAnime;

    public override void BeHit(BulletBase bulletBase)
    {
        health -= bulletBase.damage;    //损失生命值等于子弹伤害
        heroAnime.TriggerBehit();
    }

    protected override void Start () {
        base.Start();
        heroAnime = gameObject.GetComponent<HeroAnime>();
        Camera.main.gameObject.GetComponent<Follow>().FollowHero(gameObject);
    }

    protected override void Update () {
        base.Update();
        
	}

    public void Death()
    {
        UIManager.Instance.PushUIPanel("PanelEnd");
    }
}
