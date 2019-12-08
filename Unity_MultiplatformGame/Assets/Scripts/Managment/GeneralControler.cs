using UnityEngine;

public class GeneralControler : MonoBehaviour {
	[SerializeField]
	private GameObject playerWorldA, playerWorldB;
	public static int buildId;

	void Awake() {
	#if UNITY_STANDALONE
		buildId = 1;
		playerWorldA.AddComponent<PcControls>();
	#elif UNITY_WEBGL
		buildId = 2;
		#if WEB_ANDROID
			playerWorldB.AddComponent<MoboWebControls>();
		#else
			playerWorldB.AddComponent<WebControls>();
		#endif//WEBGL platform type
	#else
			throw new System.NotImplementedException("There are no controls for this build.");
	#endif //Build check
	}
}