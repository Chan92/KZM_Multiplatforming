using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebControls : PlayerManager, IControls {
	public void Update() {
		Movement();
		Shoot();
		Connect();
	}

	public override void Movement() {
		throw new System.NotImplementedException();
	}

	public override void Shoot() {
		throw new System.NotImplementedException();
	}

	public override void Connect() {
		throw new System.NotImplementedException();
	}
}
