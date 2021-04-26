using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShot : MonoBehaviour
{

    public float speed = 5f;
    Vector3 lastPos;


    void Start()
    {
        lastPos = transform.position;
    }


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Linecast(lastPos, transform.position, out hit))
        {
            print(hit.transform.name);
           // Destroy(gameObject);
        }

        lastPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Stats>().HPDecrease += 50f;
            Destroy(gameObject);
        }

        if (other.tag == "NPS")
        {
            print("NPS");
            other.GetComponent<StatsNPS>().HPDecrease += 50f;
             Destroy(gameObject);
        }
    }
}
