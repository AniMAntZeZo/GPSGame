using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShots : MonoBehaviour
{
    public bool isShotsTrue;

    public Transform bulletPref;
    public Transform PivotPos;
    public Transform PivotRot;

    private float timer = 0f;
    public float pause = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (isShotsTrue == true)
        {
            if (timer > pause)
            {
                Instantiate(bulletPref, PivotPos.position, PivotRot.rotation);
                timer = 0f;
            }
        }
    }
}
