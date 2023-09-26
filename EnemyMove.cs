using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public GameObject thisEnemy;
    private bool outlineOn = false;
    private NavMeshAgent nav;
    private Animator anim;
    private AnimatorStateInfo enemyInfo;
    private float x;
    private float z;
    private float velocitySpeed;
    public GameObject player;
    private float distance;
    private bool isAttacking = false;
    public float attackRange = 2.0f;
    private float runRange = 50.0f;
    public int enemyHealth = 100;
    private int currentHealth;
    private bool isAlive = true;
    private AudioSource audioPlayer;
    public Image healthBar;
    private float fillHealth;
    public GameObject mainCam;
    public float rotateSpeed = 50.0f;
    public GameObject coins;

    public bool hit;

    public bool death;

    // Start is called before the first frame update
    void Start()
    {
        thisEnemy.GetComponent<Outline>().enabled = false;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nav.avoidancePriority = Random.Range(5, 75);
        currentHealth = enemyHealth;
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCam == null)
        {
            mainCam = GameObject.Find("Main Camera");
        }
        healthBar.transform.LookAt(mainCam.transform.position);
        if (isAlive == true)
        {
            if (outlineOn == false)
            {
                outlineOn = true;
                if (SaveScript.theTarget == thisEnemy)
                {
                    thisEnemy.GetComponent<Outline>().enabled = true;
                }
            }
            if (outlineOn == true)
            {
                if (SaveScript.theTarget != thisEnemy)
                {
                    thisEnemy.GetComponent<Outline>().enabled = false;
                    outlineOn = false;
                }
            }
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            x = nav.velocity.x;
            z = nav.velocity.z;
            velocitySpeed = x + z;
    
            if (velocitySpeed == 0)
            {
                anim.SetBool("running", false);
            }
            else
            {
                anim.SetBool("running", true);
                isAttacking = false;
            }

            enemyInfo = anim.GetCurrentAnimatorStateInfo(0);

            distance = Vector3.Distance(transform.position,player.transform.position);
        
            if (distance < attackRange || distance > runRange)
            {
                nav.isStopped = true;
                if(distance > runRange)
                {
                    SaveScript.enemiesOnScreen--;
                    Destroy(gameObject);
                }
                if (distance < attackRange && enemyInfo.IsTag("nonAttack") && !anim.IsInTransition(0))
                {
                    if (isAttacking == false)
                    {
                        isAttacking = true;
                        anim.SetTrigger("attack");
                        Vector3 Pos = (player.transform.position - transform.position).normalized;
                        Quaternion PosRotation = Quaternion.LookRotation(new Vector3(Pos.x, 0, Pos.z));
                        transform.rotation = Quaternion.Slerp (transform.rotation, PosRotation, Time.deltaTime * rotateSpeed);
                    }
                }
                if (distance < attackRange && enemyInfo.IsTag("attack"))
                {
                    if (isAttacking == true)
                    {  
                        isAttacking = false;
                    }
                }    
            }
            else if (distance > attackRange && enemyInfo.IsTag("nonAttack") && !anim.IsInTransition(0))
            {
                if (SaveScript.invisible == false)
                {
                    nav.isStopped = false;
                    nav.destination = player.transform.position;
                }
            }
            if(currentHealth > enemyHealth)
            {
                anim.SetTrigger("hit");
                currentHealth = enemyHealth;
                audioPlayer.Play();
                fillHealth = enemyHealth;
                fillHealth /= 100.0f;
                healthBar.fillAmount = fillHealth;
            }
        }
        if(enemyHealth <= 1 && isAlive == true)
        {
            isAlive = false;
            nav.isStopped = true;
            anim.SetTrigger("death");
            SaveScript.enemiesOnScreen--;
            thisEnemy.GetComponent<Outline>().enabled = false;
            outlineOn = false;
            nav.avoidancePriority = 1;
            StartCoroutine(IsDead());
        }
    }

    IEnumerator IsDead()
    {
        yield return new WaitForSeconds(1);
        Instantiate(coins, transform.position, transform.rotation);
        SaveScript.killAmt++;
        Destroy(gameObject, 0.2f);
    }
}