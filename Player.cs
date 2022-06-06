using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField] Transform parent;
    public GameObject HP;
    GameObject cloneHp;
    [SerializeField] Camera cam;
    public bool isShot;
    private void Awake()
    {
        cloneHp = Instantiate(HP, parent);
        cloneHp.SendMessage("SetUI", this, SendMessageOptions.RequireReceiver);

    }
    public void Update()
    {
        ShowHpPower();
    }
    private void ShowHpPower()
    {
        if (Utilities.GetDistance(cam.transform, transform) < 30f && Utilities.IsBeHindMe(cam.transform, transform))
        {
            cloneHp.SetActive(true);
        }
        if (isShot == true)
        {
            cloneHp.SetActive(true);
        }
        else
        {
            cloneHp.SetActive(false);
        }
    }
    public void SetValueHp(float damage)
    {
        cloneHp.GetComponent<Slider>().value -= damage;
    }
}
