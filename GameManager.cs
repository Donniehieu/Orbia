using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ShowUIController showUIController;
    [SerializeField] PoliceCar policeCar;
    [SerializeField] MissionAction missionAction;
    public void Replay()
    {
        showUIController.startUI.SetActive(true);
        if (showUIController.MissionFail.activeInHierarchy)
        {
            showUIController.MissionFail.SetActive(false);
            missionAction.isReceive1stMission = false;

        }
        if (showUIController.loseGame.activeInHierarchy)
        {
            showUIController.loseGame.SetActive(false);
        }
    }

}
