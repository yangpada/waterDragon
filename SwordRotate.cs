using UnityEngine;
using System.Collections;

public class SwordRotate : MonoBehaviour
{	
	void Start(){
		iTween.RotateBy(gameObject, iTween.Hash("y", .25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .4));
	}
}

