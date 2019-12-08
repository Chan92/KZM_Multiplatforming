using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle : MonoBehaviour{
	[SerializeField]
	private int[] levelOrderA, levelOrderB;
	private int[] currentOrderA, currentOrderB;
	private int portalNumber;
	public GameObject winscreen;
	public Transform resetPosA, resetPosB;
	public Transform playerA, playerB;

	public static Puzzle Instance {
		get;
		private set;
	}

	private void Awake() {
		if(Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	void Start(){
		winscreen.SetActive(false);
		currentOrderA = new int[4];
		currentOrderB = new int[4];
	}

	public void HitBlock(GameObject _block) {
		_block.SetActive(false);
	}

	public void HitPortal(Transform _portal) {
		if(GeneralControler.buildId == 1) {
			currentOrderA[portalNumber] = _portal.GetComponent<PortalId>().id;
		} else if(GeneralControler.buildId == 2) {
			currentOrderB[portalNumber] = _portal.GetComponent<PortalId>().id;
		}
		
		portalNumber++;
		CheckOrder();
	}

	private void CheckOrder() {
		switch(GeneralControler.buildId) {
			case 1:
				if(currentOrderA[3] == levelOrderA[3]) {
					LevelComplete();
				} else if(currentOrderA[portalNumber -1] == levelOrderA[portalNumber -1]) {
				} else {
					currentOrderA = new int[4];
					portalNumber = 0;
					playerA.position = resetPosA.position;
				}
				break;
			case 2:
				if(currentOrderB[3] == levelOrderB[3]) {
					LevelComplete();
				} else if(currentOrderB[portalNumber -1] == levelOrderB[portalNumber -1]) {

				} else {
					currentOrderB = new int[4];
					portalNumber = 0;
					playerB.position = resetPosB.position;
				}
				break;
		}
	}

	private void LevelComplete() {
		winscreen.SetActive(true);
	}

	public void RestartGame() {
		winscreen.SetActive(false);
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
		Resources.UnloadUnusedAssets();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
	}
}
