using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXCurveManager : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] GameObject pointOne;
    [SerializeField] GameObject pointTwo;
    [SerializeField] GameObject pointThree;
    [SerializeField] GameObject pointFour;

    [Header("Parameters")]
    [SerializeField] float time = 1f;

    public void SetCurvePoints(Vector3 posOne, Vector3 posTwo, Vector3 posThree, Vector3 posFour)
    {
        pointOne.transform.position = posOne;
        pointTwo.transform.position = posTwo;
        pointThree.transform.position = posThree;
        pointFour.transform.position = posFour;
    }
    public void StartTimerToDestroy()
    {
        StartCoroutine(TimerToDestroy());
    }

    IEnumerator TimerToDestroy()
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
