using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="CarProperties", menuName ="VehicleData")]
public class DataVehicle : ScriptableObject
{
    public bool isGun;
    public float maxSpeedCar = 90f;
    public float totalHPCar;
    
   
}
