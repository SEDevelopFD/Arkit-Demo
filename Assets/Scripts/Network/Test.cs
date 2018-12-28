using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    [SerializeField]
    private GameObject target;
	// Use this for initialization
	void Start () {
        GameObject.Instantiate(target);
	}
	
	
}
