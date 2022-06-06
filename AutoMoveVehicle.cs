using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AutoMoveVehicle : MonoBehaviour
{
    [SerializeField] NavMeshAgent thisAgent;
    [SerializeField] VehicleMoving vehicleMoving;
    [SerializeField] Transform targetPosition;
    private void OnEnable()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        vehicleMoving = FindObjectOfType<VehicleMoving>();
    }
    // Update is called once per frame
    void Update()
    {
        if (vehicleMoving.isPlaying == false)
        {
            return;
        }
        MoveToDestination();
    }
    private void MoveToDestination()
    {
        thisAgent.SetDestination(targetPosition.position);
    }
}
