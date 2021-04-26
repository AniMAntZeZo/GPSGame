using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Scrollbar HPScrolBar;
    public Scrollbar MPScrolBar;
    public Scrollbar SPScrolBar;

    public float HP = 100f;
    public float MP = 100f;
    public float SP = 100f;

    public float HPMax = 100f;
    public float MPMax = 100f;
    public float SPMax = 100f;

    public float HPDecrease = 0f;
    public float MPDecrease = 0f;
    public float SPDecrease = 0f;

    public float HPRegenProcDefoult = 0f;
    public float MPRegenProcDefoult = 0f;
    public float SPRegenProcDefoult = 0f;

    public float HPRegenBuffItems = 0.1f;
    public float MPRegenBuffItems = 0.5f;
    public float SPRegenBuffItems = 2f;

    public float HPRegenAllCoif = 0f;
    public float MPRegenAllCoif = 0f;
    public float SPRegenAllCoif = 0f;

    void Start()
    {
        HP = HPMax;
        MP = MPMax;
        SP = SPMax;

        HPRegenProcDefoult = 0.1f;
        MPRegenProcDefoult = 0.5f;
        SPRegenProcDefoult = 2f;
    }

    void Update()
    {
        HPScrolBar.size = ((100f / HPMax) * HP)/100f;
        MPScrolBar.size = ((100f / MPMax) * MP)/100f;
        SPScrolBar.size = ((100f / SPMax) * SP)/100f;

        if (HP <= 0)
        {

        }

        if(MP <= 0)
        {

        }

        if(SP <= 0)
        {

        }

        HPRegenAllCoif = HPRegenProcDefoult + HPRegenBuffItems;
        MPRegenAllCoif = MPRegenProcDefoult + MPRegenBuffItems;
        SPRegenAllCoif = SPRegenProcDefoult + SPRegenBuffItems;

        HP -= HPDecrease;
        HPDecrease = 0f;

        HP += HPRegenAllCoif * Time.deltaTime;
        MP += MPRegenAllCoif * Time.deltaTime;
        SP += SPRegenAllCoif * Time.deltaTime;


    }
}
