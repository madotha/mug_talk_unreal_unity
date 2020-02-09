using UnityEngine;
using UnityEngine.EventSystems;

// Klasse zum Check, ob ImagePointer gedrückt oder losgelassen wurde
public class Joybutton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    // Boolean zum Ablegen des "Gedrückt"-Status
    public bool Pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}
