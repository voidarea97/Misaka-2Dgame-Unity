using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnime : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IDragHandler
{
    //按钮阴影动画脚本
    public GameObject defaultShadow;
    public GameObject highlihgt;
    public GameObject click;

    private void OnDisable()
    {
        defaultShadow.SetActive(true);
        highlihgt.SetActive(false);
        click.SetActive(false);
    }
    private void Enable()
    {
        defaultShadow.SetActive(true);
        highlihgt.SetActive(false);
        click.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        defaultShadow.SetActive(false);
        highlihgt.SetActive(true);
        click.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        defaultShadow.SetActive(true);
        highlihgt.SetActive(false);
        click.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        defaultShadow.SetActive(false);
        click.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        click.SetActive(false);
        defaultShadow.SetActive(true);
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragged..");
    }

}