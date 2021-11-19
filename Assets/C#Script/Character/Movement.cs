using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Camera maincamera;
    [SerializeField]
    private float speed;
    [SerializeField]
    private LayerMask layer;
    private bool isEnemyTriger,attackonline;
    public GameObject EnemyObject;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GoToMousePoint();
        
    }
    public void EnemyTrigerStay(GameObject enemy)
    {
        EnemyObject = enemy;
        isEnemyTriger = true;
    }
    public void EnemyTrigerExit()
    {
        isEnemyTriger = false;
    
    }
    public void attackOnline()
    {
        attackonline = true;
    }
    public void attackDisable()
    {
        attackonline = false;
    }

    public void GoToMousePoint()
    {
        if (attackonline == true)
        {
            transform.LookAt(new Vector3(EnemyObject.transform.position.x-1f,0.5f,EnemyObject.transform.position.z));
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit,100f,layer))
            {

                if (attackonline == false)
                {
                    transform.LookAt(new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z));
                    transform.position += transform.forward * Time.deltaTime * speed;
                }
                else if (attackonline == true)
                {
                    transform.LookAt(EnemyObject.transform.position);
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z), speed * Time.deltaTime);
                }
                EventManager.onAnimationPlay.Invoke("Move");
            }
            else
            {
                EventManager.onAnimationPlay.Invoke("Idle");
            }

        }
        else
        {
            EventManager.onAnimationPlay.Invoke("Idle");
        }

    }
  
}
