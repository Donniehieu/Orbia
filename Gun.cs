using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Dictionary<int, Queue<GameObject>> ListBullet = new Dictionary<int, Queue<GameObject>>();
    public GameObject bulletPrefab;
    public Transform gunTrans;
    public void InitBullet(GameObject bulletPrefab, int sizePool)
    {

        int id = bulletPrefab.GetInstanceID();
        if (!ListBullet.ContainsKey(id))
        {
            ListBullet.Add(id, new Queue<GameObject>());
            for (int i = 0; i < sizePool; i++)
            {
                GameObject newOb = Instantiate(bulletPrefab);

                newOb.SetActive(false);
                ListBullet[id].Enqueue(newOb);
            }
        }

    }
    public void ReuseBullet(GameObject bulletPrefab, Transform trans, Quaternion rot)
    {
        int id = bulletPrefab.GetInstanceID();
        if (ListBullet.ContainsKey(id))
        {
            GameObject reuseOb = ListBullet[id].Dequeue();
            ListBullet[id].Enqueue(reuseOb);
            reuseOb.SetActive(true);
            reuseOb.transform.position = trans.position;
            reuseOb.transform.rotation = rot;

        }
    }

}
