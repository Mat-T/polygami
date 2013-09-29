using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Handle : MonoBehaviour {
	public Transform target;
    GameObject mesh;
    bool dragging = false;
    int speed = 1;
    float animTime = 0;
    public Material finishedMaterial;


    void Start () {
        parent = transform.parent.gameObject;
        parent.animation["grow"].speed = 0;
	}
		
    // Update is called once per frame
	void Update () {
        if (dragging == true)
        {
            animTime += Input.GetAxis("Mouse X") * speed;
            Debug.Log(animTime);
            Debug.Log(Input.GetAxis("Vertical"));
        }

        if (animTime > this.transform.parent.animation["grow"].length)
        {

        }
        this.transform.parent.animation["grow"].time = animTime;
        this.transform.parent.animation["grow"].speed = 0;

        if (this.transform.parent.animation["grow"].time == this.transform.parent.animation["grow"].length)
        {
            mesh.renderer.material = finishedMaterial;
        }

        transform.position = target.position;
    }

    void OnMouseDown()
    {
        dragging = true;
        
    }

    void OnMouseUp()
    {
        dragging = false;
    }
}

