using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    float speed = 50;
    public float bonus;
    public VehicleMoving vehicle;
    public void Awake()
    {
        vehicle = FindObjectOfType<VehicleMoving>();
    }
    private void Update()
    {
        bonus = vehicle._speed + speed;
        transform.Translate(Vector3.forward * Time.deltaTime * (vehicle._speed + speed));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PoliceCar"))
        {
            other.GetComponent<Player>().SetValueHp(3);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PoliceCar"))
        {
            other.GetComponent<Player>().isShot = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PoliceCar"))
        {
            other.GetComponent<Player>().isShot = false;
        }
    }
}
