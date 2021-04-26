using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaShot : MonoBehaviour
{
    private Camera mainCamera;
    private Transform player;
    private Vector3 way;
    public float distans = 20f;
    public float speed = 20f;


    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        way = mainCamera.transform.forward * distans;
    }

    void Update()
    {
        //Debug.Log(mainCamera.transform.forward);
        if (this.transform.position != way)
        {
            this.transform.Translate(way * speed * Time.deltaTime);
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
