using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour
{
    [SerializeField] Image Arrow1;
    [SerializeField] Image Arrow2;
    [SerializeField] Color Color1;
    [SerializeField] Color Color2;
    [SerializeField] Animator _animator;
    public void PlayAnim2(string Event)
    {
        _animator.Play(Event);
    }
    public void PlayAnim(bool Visible)
    {
        if (Visible)
        {
            Arrow1.color = Color1;
            Arrow2.color = Color1;
        }
        else
        {
            Arrow1.color = Color2;
            Arrow2.color = Color2;
        }
    }
}
