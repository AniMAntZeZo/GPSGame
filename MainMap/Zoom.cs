using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Zoom : MonoBehaviour
{

    public float ZoomMin;
    public float ZoomMax;
    public float Sansitivity;

    public Transform Player;
    public Camera Cam;
    public GameObject Camhelp;

    private Touch _touchA;
    private Touch _touchB;
    private Vector2 _touchADerection;
    private Vector2 _touchBDerection;
    private float _distBtwTouchPositions;
    private float _distBtwTouchDerections;
    private float _zoom;

    private float smeshX;

    public bool openInventory = false;

    private void Awake()
    {

    }

    void Start()
    {

    }


    void Update()
    {
        if (openInventory == false)
        {
            if (Input.touchCount == 2)
            {

                _touchA = Input.GetTouch(0);
                _touchB = Input.GetTouch(1);
                _touchADerection = _touchA.position - _touchA.deltaPosition;
                _touchBDerection = _touchB.position - _touchB.deltaPosition;

                _distBtwTouchPositions = Vector2.Distance(_touchA.position, _touchB.position);
                _distBtwTouchDerections = Vector2.Distance(_touchADerection, _touchBDerection);



                if ((_distBtwTouchPositions < _distBtwTouchDerections) && (Cam.transform.position.y < ZoomMax))
                {
                    Cam.transform.position += new Vector3(0.000f, Sansitivity * 0.1f, -Sansitivity * 0.05f);
                }
                if ((_distBtwTouchPositions > _distBtwTouchDerections) && (Cam.transform.position.y > ZoomMin))
                {
                    Cam.transform.position += new Vector3(0.000f, -Sansitivity * 0.1f, Sansitivity * 0.05f);
                }

                /*if (Cam.transform.position.x != 0)
                {
                    smeshX = 0 - Cam.transform.position.x;
                    Cam.transform.position = new Vector3(0.000f, Cam.transform.position.y, Cam.transform.position.z);
                }

                if((_distBtwTouchPositions < _distBtwTouchDerections) && (Camhelp.transform.position.y < ZoomMax))
                {
                    Camhelp.transform.Rotate(Sansitivity, 0, 0);
                    Camhelp.transform.position += new Vector3(0f, Sansitivity * 0.1f, 0f);
                }
                if ((_distBtwTouchPositions > _distBtwTouchDerections) && (Camhelp.transform.position.y > ZoomMin))
                {
                    Camhelp.transform.Rotate(-Sansitivity, 0, 0);
                    Camhelp.transform.position += new Vector3(0f, -Sansitivity * 0.1f, 0f);
                }*/

            }
        }

    }
}
