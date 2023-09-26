//using UnityEngine.System.Collections;
//using UnityEngine.System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController2 : MonoBehaviour
{
    public float lookRadius = 10f;
    Animator anim;
    int attack;
    int attackOut;
            
    Transform target;
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        attack = Animator.StringToHash("attack");
        attackOut = Animator.StringToHash("attackOut");
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            anim.SetTrigger(attack);
            agent.SetDestination(target.position);            
        }
        if (distance > lookRadius)
        {
            anim.SetTrigger(attackOut);
        }
    }
  
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
