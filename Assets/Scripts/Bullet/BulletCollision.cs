using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletCollision : MonoBehaviour {

    public UnityEvent onCollision;
    private BulletBase bulletBase;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //获取碰撞两方物体或角色数据
        GameObject objSelf = bulletBase.belong;
        GameObject objOther = collision.gameObject;
        Character characterSelf = objSelf.GetComponent<Character>();
        Character characterOther = objOther.GetComponent<Character>();

        if(objOther.tag=="Transparent")
        {
            return;
        }
        if(objOther.tag=="Hard")    //碰撞墙等硬实体阻挡物
        {
            bulletBase.survivalCollision = 0;   //直接销毁子弹
            return;
        }
        if (characterOther)
        {
            //如果子弹碰撞不同阵营角色
            if ((characterSelf.kind == 0 && (characterOther.kind > 100 && characterOther.kind < 200))
                || ((characterSelf.kind > 100 && characterSelf.kind < 200) && characterOther.kind == 0))
            {
                if (!characterOther.immune) //不处于免疫状态
                {
                    characterOther.BeHit(bulletBase);   //被击中角色的处理方法
                    bulletBase.survivalCollision--;     //子弹剩余碰撞次数-1
                }
            }

            onCollision.Invoke();   //附加碰撞事件
        }
        else
        {

        }
    }

    void Awake () {
        bulletBase = gameObject.GetComponent<BulletBase>();
    }
	
	void Update () {
		
	}
}
