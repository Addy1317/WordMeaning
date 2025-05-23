#region Summary
///<summary>
/// Vfx Script for Button Hover Effect
///</summary>
#endregion
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WM.VFX
{
    public class VFXManager : MonoBehaviour
    {
        [Header("UI Buttons Effects")]
        [SerializeField] private float _scal4eUp = 1.2f;
        [SerializeField] private float _scaleUpDuration = 0.2f;


        #region UI Buttons Methods
        internal void AddHoverEffect(Button button, float scaleUp = 1.2f, float duration = 0.2f)
        {
            EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry pointerEnter = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerEnter
            };
            pointerEnter.callback.AddListener((eventData) => OnHoverEnter(button, scaleUp, duration));

            EventTrigger.Entry pointerExit = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerExit
            };
            pointerExit.callback.AddListener((eventData) => OnHoverExit(button, duration));

            trigger.triggers.Add(pointerEnter);
            trigger.triggers.Add(pointerExit);
        }

        internal void OnHoverEnter(Button button, float scaleUp, float duration)
        {
            button.transform.DOKill();
            button.transform.DOScale(scaleUp, duration).SetEase(Ease.OutBack).SetUpdate(true);
        }

        internal void OnHoverExit(Button button, float duration)
        {
            button.transform.DOKill();
            button.transform.DOScale(1f, duration).SetEase(Ease.InBack).SetUpdate(true);
        }
        #endregion
    }
}
