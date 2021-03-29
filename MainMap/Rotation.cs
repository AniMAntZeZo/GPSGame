using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Rotation : MonoBehaviour
{
    public float Sansitivity;

    public GameObject CamHelp;
    public Camera Cam;
    public Transform Player;

    private Vector2 startPos;

    public bool openInventory = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (openInventory == false)
        {

            if (Input.touchCount == 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    startPos = Input.mousePosition;
                }
                else if (Input.GetMouseButton(0))
                {
                    float pos = Input.mousePosition.x - startPos.x;
                    CamHelp.transform.Rotate(0f, pos, 0f);
                    startPos = Input.mousePosition;
                }
            }

            Cam.transform.LookAt(Player);
        }
    }
}
