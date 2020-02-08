using UnityEngine;
using UnityEngine.EventSystems;

// Klassen zum Check, ob ImagePointer gedrückt oder losgelassen wurden
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
