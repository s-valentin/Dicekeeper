using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Text txt;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("i'm hovering");
        Color txtColor = txt.color;
        txtColor.a = 1;
        txt.color = txtColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("i'm not hovering");
        Color txtColor = txt.color;
        txtColor.a = 0.3f;
        txt.color = txtColor;
    }

    private void Update()
    {
        
    }

}
