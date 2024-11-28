using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ButtonAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject Arrow1;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Arrow1.transform.DOScale(1f, 0.5f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Arrow1.transform.DOScale(0f, 0.5f);
    }
}
