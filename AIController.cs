using UnityEngine;
using UnityEngine.UI;
public class AIController : MonoBehaviour
{
    //public UnityEngine.AI.NavMeshAgent agent;
    public Transform Player;

    int MoveSpeed = 1;
    int MaxDist = 1;
    int MinDist = 1;

    void Update()
    {
        transform.LookAt(Player);
 
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
 
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
 
 
 
            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
                //Debug.Log ("you dead");
            }
 
        }
    }
}   
    