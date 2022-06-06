using UnityEngine.AI;
using UnityEngine;

public class VehicleMoving : MonoBehaviour
{
    float tangtoc;
    public bool isPlaying;
    public Transform myCar;
    public float _speed;
    [SerializeField] ShowUIController _showUIController;
    [SerializeField] PoliceCar _policeCar;
    [SerializeField] AudioSource audioSourceCarSound;
    [SerializeField] AudioSource audioSourceCrash;
    [SerializeField] AudioClip clipkhoidong, cliptangtoc;
    [SerializeField] MissionAction missionAction;
    [SerializeField] NavMeshAgent carAgent;
    [SerializeField] Transform targetPos;
    [SerializeField] Player player;
    float thoigiantangtoc;
    private void Awake()
    {
        thoigiantangtoc = 0;
    }


    public void StartRun()
    {
        tangtoc += Time.deltaTime * 0.2f;
        _speed = Mathf.Lerp(0, 10, tangtoc);
        _showUIController.Show1stMission();
        _showUIController.startButton.SetActive(false);
        isPlaying = true;
        countCrashMission = 0;
    }

    private void AutoIncreaseSpeed()
    {
        thoigiantangtoc = Time.deltaTime * 0.1f;
        _speed = Mathf.Lerp(_speed, 25, thoigiantangtoc);
    }
    public void Increase_1X_Speed()
    {
        _speed = 10;
    }
    public void ReduceSpeed()
    {
        float t = 5 * Time.deltaTime;
        t = t > 0.9f ? 0 : 5 * Time.deltaTime;
        _speed = Mathf.Lerp(_speed, 0, t);
    }
    public void Increase_2X_Speed()
    {
        _speed = 20;
    }
    public void Increase_3X_Speed()
    {
        _speed = 60;
    }
    private void Running()
    {
#if UNITY_ANDROID
        float t = Input.acceleration.x;
        myCar.Rotate(Vector3.up, +8 * t * Time.deltaTime * _speed);
        myCar.Translate(Vector3.forward * _speed * Time.deltaTime);
#endif

        if (Input.GetKey(KeyCode.D))
        {
            myCar.Rotate(Vector3.up, +8 * 1f * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myCar.Rotate(Vector3.up, +8 * -1f * Time.deltaTime * _speed);
        }

    }
    private void FixedUpdate()
    {
        if (isPlaying == false && missionAction.isSuccess2ndMission == true)
        {
            carAgent.SetDestination(targetPos.position);
            carAgent.speed = 20;
        }
        else if (isPlaying == true)
        {
            Running();
            _showUIController.SpeedShow = _speed * 6;

        }
    }
    float countCrashMission;
    private void OnTriggerStay(Collider other)
    {
        if (isPlaying == false)
            return;
        if (other.CompareTag("PoliceCar"))
        {

            PlayCrashSound();

            if (missionAction.typeMission == MissionAction.TypeMission.damxecanhsat && _showUIController.isAccept == true)
            {
                countCrashMission++;
                if (countCrashMission <= 1 && missionAction.isSuccess1stMission == false)
                {
                    missionAction.isSuccess1stMission = true;
                }
            }

        }
        if (other.CompareTag("OtherCar"))
        {
            PlayCrashSound();
        }
    }
    private void PlayCrashSound()
    {
        audioSourceCrash.Play();
    }
    private void Update()
    {
        if (isPlaying == false)
            return;
        PlaySoundCar();
        AutoIncreaseSpeed();
        CheckGetHighSpeed();
    }
    private void CheckGetHighSpeed()
    {
        if (_showUIController.isAccept == true)
        {
            if (missionAction.typeMission == MissionAction.TypeMission.chaytocdocao && missionAction.isSuccess1stMission == false)
            {
                if (_speed * 6 > _showUIController.speedMission)
                {
                    missionAction.isSuccess1stMission = true;
                }
            }
        }
    }
    private void PlaySoundCar()
    {
        if (_speed < 9)
        {
            audioSourceCarSound.clip = clipkhoidong;
            audioSourceCarSound.PlayOneShot(clipkhoidong);
        }
        else if (_speed > 9)
        {
            audioSourceCarSound.clip = cliptangtoc;
            audioSourceCarSound.PlayOneShot(cliptangtoc);
        }
    }
    public void OnDead()
    {
        if (_showUIController.GetCurrentHealth <= 0)
        {
            missionAction.completeMission?.Invoke();
            _policeCar.canChasing = false;
        }
    }
}
