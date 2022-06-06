using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataObject", menuName = "LevelData")]
public class ScriptableManager : ScriptableObject
{
    public float timePlayRound1;
    public int hpValueLeRound1;
    public float timePlayRound2;
    public int hpValueLeRound2;
    public Vector3 spawnPoint;

}
