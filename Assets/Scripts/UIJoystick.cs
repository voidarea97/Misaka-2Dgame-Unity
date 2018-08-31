using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIJoystick : MonoBehaviour {

    public Vector3 initPosition;
    public Vector3 initScreenPosition;

    public float axisX;
    public float axisY;

    public float rWorld;    //虚拟方向按钮可移动的半径
    public float rScreen;

    public Transform border;

    void Start()
    {
        //获取border对象的transform组件
        //border = GameObject.Find("border").transform;

        //GameObject.FindWithTag("Hero").GetComponent<HeroControl>().joystick = this;
        initPosition = GetComponentInParent<RectTransform>().position;
        initScreenPosition = Camera.main.WorldToScreenPoint(GetComponentInParent<RectTransform>().position);

        rWorld = Vector2.Distance(transform.position, border.position);
        rScreen = Vector2.Distance(Camera.main.WorldToScreenPoint(transform.position), Camera.main.WorldToScreenPoint(border.position));

    }

    //鼠标拖拽
    public void OnDragIng()
    {
        //如果鼠标到虚拟键盘原点的位置 < 半径r
        if (Vector2.Distance(Input.mousePosition, initScreenPosition) < rScreen)
        {
            //计算摇杆位置应改变量
            Vector3 dir=new Vector3(Input.mousePosition.x- initScreenPosition.x,
                Input.mousePosition.y - initScreenPosition.y, 0);
            dir = dir * rWorld / rScreen;

            transform.position = Camera.main.ScreenToWorldPoint(initScreenPosition) + dir;
            
        }
        else
        {
            //计算出鼠标和原点之间的方向

            Vector3 dir = new Vector3(Input.mousePosition.x - initScreenPosition.x,
                            Input.mousePosition.y - initScreenPosition.y, 0);

            transform.position = Camera.main.ScreenToWorldPoint(initScreenPosition) + dir.normalized * rWorld;
        }
        axisX = (Input.mousePosition.x - initScreenPosition.x)/rScreen;
        if (axisX >= 0.8)
            axisX = 1;
        else if (axisX <= 0.2 && axisX >= -0.2)
            axisX = 0;
        else if (axisX <= -0.8)
            axisX = -1;
        axisY = (Input.mousePosition.y - initScreenPosition.y)/rScreen;
        if (axisY >= 0.8)
            axisY = 1;
        else if (axisY <= 0.2 && axisY >= -0.2)
            axisY = 0;
        else if (axisY <= -0.8)
            axisY = -1;
    }
    //鼠标松开
    public void OnDragEnd()
    {
        //松开鼠标虚拟摇杆回到原点
        transform.position = initScreenPosition;
        axisX = 0;
        axisY = 0;
    }

    // Use this for initialization
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        
    }
}
