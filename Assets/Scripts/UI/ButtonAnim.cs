using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ButtonAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject Arrows;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Arrows.transform.DOScale(1f, 0.5f).SetUpdate(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Arrows.transform.DOScale(0f, 0.5f).SetUpdate(true);
    }
    public void KillAnimation()
    {
        Arrows.transform.DOKill();
    }
}
