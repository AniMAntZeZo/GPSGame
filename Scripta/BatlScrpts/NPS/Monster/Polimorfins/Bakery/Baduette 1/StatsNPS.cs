using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsNPS : MonoBehaviour
{

    public float HP = 0f;
    public float HPDecrease = 0f;

    void Start()
    {
        HP = 100f;
    }

    void Update()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
        }

        HP -= HPDecrease;
        HPDecrease = 0f;
    }
}
