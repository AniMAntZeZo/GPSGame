using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject enemy;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemy = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(enemy.transform.position);
    }
}
