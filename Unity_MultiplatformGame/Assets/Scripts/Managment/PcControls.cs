using UnityEngine;

public class PcControls : PlayerManager, IControls {
	public void Update() {
		Movement(0);
		Shoot();
		Connect();
	}

	public override void Movement(float _direction) {
		if(Input.GetButton("Horizontal")) {
			_direction = Input.GetAxis("Horizontal");

			base.Movement(_direction);
		}
	}

	public override void Shoot() {
		if(Input.GetKeyDown(KeyCode.Space)) {
			base.Shoot();
		}
	}

	public override void Connect() {
		if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
			base.Connect();
		}
	}
}
