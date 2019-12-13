using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour{
	public Transform[] playerList;
	private Transform player;
	private float followOfset = 35f;

    void Start(){
		if(GeneralControler.buildId == 1) {
			player = playerList[0];
		} else {
			player = playerList[1];
		}
    }

    void Update(){
		if(player.position.x < -followOfset || player.position.x > followOfset) {
			if(transform.parent != null) {
				transform.parent = null;
			}
		} else {
			if(transform.parent == null) {
				transform.parent = player;
				transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
			}
		}
    }
}
