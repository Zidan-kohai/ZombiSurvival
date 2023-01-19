using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class MobileController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Image JoystickBG;
    private Image Joystick;
    private Vector2 inputVector;

    private void Start()
    {
        JoystickBG = GetComponent<Image>();
        Joystick = transform.GetChild(0).GetComponent<Image>();
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        Joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickBG.rectTransform,ped.position, ped.pressEventCamera,out pos))
        {
            pos.x = (pos.x / JoystickBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / JoystickBG.rectTransform.sizeDelta.x);
            inputVector = new Vector2(pos.x, pos.y);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            Joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (JoystickBG.rectTransform.sizeDelta.x / 2), inputVector.y * (JoystickBG.rectTransform.sizeDelta.y / 2));
        }
    }

    public float Horizontal() => inputVector.x;
    public float Vertical() => inputVector.y;
    
}
