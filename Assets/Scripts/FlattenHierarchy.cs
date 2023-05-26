//using UnityEditor;
//using UnityEngine;

//public class FlattenHierarchy : EditorWindow
//{
//    [MenuItem("Window/Flatten Hierarchy")]
//    public static void ShowWindow()
//    {
//        EditorWindow.GetWindow(typeof(FlattenHierarchy));
//    }

//    private void OnGUI()
//    {
//        GUILayout.Label("Flatten Hierarchy", EditorStyles.boldLabel);
//        if (GUILayout.Button("Flatten"))
//        {
//            Flatten();
//        }
//    }

//    private void Flatten()
//    {
//        GameObject[] selectedObjects = Selection.gameObjects;

//        foreach (GameObject selectedObject in selectedObjects)
//        {
//            Transform[] childTransforms = selectedObject.GetComponentsInChildren<Transform>(true);

//            foreach (Transform childTransform in childTransforms)
//            {
//                if (childTransform != selectedObject.transform)
//                {
//                    childTransform.parent = selectedObject.transform.root;
//                }
//            }
//        }
//    }
//}
