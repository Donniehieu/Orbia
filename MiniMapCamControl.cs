using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamControl : MonoBehaviour
{
    [SerializeField] Transform myTarget;
    private void Update()
    {
        transform.position = new Vector3(myTarget.position.x, transform.position.y, myTarget.transform.position.z);
        transform.rotation = Quaternion.Euler(new Vector3(90, myTarget.eulerAngles.y, 0));
    }
}
