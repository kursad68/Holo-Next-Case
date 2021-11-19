using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemageObje : MonoBehaviour,ICollectable,IJettisonable
{
    private GameManager Gm;
  public  bool HaveTheObject;
   public bool Attack;
    private Rigidbody rb;
    public Rigidbody Rb { get { return (rb == null) ? rb = GetComponent<Rigidbody>() : rb; } }
    private void Start()
    {
        Gm = EventManager.getGameManager.Invoke();
    }
    private void Update()
    {
        transform.position= transform.position = new Vector3(Mathf.Clamp(transform.position.x, -40f, 40f), transform.position.y, Mathf.Clamp(transform.position.z, -40f, 40f));
    }
    public void collect(bool isCollectable, GameObject sourceObject)
    {
        if (HaveTheObject==false&&isCollectable==false) {
            gameObject.transform.position = sourceObject.transform.position;
            gameObject.transform.SetParent(sourceObject.transform);
            Rb.isKinematic = true;
            HaveTheObject = true;
        }
        
    }

    public void Throwing(Vector3 distance)
    {
        Attack = true;
        Rb.isKinematic = false;
        
        Rb.velocity = new Vector3(distance.x,distance.y+0.5f,distance.z)*3;
       
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamage damage = collision.gameObject.GetComponent<IDamage>();
        if (damage != null && Attack == true)
        {
            damage.hit();
           
        }
        if (collision.gameObject.layer == 8)
        {
            Attack = false;
            HaveTheObject = false;
            transform.SetParent(Gm.Rocks.transform);
        }
    }
}
