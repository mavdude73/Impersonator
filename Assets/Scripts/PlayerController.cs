﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	void Update ()
	{
		if(!isLocalPlayer)
		{
			return;
		}
	
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0,x,0);
		transform.Translate(0,0,z);

		if(Input.GetButtonDown("Fire1"))
		{
			CmdFire();
		}
	
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.green;

	}

	[Command]
	void CmdFire()
	{
		GameObject bullet = (GameObject) Instantiate(bulletPrefab, bulletSpawn.position,bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;

		NetworkServer.Spawn(bullet);

		Destroy(bullet, 2.0f);
	}

}
