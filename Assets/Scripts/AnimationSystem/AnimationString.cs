using System.Collections.Generic;
using UnityEngine;

namespace System.AnimationSystem
{
    public abstract class AnimationString: ScriptableObject
    {
        public string stringName;
   
        public List<AnimationNode> animationNodes = new List<AnimationNode>();
     
        public RuntimeAnimatorController runtimeAnimatorController;

        protected Dictionary<string, AnimationClip> animationClips;
        protected AnimationNode currentAnimationNode;

        /// <summary>
  
        public virtual void Initalize()
        {
            animationClips = new Dictionary<string, AnimationClip>();

            foreach (AnimationNode node in animationNodes)    
            {
                animationClips.Add(node.nodeName, node.clip );
            }
        }
        
        /// <summary>
        ///  play aspecific type of animation
        /// </summary>
        /// <param name="animationName"></param>
        public virtual AnimationClip GetAnimationClip(string animationName)
        {
            return null;
        }
        
        /// <summary>
        /// perform updates
        /// </summary>
        public virtual void UpdateString()
        {
            
        }
        /// <summary>
        /// apply animation events
        /// </summary>
        /// <param name="animationName"></param>
        public virtual void AnimationFinish(AnimationEventType animationName)
        {
            
        }
        public virtual void ResetAnimation()
        {
            
        }
        
    }
}