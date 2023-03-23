using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool brakeState;

    public void OnPointerDown(PointerEventData eventData)
    {
        brakeState = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        brakeState = false;
    }
}
