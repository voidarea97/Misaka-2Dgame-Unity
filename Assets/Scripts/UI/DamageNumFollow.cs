using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumFollow : MonoBehaviour {

    public GameObject character;

    private Vector2 pos;

    public void Getcharacter(GameObject ch)
    {
        character = ch;
    }
    // Use this for initialization

    private void OnDisable()
    {
        Destroy(gameObject);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(character)
        {
            //伤害数字跟随受伤害对象
            pos = character.transform.position;
            pos.y += character.GetComponent<SpriteRenderer>().bounds.size.y/2;
            //pos.y += 0.6f;
            gameObject.transform.position = pos;
        }
	}
}
