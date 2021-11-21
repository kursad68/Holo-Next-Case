using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDetection : MonoBehaviour
{
    public bool isFirstTriger;
    private CharacterProgress characterProgress;
    [SerializeField]
    private Movement movement;
    void Start()
    {
        characterProgress = GetComponentInParent<CharacterProgress>();
        Debug.Log(characterProgress.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            StartCoroutine(WaitForAttack());
           if(isFirstTriger == false && other.gameObject!=null) 
            {
                movement.EnemyTrigerStay(other.gameObject);
                isFirstTriger = true;
            }
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            isFirstTriger = false;
            movement.EnemyTrigerExit();
        }
    }
    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(0.01f);
        characterProgress.doAttack();
       

    }
}
