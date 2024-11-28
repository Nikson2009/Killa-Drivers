using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonAnim : MonoBehaviour
{
    [SerializeField] GameObject Arrow1;
    [SerializeField] GameObject Arrow2;
    public void OnPointEnter()
    {
        Arrow1.transform.DOScaleX(10,0.01f);
    }
    public void OnPointExit()
    {

    }
}
