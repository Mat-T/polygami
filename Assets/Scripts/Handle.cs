using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Handle : MonoBehaviour {
    StateManager stateManager;
	public Transform target;
    public GameObject mesh;
    bool dragging = false;
    float speed = 0.3f;
    float animTime = 0;
    public Material finishedMaterial;
    bool locked = false;


    void Start () {
        stateManager = GameObject.Find("goStateManager").GetComponent("StateManager") as StateManager;
        this.transform.parent.animation["grow"].speed = 0;
	}
		
    // Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            stopDrag();
        }


        if (dragging && !locked)
        {   
           
            animTime += Input.GetAxis("Mouse Y") + Input.GetAxis("Mouse X") * speed;
            if (animTime <= 0)
            {
                animTime = 0;
            }
            if (animTime >= this.transform.parent.animation["grow"].length)
            {
                animTime = this.transform.parent.animation["grow"].length;
                renderer.enabled = false;
            }
            
        }

        if (animTime >= this.transform.parent.animation["grow"].length)
        {
            mesh.renderer.material = finishedMaterial;
            locked = true;
        }
        this.transform.parent.animation["grow"].time = animTime;
        this.transform.parent.animation["grow"].speed = 0;

        transform.position = target.position;
    }

    void OnMouseDown()
    {
            startDrag();
        
        
    }

    void startDrag()
    {
        dragging = true;
        stateManager.lockCamera = true;
    }

    void stopDrag()
    {
        dragging = false;
        stateManager.lockCamera = false;
    }

}

