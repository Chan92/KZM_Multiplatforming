using UnityEngine;

public class MoboWebControls : PlayerManager, IControls {
	public void Update() {
		Movement(0);
		Shoot();
		Connect();
	}

	public override void Movement(float _direction) {
		throw new System.NotImplementedException();
	}

	public override void Shoot() {
		throw new System.NotImplementedException();
	}

	public override void Connect() {
		throw new System.NotImplementedException();
	}
}
