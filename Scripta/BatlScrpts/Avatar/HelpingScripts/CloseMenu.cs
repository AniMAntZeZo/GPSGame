using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseMenu : MonoBehaviour, IPointerClickHandler
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject inventory;
    public GameObject skills;
    public GameObject objectItem;
    public GameObject objectEqup;
    public GameObject objectUnequp;

    public void OnPointerClick(PointerEventData eventData)
    {
        mainMenu.SetActive(false);
        settings.SetActive(false);
        inventory.SetActive(false);
        skills.SetActive(false);
        objectItem.SetActive(false);
        objectEqup.SetActive(false);
        objectUnequp.SetActive(false);
    }

}
