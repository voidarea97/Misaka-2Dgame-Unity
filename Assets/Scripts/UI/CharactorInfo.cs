using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorInfo : MonoBehaviour {

    public GameObject healthText;
    public GameObject healthBar;
    public HeroCharacter heroCharacter;
    public GameObject barReference;

    //public float healthbarLong = 485f;

    private float dis;
    private Vector3 barPos, barPosScreen, initPos, initScreen;
    
    private string health;
	
	void Awake () {

        //barPosScreen = Camera.main.WorldToScreenPoint(barPos);
        //initPos = barPos;
        //initScreen = barPosScreen;
        //healthBar.transform.position = barPos;
    }
    private void Start()
    {
        dis = healthBar.GetComponent<Transform>().position.x - barReference.GetComponent<Transform>().position.x;
        
        barPos = healthBar.GetComponent<Transform>().position;

        heroCharacter = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroCharacter>();
    }
    void OnEnable()
    {
        Invoke("FindHero", 0.1f);
        //heroCharacter = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroCharacter>();
        //barPos = initPos;
        //barPosScreen = initScreen;
    }
    
    void FixedUpdate () {
        health = "HP  "+ heroCharacter.health.ToString() + "/" + heroCharacter.defaultHealth.ToString();
        healthText.GetComponent<Text>().text = health;


        barPos.x = barReference.GetComponent<Transform>().position.x + dis -
            (2*dis * (1 - heroCharacter.health / heroCharacter.defaultHealth));
        //barPosScreen.x = initScreen.x
        //    - (1 - heroCharacter.health / heroCharacter.defaultHealth) * healthbarLong;
        //barPos = Camera.main.ScreenToWorldPoint(barPosScreen);
        healthBar.transform.position = barPos;
	}
    void FindHero()
    {
        heroCharacter = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroCharacter>();
    }
}
