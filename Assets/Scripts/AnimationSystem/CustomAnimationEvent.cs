using System;
using UnityEngine;


    public class CustomAnimationEvent : MonoBehaviour
    {
        public event Action<AniamtionEventType> OnAniamtion;
        public void DammageTriggerEvent()
        {
            OnAniamtion?.Invoke(AniamtionEventType.DamageTrigger);
        }
        public void AnimationFinishTriggerEvent()
        {
            OnAniamtion?.Invoke(AniamtionEventType.AnimationFinishTrigger);
        }
        public void CancelActionTriggerEvent()
        {
            OnAniamtion?.Invoke(AniamtionEventType.CancelActionsTrigger);
        }
    }

    public enum AniamtionEventType
    {
        DamageTrigger,
        VfxTrigger,
        AnimationFinishTrigger,
        CancelActionsTrigger
    }
