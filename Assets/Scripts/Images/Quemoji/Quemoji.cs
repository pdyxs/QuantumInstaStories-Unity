using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Quemoji : MonoSingleton<Quemoji>
{
    protected override bool DestroyOnLoad => true;

    public Animator animator
    {
        get
        {
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();
            }

            return _animator;
        }
    }

    private Animator _animator;

    public Image Image
    {
        get {
            if (_image == null)
            {
                _image = GetComponent<Image>();
            }

            return _image;
        }
    }
    private Image _image;

    public void SetTo(AnimatorController controller)
    {
        animator.runtimeAnimatorController = controller;
    }
}
