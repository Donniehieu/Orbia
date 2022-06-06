
using UnityEngine;
using TMPro;

public class ResultGame :MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtcrashNormalCar;
    [SerializeField] TextMeshProUGUI txtcrashPoliceCar;
    [SerializeField] TextMeshProUGUI txtcrashPublicVehicle;
    [SerializeField] TextMeshProUGUI txtcrashTrafficPoles;
    [SerializeField] TextMeshProUGUI txtcrashTrafficLight;
    [SerializeField] TextMeshProUGUI txtcrashAmbulance;

    [SerializeField] TextMeshProUGUI txtCoinCollectCount;
    [SerializeField] TextMeshProUGUI txtFuelCansCollectCount;
    [SerializeField] TextMeshProUGUI txtHealCollectCount;
    [SerializeField] TextMeshProUGUI txtShieldCollectCount;

    [SerializeField] TextMeshProUGUI txtRemainHPCount;
    [SerializeField] TextMeshProUGUI txtTimeFinish1stMission;
    [SerializeField] TextMeshProUGUI txtMaxSpeed;
    //[SerializeField] TextMeshProUGUI txtDrift;

    //[SerializeField] TextMeshProUGUI txtBaseReward;
    //[SerializeField] TextMeshProUGUI txtTaskReward;
    //[SerializeField] TextMeshProUGUI txtVictoryReward;

    [SerializeField] VehicleMoving vehicleMoving;
    [SerializeField] ShowUIController showUIController;
    private void Awake()
    {
        vehicleMoving = FindObjectOfType<VehicleMoving>();
        showUIController = FindObjectOfType<ShowUIController>();
    }
    public void UpdateResultGame()
    {
        
        txtcrashPoliceCar.text = StringHelper.CrashToPoliceCar+ $": {vehicleMoving.crashPoliceCount}";
        txtcrashNormalCar.text = StringHelper.CrashToOtherCar + $": {vehicleMoving.crashNormalCount}";
        txtRemainHPCount.text = StringHelper.RemainHP + $": {showUIController.currentHealth}/{showUIController.totalHP}";
        txtTimeFinish1stMission.text = StringHelper.TimeFinish1stMission + $": {vehicleMoving.timeFinish1stMission:00} s";
        txtMaxSpeed.text = StringHelper.MaxSpeed + $": {vehicleMoving.maxSpeed*6:00} Km/h";
        txtcrashPublicVehicle.text = StringHelper.PublicVehicles + $": {vehicleMoving.crashPublicVehicleCount}";
        //txtcrashAmbulance.text = StringHelper.Ambulance + $": {vehicleMoving.crashAmbulance}";
        //txtcrashTrafficLight.text = StringHelper.TrafficLight + $": {vehicleMoving.crashTrafficLight}";
        //txtcrashTrafficPoles.text = StringHelper.TrafficPoles + $": {vehicleMoving.crashTrafficPole}";
        txtCoinCollectCount.text = StringHelper.Coins + $": {vehicleMoving.coinCollected}";
        txtFuelCansCollectCount.text = StringHelper.FuelCans + $": {vehicleMoving.fuelCansCollected}";
        //txtHealCollectCount.text = StringHelper.Heal + $": {vehicleMoving.healCollected}";
        //txtShieldCollectCount.text = StringHelper.Shields + $": {vehicleMoving.shieldCollected}";
    }
}
