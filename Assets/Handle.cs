using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Handle : MonoBehaviour {
	public Transform target;
    GameObject parent;


    void Start () {
        parent = transform.parent.gameObject;
        parent.animation["grow"].speed = 0;
	}
		
    // Update is called once per frame
	void Update () {

        transform.position = target.position;
    }

    void OnMouseDown()
    {

        parent.animation["grow"].time = parent.animation["grow"].length;
        parent.animation["grow"].speed = 0;
    } 

}

