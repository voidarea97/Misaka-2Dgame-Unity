using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    Transform heroTransform;
    Vector3 trans;

    public void FollowHero(GameObject hero)
    {
        heroTransform = hero.transform;
    }

	// Use this for initialization
	void Start () {
        //heroTransform = GameObject.FindWithTag("Hero").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (heroTransform)
        {
            if (Math.Abs(transform.position.x - heroTransform.position.x) > 4.5)
            {

                trans = Vector3.Lerp(transform.position, heroTransform.position, 0.008f);
                trans.y = transform.position.y;
                trans.z = transform.position.z;
                transform.position = trans;
            }
        }
	}
}
