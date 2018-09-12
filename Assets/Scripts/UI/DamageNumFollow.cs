using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumFollow : MonoBehaviour {

    public GameObject charactor;

    private Vector2 pos;

    public void GetCharactor(GameObject ch)
    {
        charactor = ch;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(charactor)
        {
            //伤害数字跟随受伤害对象
            pos = charactor.transform.position;
            pos.y += charactor.GetComponent<SpriteRenderer>().bounds.size.y/2;
            //pos.y += 0.6f;
            gameObject.transform.position = pos;
        }
	}
}
