using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventory : MonoBehaviour
{
    public Rotation isOpenInvRot;
    public Zoom isOpenInvZoom;

    public void IfCloseInventory()
    {
        isOpenInvRot = GetComponent<Rotation>();
        isOpenInvRot.openInventory = false;
        isOpenInvZoom = GetComponent<Zoom>();
        isOpenInvZoom.openInventory = false;
    }

}
