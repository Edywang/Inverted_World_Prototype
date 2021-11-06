using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/**
SOURCE: https://www.patreon.com/posts/37702209
https://gist.github.com/khadzhynov/933134bac5bcb747c4ecd31f815c72a6
**/
[CustomEditor(typeof(NavMeshSphere))]
public class NavMeshSphereEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Load navmesh data"))
        {
            (target as NavMeshSphere).LoadNavmeshData();
        }

        if (GUILayout.Button("remove navmesh data"))
        {
            (target as NavMeshSphere).RemoveAllNavMeshLoadedData();
        }
    }
}