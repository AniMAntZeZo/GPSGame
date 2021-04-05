using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Going : MonoBehaviour
{
    public float speedMove;
    public float jumpPower;
    public float speedRotation;

    private float gravitiForse;
    public float graviti;
    private Vector3 moveVector;

    private CharacterController ch_controller;
    private MobailControlller mContr;
    private JostickRotation rotat;

    public GameObject Player;
    public GameObject Camera;

    public RotationPlayer touchFailed;

    public float horizontal;
    public float vertical;

    public bool skillActive = false;
    public float slow;

    public Slider sliderJostickSensivility;
    public Slider sliderRotationSensivility;


    public float maxVerticalRotation;
    public float minVerticalRotation;

    public GameObject model;

    private void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        mContr = GameObject.FindGameObjectWithTag("JostickMove").GetComponent<MobailControlller>();
        rotat = GameObject.FindGameObjectWithTag("JostickRotation").GetComponent<JostickRotation>();

    }

    private void Update()
    {
        CharacterMove();
        GamingGraviti();
        Rotation();
        
        if(mContr.theGoing == true)
        {
            model.GetComponent<Animator>().Play("going");
        }
        else
        {
            model.GetComponent<Animator>().Play("stop");
        }
    }       
    private void CharacterMove()
    {
        if (ch_controller.isGrounded)
        {
            moveVector = Vector3.zero;
            moveVector.x = mContr.Horizontal() * speedMove;
            moveVector.z = mContr.Vertical() * speedMove;

            moveVector = transform.TransformDirection(moveVector);

            
        }
        
        moveVector.y = gravitiForse;
        ch_controller.Move(moveVector * Time.deltaTime);

        
    }

    private void GamingGraviti()
    {
        if (!ch_controller.isGrounded) gravitiForse -= graviti * Time.deltaTime;
        else gravitiForse = -1f;
        if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded) gravitiForse = jumpPower;
    }

    private void Rotation()
    {
        if (skillActive == false)
        {
           // if (Camera.transform.rotation.x > minVerticalRotation / 100f && Camera.transform.rotation.x < maxVerticalRotation / 100f)
           // {
                Player.transform.Rotate(0f, touchFailed.tochDist.x * sliderRotationSensivility.value/50f, 0f);
                Camera.transform.Rotate(touchFailed.tochDist.y * -sliderRotationSensivility.value/50f, 0f, 0f);
           /* }
            else
            {
                if (Camera.transform.rotation.x <= minVerticalRotation / 1000f)
                {
                    if (touchFailed.tochDist.x > 0)
                    {
                        // Player.transform.Rotate(0f, rotat.HorizontalRotation() * sliderJostickSensivility.value / 10f, 0f);
                        Camera.transform.Rotate(touchFailed.tochDist.x * -sliderJostickSensivility.value / 10f, 0f, 0f);
                    }
                }
                else
                {
                    if (Camera.transform.rotation.x >= maxVerticalRotation / 1000f)
                    {
                        if (touchFailed.tochDist.x < 0)
                        {
                            print(rotat.VerticalRotation());
                            // Player.transform.Rotate(0f, rotat.HorizontalRotation() * sliderJostickSensivility.value / 10f, 0f);
                            Camera.transform.Rotate(touchFailed.tochDist.x * -sliderJostickSensivility.value / 10f, 0f, 0f);
                        }
                    }
                }
            }*/
        }
        else
        {
           // if (Camera.transform.rotation.x > minVerticalRotation / 100f && Camera.transform.rotation.x < maxVerticalRotation / 100f)
           // {
                Player.transform.Rotate(0f, rotat.HorizontalRotation() * sliderJostickSensivility.value / 50f, 0f);
                Camera.transform.Rotate(rotat.VerticalRotation() * -sliderJostickSensivility.value / 50f, 0f, 0f);
           /* }
            else
            {
                if (Camera.transform.rotation.x <= minVerticalRotation / 1000f)
                {
                    if (rotat.VerticalRotation() > 0)
                    {
                        // Player.transform.Rotate(0f, rotat.HorizontalRotation() * sliderJostickSensivility.value / 10f, 0f);
                        Camera.transform.Rotate(rotat.VerticalRotation() * -sliderJostickSensivility.value / 10f, 0f, 0f);
                    }
                }
                else
                {
                    if (Camera.transform.rotation.x >= maxVerticalRotation / 1000f)
                    {
                        if (rotat.VerticalRotation() < 0)
                        {
                            print(rotat.VerticalRotation());
                            // Player.transform.Rotate(0f, rotat.HorizontalRotation() * sliderJostickSensivility.value / 10f, 0f);
                            Camera.transform.Rotate(rotat.VerticalRotation() * -sliderJostickSensivility.value / 10f, 0f, 0f);
                        }
                    }
                }
            }*/
        }
    }

}
