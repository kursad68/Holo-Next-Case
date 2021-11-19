using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrienlyDetected : MonoBehaviour
{

    [SerializeField]
    private FrienlyMove freinlyMove;
    List<Transform> RocksTransform = new List<Transform>();
    [SerializeField]
    private GameObject Rocks;
    private void Start()
    {
        for (int i = 0; i < Rocks.transform.childCount; i++)
        {
            RocksTransform.Add(Rocks.transform.GetChild(i).gameObject.transform);
            freinlyMove.GetRockObje(Rocks.transform.GetChild(i).gameObject.transform);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            freinlyMove.enemyTriger = true;
            freinlyMove.NewFriendlyObject(other.gameObject);
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
        if (other.gameObject.GetComponent<Enemy>() )
        {
            freinlyMove.enemyTriger = false;

        }

    }
}
