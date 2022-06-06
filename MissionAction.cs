using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MissionAction : MonoBehaviour
{
    public Action completeMission;
    public Action Receive2ndMission;
    public enum TypeMission
    {
        vuotdendo, damnguoi, damxecanhsat, vuotchotkiemtra, damxekhac, banxekhac, banxecanhsat, chaytocdocao
    }
    public TypeMission typeMission;
    int randMission;
    private void Start()
    {
        ChooseMission();
    }
    private void ChooseMission()
    {
        randMission = 7;
        switch (randMission)
        {
            case 0:
                typeMission = TypeMission.vuotdendo;
                break;
            case 1:
                typeMission = TypeMission.damnguoi;
                break;
            case 2:
                typeMission = TypeMission.damxecanhsat;
                break;
            case 3:
                typeMission = TypeMission.vuotchotkiemtra;
                break;
            case 4:
                typeMission = TypeMission.damxekhac;
                break;
            case 5:
                typeMission = TypeMission.banxekhac;
                break;
            case 6:
                typeMission = TypeMission.banxecanhsat;
                break;
            case 7:
                typeMission = TypeMission.chaytocdocao;
                break;
        }
    }
    public bool isSuccess1stMission;
    public bool isSuccess2ndMission;
    public bool isReceive1stMission;
    public bool isRefuse1stMission;
    public bool isReceive2ndMission;
}
