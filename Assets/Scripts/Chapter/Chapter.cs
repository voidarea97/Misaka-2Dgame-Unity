using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter : MonoBehaviour {

    public int num;
    //public Mediator mediator;
    //private UIPlay uiPlay;

    //private void Awake()
    //{
    //    uiPlay=GameObject.Find("/UI/UIPlay").GetComponent<UIPlay>();
    //}

    //public void ShowDamage(GameObject obj,float num)
    //{
    //    uiPlay.ShowDamage(obj, num);
    //}
    public bool hasCustomGenerator;

    private void OnEnable()
    {
        if (hasCustomGenerator)
        {
            Mediator.Instance.SetAddBtn(true);
        }
        else
            Mediator.Instance.SetAddBtn(false);
    }
}

