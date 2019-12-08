using System.Collections;
using UnityEngine;

public class WebControls : PlayerManager, IControls {
	private int clickCounter;
	private const int clicksToShoot = 2;
	private float resetCounterTime = 2f;

	public void Update() {
		Movement(0);
		Shoot();
		Connect();
	}

	public override void Movement(float _direction) {
		if(Input.GetKey(KeyCode.Mouse0)) {
			Vector2 _mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			Ray _ray = Camera.main.ScreenPointToRay(_mousePos);
			RaycastHit _hit;

			if(Physics.Raycast(_ray, out _hit, 10f)) {
				if(_hit.point.x < transform.position.x) {
					_direction = -1;
				} else {
					_direction = 1;
				}

				_direction *= Mathf.Abs(_hit.point.x - transform.position.x);
			}

			base.Movement(_direction/10);
		}
	}

	public override void Shoot() {
		if(Input.GetKeyUp(KeyCode.Mouse0)) {
			clickCounter++;

			if(clickCounter == clicksToShoot) {
				base.Shoot();
				clickCounter = 0;
			}

			StartCoroutine(ClickTimer());
		}
	}

	public override void Connect() {
		if(Input.GetKeyUp(KeyCode.Mouse1)) {
			base.Connect();
		}
	}

	private IEnumerator ClickTimer() {
		yield return new WaitForSeconds(resetCounterTime);
		clickCounter = 0;
	}
}
