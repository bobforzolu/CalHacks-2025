using UnityEngine;

namespace System.AnimationSystem
{
    [CreateAssetMenu(fileName = "Generic", menuName = "Animation System/Generic strings")]
    public class GenericAnimationString : AnimationString
    {
        
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

        public override void AnimationFinish(AniamtionEventType animationName)
        {
            base.AnimationFinish(animationName);
        }
    }
}