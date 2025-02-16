using System;
using UnityEngine;


    public class CustomAnimationEvent : MonoBehaviour
    {
        public event Action<AnimationEventType> OnAniamtion;
        public void DammageTriggerEvent()
        {
            OnAniamtion?.Invoke(AnimationEventType.DamageTrigger);
        }
        public void AnimationFinishTriggerEvent()
        {
            OnAniamtion?.Invoke(AnimationEventType.AnimationFinishTrigger);
        }
        public void CancelActionTriggerEvent()
        {
            OnAniamtion?.Invoke(AnimationEventType.CancelActionsTrigger);
        }
    }

    public enum AnimationEventType
    {
        DamageTrigger,
        VfxTrigger,
        AnimationFinishTrigger,
        CancelActionsTrigger
    }
