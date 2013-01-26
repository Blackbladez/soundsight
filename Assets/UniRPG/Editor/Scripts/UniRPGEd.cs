// ====================================================================================================================
// -== UniRPG ==-
// by Leslie Young
// www.plyoung.com
// ====================================================================================================================

using UnityEngine;
using UnityEditor;

public class UniRPGEd : UniRPGEditor.UniRPGEditorBase
{

	// ================================================================================================================
	#region menu items
		
	[MenuItem("UniRPG/Controllers/Player", false, 20)]
	public static void AddController_Player()
	{
		//if (Selection.gameObjects.Length > 0)
		//{
		//	Undo.RegisterSceneUndo("Add TilePiece Component");
		//	foreach (GameObject go in Selection.gameObjects)
		//	{
		//		go.AddComponent<>();
		//	}
		//}
	}

	[MenuItem("UniRPG/Controllers/NPC or Monster", false, 20)]
	public static void AddController_NPC()
	{
		//if (Selection.gameObjects.Length > 0)
		//{
		//	Undo.RegisterSceneUndo("Add TilePiece Component");
		//	foreach (GameObject go in Selection.gameObjects)
		//	{
		//		go.AddComponent<>();
		//	}
		//}
	}
		
	#endregion
	// ================================================================================================================
}
