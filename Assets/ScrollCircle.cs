using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollCircle : ScrollRect
{
    public float axisX;
    public float axisY;

    // 半径
    private float _mRadius = 0f;

    //private Vector2 moveBackPos;

    // 距离
    private const float Dis = 0.8f;

    protected override void Start()
    {
        base.Start();
        GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroControl>().joystick = this;
        // 能移动的半径 = 摇杆的宽 * Dis
        _mRadius = content.sizeDelta.x * Dis;

        //moveBackPos = transform.parent.transform.position;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        // 获取摇杆，根据锚点的位置。
        var contentPosition = content.anchoredPosition;

        // 判断摇杆的位置 是否大于 半径
        if (contentPosition.magnitude > _mRadius)
        {
            // 设置摇杆最远的位置
            contentPosition = contentPosition.normalized * _mRadius;
            SetContentAnchoredPosition(contentPosition);
        }

        // 最后 v2.x/y 就跟 Input中的 Horizontal Vertical 获取的值一样 
        var v2 = content.anchoredPosition.normalized;

        axisX = v2.x;
        if (axisX >= 0.8)
            axisX = 1;
        else if (axisX <= 0.2 && axisX >= -0.2)
            axisX = 0;
        else if (axisX <= -0.8)
            axisX = -1;
        axisY = v2.y;
        if (axisY >= 0.8)
            axisY = 1;
        else if (axisY <= 0.2 && axisY >= -0.2)
            axisY = 0;
        else if (axisY <= -0.8)
            axisY = -1;

        //Vector2 oppsitionVec = eventData.position;
        //oppsitionVec=oppsitionVec.normalized;
        //axisX = oppsitionVec.x;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        SetContentAnchoredPosition(new Vector2(0, 0));

        axisX = 0;
        axisY = 0;
    }
}