using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestMove : MonoBehaviour
{
    public Transform[] points;          //巡回するポイント
    private int destPoint = 0;
    private NavMeshAgent agent;
    public float chaspeed = 15f;        //プレイヤーのスピード

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }


    void GotoNextPoint()
    {
        if (points.Length == 0)return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    public void EneChasing()
    {
        transform.position += transform.forward * chaspeed;
    }
}
