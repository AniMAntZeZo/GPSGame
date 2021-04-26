using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifOpenInventory : MonoBehaviour
{
    public Rotation isOpenInvRot;
    public Zoom isOpenInvZoom;

    public void OpenInventory()
    {
        isOpenInvRot = GetComponent<Rotation>();
        isOpenInvRot.openInventory = true;
        isOpenInvZoom = GetComponent<Zoom>();
        isOpenInvZoom.openInventory = true;
    }

    

}
