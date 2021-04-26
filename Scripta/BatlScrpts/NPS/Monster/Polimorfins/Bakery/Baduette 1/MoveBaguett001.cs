using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveBaguett001 : MonoBehaviour
{
    public Animator modelAnimator;
    private Animator playerAnimator;
    private NavMeshAgent agent;
    private GameObject Player;
    private float distans;
    public float radius = 20f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
       distans = Vector3.Distance(Player.transform.position, transform.position);
        if (distans >= radius)
        {
            agent.enabled = false;

            modelAnimator.Play("Stop");
        }
        if (distans < radius && distans > 2f)
        {
            agent.enabled = true;
            agent.SetDestination(Player.transform.position);

            modelAnimator.Play("jump");
        }
        if (distans <= 2f)
        {
            agent.enabled = false;

            modelAnimator.Play("jump");
        }



    }
}
