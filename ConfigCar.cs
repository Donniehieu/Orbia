using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="TypeCar", menuName ="CreateTypeofCar")]
public class ConfigCar : ScriptableObject
{
    public float minSpeed;
    public float maxSpeed;
    public bool IsGunEquiped;
}
