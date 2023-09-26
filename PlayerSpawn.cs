using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSpawn : MonoBehaviour
{
    public GameObject[] Characters;
    public Transform spawnPoint;
    
 // Start is called before the first frame update
    void Start()
    {
        Instantiate(Characters[SaveScript.pchar], spawnPoint.position, spawnPoint.rotation);
    }
}