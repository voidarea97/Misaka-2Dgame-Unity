using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistic : MonoBehaviour {

    public float behits;
    public float time;
    public float combo;

    // Use this for initialization
    void Start () {
        time = 0;
        behits = 0;
        combo = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        time += Time.deltaTime;
	}
}
