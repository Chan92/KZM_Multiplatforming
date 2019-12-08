using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IControls {
	private float movespeed = 10f;
	private Vector3 scale;

	private void Start() {
		scale = transform.localScale;
	}

	public virtual void Movement(float _direction) {
		//makes the player face the way of the direction
		if(_direction < 0) {
			transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
		} else if(_direction > 0) {
			transform.localScale = new Vector3(scale.x, scale.y, scale.z);
		}

		//moves the player
		transform.Translate(_direction * movespeed  * Time.deltaTime, 0, 0);
	}

	public virtual void Shoot() {
		RaycastHit _hit;

		if(Physics.Raycast(transform.position, Vector3.right, out _hit, 2.5f)) {
			if(_hit.transform.tag == "Block") {
				Puzzle.Instance.HitBlock(_hit.transform.gameObject);
			}
		}
	}

	public virtual void Connect() {
		RaycastHit _hit;
		Vector3 _offset = Vector3.zero;
		Vector3 direction = Vector3.up;

		if(GeneralControler.buildId == 1) {
			_offset = new Vector3(0, 3, 0);
			direction = Vector3.down;
		} else if(GeneralControler.buildId == 2) {
			_offset = new Vector3(0, -3, 0);
			direction = Vector3.up;
		}
	 
		if(Physics.Raycast(transform.position + _offset, direction, out _hit, 5f)) {
			if(_hit.transform.tag == "Portal") {
				Puzzle.Instance.HitPortal(_hit.transform);
			}
		}
	}
}
