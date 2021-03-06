using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrienlyAnim : MonoBehaviour
{

    [SerializeField]
    private GameObject obj;

    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }
    [SerializeField]
    private FrienlyMove FriendMove;
    string previous = "Idle";
    void Start()
    {
        previous = "Idle";

    }
    public void AnimationPlayTriger(string Triger)
    {

        SetTriger(Triger, previous);
        previous = Triger;

    }
  
    public void SetTriger(string value, string previous)
    {

        Animator.SetTrigger(value);
        if (value != previous)
            Animator.ResetTrigger(previous);
    }
    public void AttackDisable()
    {

        if (obj.transform.childCount > 0)
        {
            IJettisonable ıj = obj.transform.GetChild(0).gameObject.GetComponent<IJettisonable>();
            ıj.Throwing(FriendMove.EnemyGameObject.transform.position - obj.transform.GetChild(0).gameObject.transform.position);
            obj.transform.GetChild(0).gameObject.transform.SetParent(null);
        }
    }
    public void AttackOffline()
    {
        FriendMove.AttackOnline = false;
    }
    public void AttackOnline()
    {
        FriendMove.AttackOnline = true;
    }
}
