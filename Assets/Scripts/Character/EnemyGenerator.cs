using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : CharacterGenerator {


    public override bool Generate(int charactorClass = 1, float phyatk = 1, 
        float magatk = 0, float health = 20, float speedX = 1.0f, float speedY = 0.5f)
    {

        string sClass = "EnemyClass" + charactorClass.ToString();
        characterPrefab = Resources.Load<GameObject>(characterPath + sClass + "/" + sClass);
        genPos = new Vector3(parentTransform.position.x + Random.Range(-0.1f, 0.1f),
            parentTransform.position.y + Random.Range(-0.1f, 0.1f), parentTransform.position.z);

        //Debug.Log(sClass);
        newCharactor = Instantiate(characterPrefab, genPos, parentTransform.rotation, parentTransform);
        if (!newCharactor)
            return false;
        newCharactor.GetComponent<Character>().phyAtk = phyatk;
        newCharactor.GetComponent<Character>().defaultHealth = health;
        newCharactor.GetComponent<Character>().speedX = speedX;
        newCharactor.GetComponent<Character>().speedY = speedY;
        return true;
    }

    // Use this for initialization
    protected override void Start () {
        parentTransform = GetComponent<Transform>();
        characterPath = "Enemy/";
    }
	
	// Update is called once per frame
	protected override void Update () {
		
	}
}
