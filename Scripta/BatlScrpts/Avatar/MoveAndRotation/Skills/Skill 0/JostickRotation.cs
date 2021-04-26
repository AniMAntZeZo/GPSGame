using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JostickRotation : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image jostickBG;
    [SerializeField]
    private Image jostick;
    private Vector2 inputVector;

    private Going skill0;
    private TestShots shotsActiv;
    private bool useSkill0;

    public GameObject manaShot;
    public Transform Player;

    private Camera mainCamera;

    private float nextActionTime = 0.0f;
    public float period = 0.5f;

    private void Start()
    {
        jostickBG = GetComponent<Image>();
        jostick = transform.GetChild(1).GetComponent<Image>();
        skill0 = GameObject.FindGameObjectWithTag("Player").GetComponent<Going>();
        shotsActiv = GameObject.FindGameObjectWithTag("Player").GetComponent<TestShots>();

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
        skill0.skillActive = true;
        useSkill0 = true;
        shotsActiv.isShotsTrue = true;


      //  CreateManaShot();
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        jostick.rectTransform.anchoredPosition = Vector2.zero;
        skill0.skillActive = false;
        useSkill0 = false;
        shotsActiv.isShotsTrue = false;


    }

    public virtual void OnDrag(PointerEventData ped)
    {
       // Debug.Log("On Drag");
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(jostickBG.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / jostickBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / jostickBG.rectTransform.sizeDelta.x);

            inputVector = new Vector2(pos.x, pos.y);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            jostick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (jostickBG.rectTransform.sizeDelta.x / 2), inputVector.y * (jostickBG.rectTransform.sizeDelta.y / 2));
        }
    }

    public float HorizontalRotation()
    {
        if (inputVector.x != 0) return inputVector.x;
        else return 0;
    }

    public float VerticalRotation()
    {
        if (inputVector.y != 0) return inputVector.y;
        else return 0;
    }

    public void CreateManaShot()
    {
        while (useSkill0 == true)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                Instantiate(manaShot, new Vector3(Player.position.x, Player.position.y+1.5f, Player.position.z), Player.rotation);
            }

            //yield return new WaitForSeconds(2);
        }
    }

    private void Update()
    {
        /*if (Time.time > nextActionTime && useSkill0 == true)
        {
            nextActionTime += period;
            Instantiate(manaShot, new Vector3(Player.position.x, Player.position.y + 1.5f, Player.position.z), mainCamera.transform.rotation);
        }*/
    }

}
