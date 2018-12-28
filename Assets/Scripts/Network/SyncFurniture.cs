using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SyncFurniture : NetworkBehaviour {

    [SyncVar]
    private Quaternion rotation;
    [SyncVar]
    private Vector3 position;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(transform.position);
        if(hasAuthority){
            transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Debug.Log("system ready to cmd sync");
            CmdSyncTransform(transform.rotation,transform.position);
        }
        transform.rotation = rotation;
        transform.position = position;
	}
    [Command]
    void CmdSyncTransform(Quaternion r, Vector3 p){
        Debug.Log(GetComponent<NetworkIdentity>().netId);
        rotation = r;
        position = p;
    }
}
