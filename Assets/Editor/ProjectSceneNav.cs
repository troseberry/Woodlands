using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ProjectSceneNav : MonoBehaviour 
{

	[MenuItem("Game/Scenes/MainMenu")]
	static void MainMenuLoad()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
	}

	[MenuItem("Game/Scenes/Homestead")]
	static void HomesteadLoad()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/Homestead.unity");
	}

	[MenuItem("Game/Scenes/MainCabin")]
	static void MainCabinLoad()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/MainCabin.unity");
	}

	[MenuItem("Game/Scenes/Workshop")]
	static void WorkshopLoad()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/Workshop.unity");
	}

	[MenuItem("Game/Scenes/Forest")]
	static void ForestLoad()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/Forest.unity");
	}

	[MenuItem("Game/Scenes/LumberYard")]
	static void LumberYardLoad()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/LumberYard.unity");
	}

	[MenuItem("Game/Scenes/Testing")]
	static void TestingLoad()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/Testing.unity");
	}
}