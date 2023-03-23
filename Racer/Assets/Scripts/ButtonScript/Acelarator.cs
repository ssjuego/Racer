using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Acelarator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int velocity;

    public void OnPointerDown(PointerEventData eventData)
    {
        velocity = 1;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        velocity = 0;
    }
}
