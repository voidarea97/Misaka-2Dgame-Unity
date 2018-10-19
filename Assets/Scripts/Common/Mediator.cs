using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mediator : MonoBehaviour{

    
    private UIPlay uiPlay;
    private Statistic statistic;

    private void Start()
    {
        uiPlay = GameObject.Find("/UI/UIPlay").GetComponent<UIPlay>();
    }

    public void ShowDamage(GameObject obj, float num)
    {
        uiPlay.ShowDamage(obj, num);
    }
}
