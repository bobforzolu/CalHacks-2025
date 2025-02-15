using UnityEngine;

namespace System.AnimationSystem
{
    [CreateAssetMenu(fileName = "Attack_Strings", menuName = "Animation System/Attack strings")]
    public class AttackAnimationString : AnimationString
    {
        public override void AnimationFinish(AniamtionEventType animationName)
        {
            base.AnimationFinish(animationName);
        }

        public override void Initalize()
        {
            base.Initalize();
        }

        public override AnimationClip GetAnimationClip(string animationName)
        {
            return animationClips[animationName];
        }

        public override void UpdateString()
        {
            base.UpdateString();
        }

        public override void ResetAnimation()
        {
            base.ResetAnimation();
        }
    }
}