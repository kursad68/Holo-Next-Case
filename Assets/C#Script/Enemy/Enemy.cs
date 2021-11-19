using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamage
{
    [SerializeField]
    private GameObject HandleObject;
    public bool HandleObjectİsNull,RocksİsFlying=true;
    GameManager gameManager;
   
    private int Health,TryAgain;
    private Rigidbody rb;
    public Rigidbody Rb { get { return (rb == null) ? rb = GetComponent<Rigidbody>() : rb; } }
    void Start()
    {
        Health = 100;
        TryAgain = 10;
        gameManager = EventManager.getGameManager.Invoke();
        Debug.Log(gameManager.name);
        gameManager.objectEnemy.Add(gameObject);
    }
    private void OnDisable()
    {
        gameManager.objectEnemy.Remove(gameObject);
    }
    private void OnDestroy()
    {
        gameManager.objectEnemy.Remove(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ICollectable collectableObject = collision.gameObject.GetComponent<ICollectable>();
        if (collectableObject != null && HandleObjectİsNull == false&&RocksİsFlying==true)
        {
            collectableObject.collect(false, HandleObject);
            HandleObjectİsNull = true;
            StartCoroutine(WaitForAddHandle());
        }

    }
 
    IEnumerator WaitForAddHandle()
    {
        yield return new WaitForSeconds(0.2f);
        HandleObjectİsNull = false;
    }
    IEnumerator WaitForAddRocks()
    {
        yield return new WaitForSeconds(0.5f);
       RocksİsFlying = true;
    }
    private void TryAgainFunc()
    {
        TryAgain--;
        if (TryAgain <= 0)
        {
            Destroy(gameObject);
        }
        Health = 100;
        int randomx = Random.Range(5, 45);
        
        int randomz = Random.Range(5, 45);
        transform.position = new Vector3(randomx, transform.position.y, randomz);
      
        
    }
    public void Damage()
    {
        int random = Random.Range(5, 25);
        Health -= random;
        if (Health <= 0)
        {
            TryAgainFunc();
        }
        RocksİsFlying = false;
        StartCoroutine(WaitForAddRocks());
    }

    public void hit()
    {
        Rb.velocity = Vector3.forward * -2f;
        Damage();
    }
}
