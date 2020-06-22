using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonDownPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed;
    private GameObject houseObject;
    private float speed;

    void Start()
    {
        isPressed = false;
        speed = 0.5f;
    }

    void Update()
    {
        if (isPressed)
        {
            if (houseObject != null)
            {
                houseObject.transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
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