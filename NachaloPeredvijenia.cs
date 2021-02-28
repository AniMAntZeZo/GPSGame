using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Player : MonoBehaviour
{
    public GameObject player;
    public int speed = 3;
    public Rigidbody rb;
    private bool isW = false;
    private bool isS = false;
    private bool isD = false;
    private bool isA = false;


    void Start()
    {
        player = (GameObject)this.gameObject;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isW = Input.GetKey(KeyCode.W);
        isS = Input.GetKey(KeyCode.S);
        isD = Input.GetKey(KeyCode.D);
        isA = Input.GetKey(KeyCode.A);


    }
    void FixedUpdate()
     {if (isW)
         {
              player.transform.position += player.transform.forward * speed * Time.deltaTime;
             //rb.velocity = new Vector3(0, 0, 20 * speed * Time.deltaTime); это с физикой, но работает не очень удобно, кубик 
                                                                              //вращается при ходьбе
         }

         if (isS)
         {
            player.transform.position -= player.transform.forward * speed * Time.deltaTime;
            //rb.velocity = new Vector3(0, 0, -20 * speed * Time.deltaTime);
        }

         if (isD)
         {
            player.transform.position += player.transform.right * speed * Time.deltaTime;
            //rb.velocity = new Vector3(20 * speed * Time.deltaTime, 0, 0); 
        }
         if (isA)
         {
             player.transform.position -= player.transform.right * speed * Time.deltaTime;
           //rb.velocity = new Vector3(-20 * speed * Time.deltaTime, 0, 0);
        }

             }
}
