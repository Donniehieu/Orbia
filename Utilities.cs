using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
public class Utilities : MonoBehaviour
{
    public static IEnumerator DoCallBackAfterSeconds(float waitedTime, System.Action action)
    {
        yield return new WaitForSeconds(waitedTime);
        action?.Invoke();
    }

    public static float GetDistance(Transform target, Transform mine)
        => Vector3.Distance(target.position, mine.position);
    public static bool IsBeHindMe(Transform target, Transform mine)
    {

        Vector3 direction = mine.InverseTransformPoint(target.position) - mine.position;
        return Vector3.Angle(direction, -mine.forward) < 90f;
    }
    public static void DrawDirection(NavMeshAgent target, Transform transform, LineRenderer myLine)
    {
        myLine.positionCount = target.path.corners.Length;
        myLine.SetPosition(0, transform.position);
        float countPoint = target.path.corners.Length;
        if (countPoint < 2)
        {
            return;
        }
        for (int i = 0; i < countPoint; i++)
        {
            Vector3 pointPosition = new Vector3(target.path.corners[i].x, target.path.corners[i].y, target.path.corners[i].z);
            myLine.SetPosition(i, pointPosition);
        }
    }
}
