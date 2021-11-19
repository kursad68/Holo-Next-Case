using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frienly : MonoBehaviour,IDamage
{
    [SerializeField]
    private GameObject HandleObject;
    public bool HandleObjectİsNull, RocksİsFlying = true;
    GameManager gameManager;
    private int Health;
    private Rigidbody rb;
    public Rigidbody Rb { get { return (rb == null) ? rb = GetComponent<Rigidbody>() : rb; } }
    void Start()
    {
        Health = 100;
        gameManager = EventManager.getGameManager.Invoke();
        Debug.Log(gameManager.name);
        gameManager.objectFriend.Add(gameObject);

    }

    private void OnDisable()
    {
        gameManager.objectFriend.Remove(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        ICollectable collectableObject = collision.gameObject.GetComponent<ICollectable>();
        if (collectableObject != null && HandleObjectİsNull == false && RocksİsFlying == true)
        {
            collectableObject.collect(false, HandleObject);
            HandleObjectİsNull = true;
            StartCoroutine(WaitForAddHandle());
        }

    }

    IEnumerator WaitForAddHandle()
    {
        yield return new WaitForSeconds(0.5f);
        HandleObjectİsNull = false;
    }

    IEnumerator WaitForAddRocks()
    {
        yield return new WaitForSeconds(0.5f);
        RocksİsFlying = true;
    }
    public void Damage()
    {
        int random = Random.Range(5, 25);
        Health -= random;
        RocksİsFlying = false;
        StartCoroutine(WaitForAddRocks());
    }

    public void hit()
    {
        Rb.velocity = Vector3.forward * -2f;
        Damage();
    }
}
