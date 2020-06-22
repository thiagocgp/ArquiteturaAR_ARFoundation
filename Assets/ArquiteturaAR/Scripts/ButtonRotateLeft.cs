using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRotateLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed;
    private GameObject houseObject;
    private float speed;

    void Start()
    {
        isPressed = false;
        speed = 30.0f;
    }

    void Update()
    {
        if (isPressed)
        {
            if (houseObject != null)
            {
                houseObject.transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.Self);
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