

///////////////////////////////////////


//            first PlayerMove.cs


///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    private Ray ray;
    private RaycastHit hit;
    private float x;
    private float z;
    private float velocitySpeed;
 
    CinemachineTransposer ct;
    public CinemachineVirtualCamera playerCam;
    private Vector3 pos;
    private Vector3 currPos;
    public static bool canMove = true;
    public static bool moving = false;
    public LayerMask moveLayer;
    //public GameObject freeCam;
    //public GameObject staticCam;
    //private bool freeCamActive = true;
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>();
        currPos = ct.m_FollowOffset;
        //freeCam.SetActive(true);
        //staticCam.SetActive(false);
        SaveScript.spawnPoint = spawnPoint;
    }
 // Update is called once per frame
    void Update()
    {
 //Calculate velocity speed
        x = nav.velocity.x;
        z = nav.velocity.z;
        velocitySpeed = x + z;
 //Get mouse position
        pos = Input.mousePosition;
        ct.m_FollowOffset = currPos;
        if (Input.GetMouseButtonDown(0)) //&& playerInfo.IsTag("nonAttack") && ! anim.IsInTransition(0))
        {
            
            if (canMove == true)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 300, moveLayer))
                {                    
                    if(hit.transform.gameObject.CompareTag("enemy"))
                    {
                        nav.isStopped = false;
                        SaveScript.theTarget = hit.transform.gameObject;
                        nav.destination = hit.point;
                        transform.LookAt(SaveScript.theTarget.transform);
                        //StartCoroutine(MoveTo());
                    }
                    else
                    {
                        SaveScript.theTarget = null;
                        nav.destination = hit.point;
                        nav.isStopped = false;
                    } 
                }
            }
        }
        if(velocitySpeed != 0)
        {
            anim.SetBool("sprinting", true);
            moving = true;
        }
        if (velocitySpeed == 0)
        {
            anim.SetBool("sprinting", false);
            moving = false;
        }
        /*if(Input.GetMouseButton(1))
        {
            
            if (pos.x != 0 || pos.y != 0)
            {
                currPos = pos / 32;
            }
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(freeCamActive == true)
            {
                freeCam.SetActive(false);
                staticCam.SetActive(true);
                freeCamActive = false;
            }
            else if (freeCamActive == false)
            {
                freeCam.SetActive(true);
                staticCam.SetActive(false);
                freeCamActive = true;
            }
        }*/
    }
}