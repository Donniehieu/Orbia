using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.UI;
public class ShowUIController : MonoBehaviour
{
    [SerializeField] MissionAction missionAction;
    [SerializeField] TextMeshProUGUI txt_Time;
    [SerializeField] TextMeshProUGUI txt_HP;
    [SerializeField] float playTime;
    public int currentHealth;
    [SerializeField] GameObject curHealthandTime;
    public GameObject loseGame;
    public GameObject winGame;
    [SerializeField] GameObject Mission;
    [SerializeField] TextMeshProUGUI txt_MissionContent;
    [SerializeField] GameObject miniMap;
    public GameObject MissionFail;
    [SerializeField] GameObject refuseMission;
    public GameObject uiGamePlay;
    public GameObject startUI;
    [SerializeField] GameObject controlMoveUI;
    [SerializeField] GameObject uiReceiveMission;
    public GameObject startButton;
    [SerializeField] VehicleMoving vehicleMoving;
    [SerializeField] ScriptableManager map1Data;
    [SerializeField] PoliceCar policeCar;
    [SerializeField] LineRenderer guideLine;
    [SerializeField] NavMeshAgent policeAgent;
    [SerializeField] Slider sliderHP;
    [SerializeField] TextMeshProUGUI txt_winorlose;
    [SerializeField] Gun gun;
    [SerializeField] TextMeshProUGUI txt_Speedhienthi;
    [SerializeField] float speedTarget;
    public float speedMission;
    private int totalHP;
    public bool isAccept, isRefuse;

    public float GetPlayTime => playTime;
    public int GetCurrentHealth => currentHealth;
    private void Start()
    {
        gun.InitBullet(gun.bulletPrefab, 10);
        missionAction.completeMission += ShowLoseGame;
    }
    public void StartGame()
    {

        vehicleMoving.myCar.position = new Vector3(map1Data.spawnPoint.x, map1Data.spawnPoint.y, map1Data.spawnPoint.z);
        vehicleMoving.myCar.rotation = Quaternion.Euler(new Vector3(0, -32.5f, 0));
        vehicleMoving._speed = 0;
        startUI.SetActive(false);
        uiGamePlay.SetActive(true);
        miniMap.SetActive(true);
        totalHP = map1Data.hpValueLeRound1;
        currentHealth = totalHP;
        sliderHP.value = (currentHealth * 100f / totalHP);
        playTime = map1Data.timePlayRound1;
        txt_Time.text = $"{ (int)playTime / 60:00}:{(int)playTime % 60:00}";
        missionAction.isSuccess1stMission = false;
        missionAction.isReceive1stMission = false;
        missionAction.isReceive2ndMission = false;
        missionAction.isSuccess2ndMission = false;
        isAccept = false;
        isRefuse = false;
        vehicleMoving.StartRun();
    }
    private void ShowWinGame()
    {
        winGame.SetActive(true);
        if (missionAction.isSuccess2ndMission == false)
        {
            txt_winorlose.text = "Lose";
            loseGame.SetActive(false);
        }
        else if (missionAction.isSuccess2ndMission == true)
        {
            txt_winorlose.text = "Victory";
            uiGamePlay.SetActive(false);
        }

        vehicleMoving.isPlaying = false;
        missionAction.isSuccess2ndMission = true;
    }
    private void ShowLoseGame()
    {
        loseGame.SetActive(true);
        vehicleMoving.isPlaying = false;
        uiGamePlay.SetActive(false);
    }
    private void ShowLose1stMission()
    {
        MissionFail.SetActive(true);
        uiGamePlay.SetActive(false);
        vehicleMoving.isPlaying = false;
    }
    public void UpdateHealth(int healthVolumn)
    {
        currentHealth += healthVolumn;
        sliderHP.value = (currentHealth * 100 / totalHP);

    }
    public float SpeedShow
    {
        get { return speedTarget; }
        set
        {
            speedTarget = value;
            txt_Speedhienthi.text = $"{(int)speedTarget:00} Km/h";
        }

    }


    public void AddTimeToPlay(int time)
    {
        playTime += time;
        txt_Time.text = $"{ (int)playTime / 60:00}:{(int)playTime % 60:00}";
    }
    public void Receive1stMission()
    {
        AcceptMission();
        missionAction.isReceive1stMission = true;
        totalHP = map1Data.hpValueLeRound1;
        playTime = map1Data.timePlayRound1;
        sliderHP.value = (currentHealth * 100 / totalHP);

        txt_Time.text = $"{ (int)playTime / 60:00}:{(int)playTime % 60:00}";
    }
    private void Receive2ndMission()
    {
        Show2ndMission();
        AcceptMission();
        policeCar.canChasing = true;
        uiReceiveMission.SetActive(false);
        playTime = map1Data.timePlayRound2;
        txt_Time.text = $" { (int)playTime / 60:00}:{(int)playTime % 60:00}";
        totalHP = map1Data.hpValueLeRound2;
        currentHealth = totalHP;
        sliderHP.value = (currentHealth * 100 / totalHP);
        missionAction.isReceive2ndMission = true;
        missionAction.Receive2ndMission?.Invoke();

    }
    private void AcceptMission()
    {
        isAccept = true;
        miniMap.SetActive(true);
        curHealthandTime.SetActive(true);
        Mission.SetActive(false);

    }
    public void RefuseMission()
    {
        miniMap.SetActive(true);
        Mission.SetActive(false);
    }
    private void CountDownTime()
    {
        if (playTime <= 0)
        {
            playTime = 0;
            txt_Time.text = $" { 00:00}:{00:00}";
            CheckWinLose();
        }
        else
        {
            playTime -= Time.deltaTime;
            txt_Time.text = $" { (int)playTime / 60:00}:{(int)playTime % 60:00}";
        }

    }
    public void Exit()
    {
        ShowWinGame();
    }
    private void CheckWinLose()
    {
        if (playTime <= 0 && missionAction.isSuccess1stMission == false && missionAction.isReceive1stMission == true)
        {
            ShowLose1stMission();
            vehicleMoving.isPlaying = false;
        }

        if (playTime >= 0 && missionAction.isSuccess1stMission == true && missionAction.isReceive2ndMission == false)
        {
            Show2ndContentMission();
        }
        if (playTime <= 0 && currentHealth > 0 && missionAction.isReceive2ndMission == true)
        {
            ShowWinGame();
            policeCar.canChasing = false;
        }
        else if (currentHealth < 0 && missionAction.isReceive2ndMission == true)
        {
            policeCar.canChasing = false;
            missionAction.completeMission?.Invoke();
        }
    }
    private void DrawGuideLine()
    {
        if (missionAction.typeMission == MissionAction.TypeMission.damxecanhsat)
        {
            Utilities.DrawDirection(policeAgent, transform, guideLine);
        }
    }
    private void Show2ndMission()
    {
        StartCoroutine(Show2ndContentMission());
    }
    IEnumerator Show2ndContentMission()
    {

        yield return new WaitForSeconds(1f);
        miniMap.SetActive(false);
        Mission.SetActive(true);
        txt_MissionContent.text = $" You have to escape from Police's chasing as long as possible";
        yield return new WaitForSeconds(5f);
        Mission.SetActive(false);
        miniMap.SetActive(true);
    }
    public void Show1stMission()
    {
        StartCoroutine(Show1stContentMission());
    }
    IEnumerator Show1stContentMission()
    {
        yield return new WaitForSeconds(5f);
        {
            Mission.SetActive(true);
            uiReceiveMission.SetActive(true);
            miniMap.SetActive(false);
            switch (missionAction.typeMission)
            {
                case MissionAction.TypeMission.vuotdendo:
                    txt_MissionContent.text = $"Run red light";
                    break;
                case MissionAction.TypeMission.damnguoi:
                    txt_MissionContent.text = $"Crash into someone else";
                    break;
                case MissionAction.TypeMission.damxecanhsat:
                    txt_MissionContent.text = $"Crash into Police car";
                    break;
                case MissionAction.TypeMission.vuotchotkiemtra:
                    txt_MissionContent.text = $"Pass the roadblocks";
                    break;
                case MissionAction.TypeMission.damxekhac:
                    txt_MissionContent.text = $"Crash into Other car";
                    break;
                case MissionAction.TypeMission.banxekhac:
                    txt_MissionContent.text = $"Shot Other car";
                    break;
                case MissionAction.TypeMission.banxecanhsat:
                    txt_MissionContent.text = $"Shot Police car";
                    break;
                case MissionAction.TypeMission.chaytocdocao:
                    speedMission = 300;
                    txt_MissionContent.text = $"Reach at {speedMission}km/h speed";
                    break;
                default:
                    break;
            }

        }
    }
    public void Shot()
    {
        gun.ReuseBullet(gun.bulletPrefab, gun.gunTrans, Quaternion.Euler(new Vector3(0, gun.transform.eulerAngles.y, 0)));
    }
    private void Update()
    {
        if (isAccept == true)
        {
            DrawGuideLine();
            CountDownTime();
        }
        if (missionAction.isSuccess1stMission == true && missionAction.isReceive2ndMission == false)
        {
            Receive2ndMission();
        }

    }
}
