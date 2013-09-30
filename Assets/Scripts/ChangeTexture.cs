using UnityEngine;
using System.Collections;

public class ChangeTexture : MonoBehaviour {
 
    public Material finishedMaterial;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.parent.animation["grow"].time == this.transform.parent.animation["grow"].length)
        {
            renderer.material = finishedMaterial;
        }
	}
}
