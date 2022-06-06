using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Transform cameraMain;
    public Transform transformtarget;
    private void Update()
    {
        this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(transformtarget.position.x, transformtarget.position.y + 1);
        this.gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, cameraMain.transform.eulerAngles.y, 0));
    }
}
