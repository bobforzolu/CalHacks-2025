using System.Collections.Generic;
using UnityEngine;

namespace System.AnimationSystem
{
    [CreateAssetMenu(fileName = "Controller", menuName = "Animation System/ String Controller")]
    public class AnimationDirectory: ScriptableObject
    {
        public List<AnimationString> Animations;
        [NonSerialized]
        public Dictionary<String, AnimationString> AnimationDictionary ;
        public RuntimeAnimatorController animatorController;
        private AnimationString currentString;
        private Animator animator;

        public void Initialize(Animator animator)
        {
            AnimationDictionary = new Dictionary<string, AnimationString>(); // Ensure it's fresh
            this.animator = animator;
            SetupAnimationDictionary();
            
        }

        public void playGenericAnimation(string stringName, string animationName)
        {
            currentString = AnimationDictionary[stringName];
            animator.runtimeAnimatorController = currentString.runtimeAnimatorController;
            animator.Play( currentString.GetAnimationClip(animationName).name );
        }
        


        public void updateStringInfo()
        {
            if(Animations == null) return;
            foreach (AnimationString animation in Animations)
            {
                animation.UpdateString();
            }
        }

        private void SetupAnimationDictionary()
        {
            foreach (AnimationString animation in Animations)
            {
                animation.Initalize();
                AnimationDictionary.Add(animation.stringName, animation);
            }
        }
    }
}