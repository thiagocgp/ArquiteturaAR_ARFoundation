using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonZoomIn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed;
    private GameObject houseObject;
    private float speed;

    void Start()
    {
        isPressed = false;
        speed = 0.005f;
    }

    void Update()
    {
        if (isPressed)
        {
            if (houseObject != null && houseObject.transform.localScale.x < 3.0f)
            {
                float maxScale = houseObject.transform.localScale.x + 5.0f;
                houseObject.transform.localScale = Vector3.Lerp(houseObject.transform.localScale, new Vector3(maxScale, maxScale, maxScale), speed * Time.deltaTime);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        houseObject = GameObject.FindGameObjectWithTag("casa");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        houseObject = null;
    }
}
