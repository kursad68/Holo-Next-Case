using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Rocks;
    public List<GameObject> objectFriend;
    public List<GameObject> objectEnemy;
    private void OnEnable()
    {
        EventManager.getGameManager += gm;
    }
    private void OnDisable()
    {

        EventManager.getGameManager -= gm;
    }

    GameManager gm()
    {
        return GetComponent<GameManager>();
    }

  
}
