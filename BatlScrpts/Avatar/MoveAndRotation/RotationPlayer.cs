using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationPlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 tochDist;
    Vector2 pointerOld;
    int pointerID;
    public bool pressent;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressent = true;
        pointerID = eventData.pointerId;
        pointerOld = eventData.position;
    }

    private void Update()
    {
        if (pressent)
        {
            if (pointerID >= 0 && pointerID < Input.touches.Length)
            {
                tochDist = Input.touches[pointerID].position - pointerOld;
                pointerOld = Input.touches[pointerID].position;
            }
            else
            {
                tochDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - pointerOld;
                pointerOld = Input.mousePosition;
            }
        }
        else
        {
            tochDist = new Vector2();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressent = false;
    }
}
