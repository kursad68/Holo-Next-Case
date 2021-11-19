using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetected : MonoBehaviour
{
    [SerializeField]
    private EnemyMove enemyMove;
    List<Transform> RocksTransform = new List<Transform>();
    [SerializeField]
    private GameObject Rocks;
    private void Start()
    {
        for (int i = 0; i < Rocks.transform.childCount; i++)
        {
            RocksTransform.Add(Rocks.transform.GetChild(i).gameObject.transform);
            enemyMove.GetRockObje(Rocks.transform.GetChild(i).gameObject.transform);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Frienly>()|| other.gameObject.GetComponent<CharacterProgress>())
        {
            enemyMove.friendTriger = true;
            enemyMove.NewFriendlyObject(other.gameObject);
        }

        ICollectable ıc = other.gameObject.GetComponent<ICollectable>();
        if (ıc != null)
        {
            if (!RocksTransform.Contains(other.transform))
            {
            
               // enemyMove.GetRockObje(other.transform);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Frienly>() || other.gameObject.GetComponent<CharacterProgress>())
        {
            enemyMove.friendTriger = false;
           
        }
   
    }

}
