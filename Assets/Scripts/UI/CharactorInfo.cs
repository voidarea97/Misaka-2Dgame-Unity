using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorInfo : MonoBehaviour {

    public GameObject healthText;
    public GameObject healthBar;
    public HeroCharacter heroCharacter;
    public float healthbarLong = 485f;

    private Vector3 barPos, barPosScreen, initPos, initScreen;
    
    private string health;
	// Use this for initialization
	void Awake () {
        
        barPos = healthBar.GetComponent<Transform>().position;
        barPosScreen = Camera.main.WorldToScreenPoint(barPos);
        initPos = barPos;
        initScreen = barPosScreen;
        //healthBar.transform.position = barPos;
    }
    private void Start()
    {
        heroCharacter = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroCharacter>();
    }
    void OnEnable()
    {
        Invoke("FindHero", 0.1f);
        //heroCharacter = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroCharacter>();
        barPos = initPos;
        barPosScreen = initScreen;
    }
    // Update is called once per frame
    void FixedUpdate () {
        health = "HP  "+ heroCharacter.health.ToString() + "/" + heroCharacter.defaultHealth.ToString();
        healthText.GetComponent<Text>().text = health;



        barPosScreen.x = initScreen.x
            - (1 - heroCharacter.health / heroCharacter.defaultHealth) * healthbarLong;
        barPos = Camera.main.ScreenToWorldPoint(barPosScreen);
        healthBar.transform.position = barPos;
	}
    void FindHero()
    {
        heroCharacter = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroCharacter>();
    }
}
