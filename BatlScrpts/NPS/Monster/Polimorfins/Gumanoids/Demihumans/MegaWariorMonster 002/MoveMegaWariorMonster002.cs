using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveMegaWariorMonster002 : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject enemy;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemy = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        agent.SetDestination(enemy.transform.position);
    }
}
