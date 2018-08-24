using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemy : MonoBehaviour {

    public GameObject[] Enemys;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent <Character>())
        {
            if (collision.gameObject.GetComponent<Character>().kind == 0)
                foreach (var item in Enemys)
                {
                    item.SetActive(true);
                }
            gameObject.SetActive(false);
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
