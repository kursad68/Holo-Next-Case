using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnim : MonoBehaviour
{
    string previous = "Idle";
 
    void Start()
    {
        previous = "Idle";
    }
    void Update()
    {

    }
    private void OnEnable()
    {
        EventManager.onAnimationPlay += AnimationPlayTriger;
    }
    private void OnDisable()
    {
        EventManager.onAnimationPlay -= AnimationPlayTriger;
    }
    public void AnimationPlayTriger(string Triger)
    {

        EventManager.onAnimatorAction.Invoke(Triger, previous);
        previous = Triger;

    }
}
