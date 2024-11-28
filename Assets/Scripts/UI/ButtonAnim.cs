using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] GameObject Visual;
    public void Animates(string Event)
    {
        _animator.StopPlayback();
        _animator.Play(Event);
    }
}
