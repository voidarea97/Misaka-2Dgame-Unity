using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterGenerator : MonoBehaviour {


    protected GameObject characterPrefab;
    protected Transform parentTransform;
    protected Vector3 genPos;
    protected GameObject newCharactor;

    public string characterPath;

    public abstract bool Generate(int charactorClass, float phyatk, float magatk , float health , float speedX , float speedY);

	// Use this for initialization
	protected virtual void Start () {
        
	}

    // Update is called once per frame
    protected virtual void Update () {
		
	}
}
