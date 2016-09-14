using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NPCSpawner : NetworkBehaviour {

	public GameObject npcPrefab;
	public int npcCount;

	public override void OnStartServer ()
	{
		for(int i = 0; i < npcCount; i++)
		{
			Vector3 spawnPosition = new Vector3 (Random.Range(-8f,8f),0f, Random.Range(-8f,8f));
			Quaternion spawnRotation = Quaternion.Euler(0f, Random.Range(0,180f), 0f);

			GameObject npc = (GameObject) Instantiate(npcPrefab,spawnPosition, spawnRotation);
			NetworkServer.Spawn(npc);
		}
	}

}
