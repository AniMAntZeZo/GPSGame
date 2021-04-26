using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim1 : MonoBehaviour
{

    void Update()
    {
        while (true)
        {
            this.gameObject.GetComponent<Animator>().Play("jump");
        }
    }
}
