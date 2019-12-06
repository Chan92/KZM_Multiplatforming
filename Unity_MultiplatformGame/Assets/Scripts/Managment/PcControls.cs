using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcControls : PlayerManager, IControls {
	public void Update() {
		Movement();
		Shoot();
		Connect();
	}

	public override void Movement() {
		if(Input.GetKeyDown(KeyCode.Space)) {
			print("not working");
			base.Movement();
		}
	}

	public override void Shoot() {
		throw new System.NotImplementedException();
	}

	public override void Connect() {
		throw new System.NotImplementedException();
	}
}
