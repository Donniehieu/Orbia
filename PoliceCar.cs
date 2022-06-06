
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class PoliceCar : MonoBehaviour
{
    public NavMeshAgent policeAgent;
    [SerializeField] VehicleMoving vehicleMovement;
    [SerializeField] ShowUIController showUIController;
    [SerializeField] AudioSource policeAudioSource;
    [SerializeField] AudioSource policeAudioHorn;
    [SerializeField] AudioSource shotAudioSource;
    [SerializeField] AudioClip clipgunShot;
    public bool canChasing;
    [SerializeField] MissionAction missionAction;

    private void OnEnable()
    {
        canChasing = false;
    }
    private void Start()
    {
        missionAction.Receive2ndMission += Chasing;
    }
    private void Chasing()
    {
        StartCoroutine(StartChasing());
    }
    IEnumerator StartChasing()
    {
        yield return new WaitForSeconds(2f);
        policeAgent.speed = 30;
        policeAudioSource.Play();
        policeAudioHorn.Play();
    }
    private void StopChasing()
    {
        policeAgent.speed = 0;
        policeAudioHorn.Stop();
        policeAudioSource.Stop();
    }
    float timeCollision = 0;
    private void MakeDamageAround()
    {
        timeCollision += Time.deltaTime;
        if (timeCollision > 3f)
        {
            showUIController.UpdateHealth(-20);
            vehicleMovement.OnDead();
            timeCollision = 0;
        }
    }
    float timetoShot = 0;
    private void ShotCar()
    {
        if (timetoShot > 5)
        {
            showUIController.UpdateHealth(-30);
            shotAudioSource.PlayOneShot(clipgunShot);
            vehicleMovement.OnDead();
            timetoShot = 0;
        }
    }
    public bool CanMakeDamageArround()
    {
        return Utilities.GetDistance(vehicleMovement.myCar, policeAgent.transform) < 10;
    }

    public bool CanShotCar()
    {
        return (!Utilities.IsBeHindMe(vehicleMovement.myCar, policeAgent.transform)
           && Utilities.GetDistance(vehicleMovement.myCar, policeAgent.transform) < 30
           && showUIController.GetPlayTime < 30);
    }

    private void Update()
    {
        if (missionAction.isReceive1stMission == true && missionAction.isReceive2ndMission == false)
        {
            policeAgent.SetDestination(vehicleMovement.myCar.position);
            policeAgent.speed = 0;
        }
        if (canChasing == false)
        {
            StopChasing();
            return;
        }
        if (canChasing == true)
        {
            timetoShot += Time.deltaTime;
            policeAgent.SetDestination(vehicleMovement.myCar.position);
            if (CanMakeDamageArround())
            {
                MakeDamageAround();
            }
            if (CanShotCar())
            {
                ShotCar();
            }
        }
        else if (canChasing == false && missionAction.isSuccess2ndMission == false && missionAction.isReceive2ndMission == true)
        {
            policeAgent.SetDestination(vehicleMovement.myCar.position);
        }


    }

}
