using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Going : MonoBehaviour
{
    public float speedMove;
    public float jumpPower;
    public float speedRotation;

    private float gravitiForse;
    private Vector3 moveVector;

    private CharacterController ch_controller;
    private MobailControlller mContr;
    private JostickRotation rotat;

    public GameObject Player;
    public GameObject Camera;

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
    }
    private void CharacterMove()
    {
        if (ch_controller.isGrounded)
        {
            moveVector = Vector3.zero;
            moveVector.x = mContr.Horizontal() * speedMove;
            moveVector.z = mContr.Vertical() * speedMove;
        }

        moveVector.y = gravitiForse;
        ch_controller.Move(moveVector * Time.deltaTime);
    }

    private void GamingGraviti()
    {
        if (!ch_controller.isGrounded) gravitiForse -= 20f * Time.deltaTime;
        else gravitiForse = -1f;
        if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded) gravitiForse = jumpPower;
    }

    private void Rotation()
    {
        Player.transform.Rotate(0, rotat.HorizontalRotation() * speedRotation, 0);
        Camera.transform.Rotate(rotat.VerticalRotation() * -speedRotation, 0, 0);
    }

}
