using UnityEngine;
using UnityEditor;

static class CharacterUnityIntegration {

	[MenuItem("Assets/Create/Character Asset")]
	public static void CreateYourScriptableObject() {
		ScriptableObjectUtility2.CreateAsset<CharacterAsset>();
	}

}
