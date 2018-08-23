using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillProperty : MonoBehaviour {

    public string skillName;

    public float flash; //冷却时间
    public float flashing;  //当前剩余冷却时间
    public float level; //等级
    public float stay;  //后摇
    public float staying;
    public float animeTime; //动画持续时间
    public int damageType;  //0:real    1:phy   2:mag


    public float phyCoefficient;    //物理加成系数
    public float magCoefficient;    //魔法加成
    public float baseCoefficient;   //基础伤害

    public float damage;

    

    void Start()
    {
        damage = baseCoefficient + phyCoefficient * transform.parent.GetComponent<Character>().phyAtk 
            + magCoefficient * transform.parent.GetComponent<Character>().magAtk;
    }

    void FixedUpdate()
    {
        if (flashing > 0)   //冷却中
            flashing -= Time.deltaTime;
        if (staying > 0)    //后摇中
        {
            staying -= Time.deltaTime;
            if (staying <= 0)
                transform.parent.GetComponent<Character>().action = true;
        }
    }
}
