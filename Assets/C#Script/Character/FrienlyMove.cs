using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrienlyMove : MonoBehaviour
{

    [SerializeField]
    private FrienlyAnim frienlyAnim;
    [SerializeField]
    private GameObject HandleObject;
    public GameObject EnemyGameObject;
    private GameManager gm;
    public bool enemyTriger, isHandle, AttackOnline;
    List<Transform> RocksTransform = new List<Transform>();
    private float closestRock = 100f;
    private Transform TempRock;
    [SerializeField]
    private GameObject Rocks;
    private void Start()
    {
        StartCoroutine(waitForSource());
        for (int i = 0; i < Rocks.transform.childCount; i++)
        {
            RocksTransform.Add(Rocks.transform.GetChild(i).gameObject.transform);

        }
    }

    IEnumerator waitForSource()
    {
        enemyTriger = true;
        yield return new WaitForSeconds(1f);
        gm = EventManager.getGameManager.Invoke();
        EnemyGameObject = gm.objectEnemy[0];
        enemyTriger = false;
        StopAllCoroutines();
    }
    public void NewFriendlyObject(GameObject g)
    {
        StartCoroutine(enumerator());
        EnemyGameObject = g;
    }
    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(0.5f);
    }
    public void GetRockObje(Transform t)
    {
        RocksTransform.Add(t);
    }
    public void DestroyRockObje(Transform t)
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (HandleObject.transform.childCount > 0)
        {
            isHandle = true;
            AttackOnline = true;
        }
        if (AttackOnline == true)
        {
            transform.LookAt(EnemyGameObject.transform.position);
            frienlyAnim.AnimationPlayTriger("Attack");

        }
        else if (AttackOnline == false)
        {
            isHandle = false;

            closestRock = 100f;
            RocksList();
        }

        if (isHandle == true)
        {

            if (enemyTriger == false && AttackOnline == false)
            {
                GotoFriend();
            }
            else if (enemyTriger == true && HandleObject.transform.childCount > 0)
            {

                frienlyAnim.AnimationPlayTriger("Attack");
                isHandle = false;


            }
        }
        else
        if (isHandle == false)
        {
            GotoRock();
        }
    }
    private void GotoFriend()
    {
        transform.LookAt(EnemyGameObject.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, EnemyGameObject.transform.position, 3f * Time.deltaTime);
        frienlyAnim.AnimationPlayTriger("Move");
        StopAllCoroutines();
    }
    private void GotoRock()
    {
        transform.LookAt(new Vector3(TempRock.position.x, transform.position.y, TempRock.position.z));
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(TempRock.position.x, transform.position.y, TempRock.position.z), 3f * Time.deltaTime);
        frienlyAnim.AnimationPlayTriger("Move");
    }
    private void RocksList()
    {
        foreach (var rock in RocksTransform)
        {
            if (Vector3.Distance(transform.position, rock.position) < closestRock)
            {
                closestRock = Vector3.Distance(transform.position, rock.position);
                TempRock = rock;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        DemageObje demage = collision.gameObject.GetComponent<DemageObje>();
        if (demage != null && isHandle == false && demage.Attack == false)
        {


            isHandle = true;
        }
    }
}
