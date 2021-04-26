using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingFastPanel : MonoBehaviour
{
    public Button slot0;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    public void ModeOne()
    {
        slot0.transform.position = new Vector3(0,0,0);
        slot1.transform.position = new Vector3(500, 250, 0);
        slot0.transform.position = new Vector3(650, 250, 0);
        slot0.transform.position = new Vector3(800, 250, 0);
    }


    public void ModeTwo()
    {

    }


    public void ModeThree()
    {

    }

}
