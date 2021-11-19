using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }
    [SerializeField]
    private Movement movement;

    private void Start()
    {
        Debug.Log(obj.transform.childCount);
    }

    private void OnEnable()
    {

        EventManager.onAnimatorAction += SetTriger;
    }
    private void OnDisable()
    {
        EventManager.onAnimatorAction -= SetTriger;

    }
    public void HandleDamageObject(GameObject objectHandle)
    {
        obj = objectHandle;
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
            ıj.Throwing(movement.EnemyObject.transform.position- obj.transform.GetChild(0).gameObject.transform.position);
            obj.transform.GetChild(0).gameObject.transform.SetParent(null);
            
        }
    }
    public void AttackOffline()
    {
        movement.attackDisable();
    }
    public void AttackOnline()
    {
        movement.attackOnline();
    }
   
}
