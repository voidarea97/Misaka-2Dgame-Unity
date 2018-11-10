using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMove : MonoBehaviour {
    //循环显示背景图片

    float width;    //图片sprite宽度
    float mid;  //屏幕中点的x World坐标
    public int mul;    //移动距离倍数
	// Use this for initialization
	void Start () {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        //mid = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0)).x;
        //Debug.Log(width.ToString());
    }
	
	// Update is called once per frame
	void Update () {
        float x = (gameObject.GetComponent<Transform>().position).x;
        mid = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0)).x;
        if (x - mid < -mul * width / 2)
        {
            GetComponent<Transform>().position = new Vector3(
            GetComponent<Transform>().position.x + mul * width,
            GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
        }
        else if(x - mid > mul * width / 2)
        {
            GetComponent<Transform>().position = new Vector3(
            GetComponent<Transform>().position.x - mul * width,
            GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
        }
	}

    //private void OnBecameInvisible()
    //{
    //    GetComponent<Transform>().position = new Vector3(
    //        GetComponent<Transform>().position.x + 3.0f * width,
    //        GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
    //}
}
