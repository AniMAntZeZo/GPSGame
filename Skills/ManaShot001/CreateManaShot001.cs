using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateManaShot001 : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    public GameObject manaShot;
    public Transform Player;

    private Camera mainCamera;

    private float nextActionTime = 0.0f;
    public float period = 0.5f;


    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            Instantiate(manaShot, new Vector3(Player.position.x, Player.position.y +1.5f, Player.position.z), Player.rotation);
        }
    }
}
