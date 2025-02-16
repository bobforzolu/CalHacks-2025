using System.Collections.Generic;
using UnityEngine;

namespace System.AnimationSystem
{
    public class AnimationController : MonoBehaviour
    {
        private AnimationDirectory copyanimationDirectory;
        public AnimationDirectory animationDirectory;
        public Animator animator;

        
        public void Initialize()
        {
            copyanimationDirectory = ScriptableObject.CreateInstance<AnimationDirectory>();
            copyanimationDirectory.Animations = new List<AnimationString>(animationDirectory.Animations);
            copyanimationDirectory.Initialize(animator);


        }

        public void PlayAnimation(string StringName, string animationName)
        {
            
            copyanimationDirectory.playGenericAnimation(StringName, animationName);
            Debug.Log("playing"+ animationName);
        }

        public void LoopAnimation(string StringName)
        {
            
        }
        public void Update()
        {
            if(copyanimationDirectory != null)
                copyanimationDirectory.updateStringInfo();
        }
    }
}