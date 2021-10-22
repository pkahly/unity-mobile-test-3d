using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    System.Random rand = new System.Random();
    NavMeshAgent agent;

    float minX = -30f;
    float maxX = 30f;
    float minZ = -20f;
    float maxZ = 20f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        StartCoroutine(Patrol());
    }

    void Update()
    {

    }

    IEnumerator Patrol()
    {
        while (true)
        {
            if (agent.velocity.x < 0.2 && agent.velocity.z < 0.2)
            {
                Vector3 nextPos = RandomPoint();
                agent.SetDestination(nextPos);

                Debug.Log(nextPos);
                yield return new WaitForSeconds(2);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    Vector3 RandomPoint()
    {
        int x = rand.Next((int)minX, (int)maxX);
        int z = rand.Next((int)minZ, (int)maxZ);

        return GetNavPosition(new Vector3(x, 0, z));
    }

    private Vector3 GetNavPosition(Vector3 center)
    {
        // Get Nearest Point on NavMesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(center, out hit, 30.0f, NavMesh.AllAreas))
        {
            return hit.position;
        }

        throw new ArgumentException("Failed to Get NavMesh Point");
    }
}
