using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProgress : MonoBehaviour,IDamage
{
    [SerializeField]
    private GameObject HandleObject;
    public bool HandleObjectİsNull;
    [SerializeField]
    private CharacterPlayAnimation PlayAnimation;
   [SerializeField]
    private characterAnim characterAnim;
    private GameManager gm;
   private int can = 100;
    private Rigidbody rb;
    public Rigidbody Rb { get { return (rb == null) ? rb = GetComponent<Rigidbody>() : rb; } }
    void Start()
    {
        gm = EventManager.getGameManager.Invoke();
        gm.objectFriend.Add(gameObject);
    }
    private void Update()
    {
        if (HandleObject.transform.childCount > 0)
        {
            HandleObjectİsNull = true;
        }
        else
        {
            HandleObjectİsNull = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ICollectable collectableObject = collision.gameObject.GetComponent<ICollectable>();
        DemageObje demage = collision.gameObject.GetComponent<DemageObje>();
        if (collectableObject != null&&HandleObjectİsNull==false&&demage.Attack==false)
        {
            collectableObject.collect(false, HandleObject);
          
        }

    }

    public void doAttack()
    {
        if (HandleObjectİsNull == true&&HandleObject.transform.childCount>0)
        {

            characterAnim.AnimationPlayTriger("Attack");
          
        }
    }


    public void Damage()
    {
        int random = Random.Range(5, 25);
        can -= random;
    }

    public void hit()
    {
        Rb.velocity = Vector3.forward * -2f;
        Damage();
    }
}
