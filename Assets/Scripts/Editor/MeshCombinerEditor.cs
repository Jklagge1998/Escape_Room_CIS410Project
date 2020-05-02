using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MeshCombiner))]
public class MeshCombinerEditor : Editor
{
    /*
     Notes:
        * This class creates a GUI interface for MeshCombinerEditor, making it easier for users in the editor to combine meshes.
        * The if statement does give two compiler warnings, but they work find.
        * Currently looking into commands that will replace the obselete commands but the program does work as intended.
     */
    private void OnSceneGUI()
    {
        MeshCombiner mc = target as MeshCombiner;

        if (Handles.Button(mc.transform.position + Vector3.up * 5, Quaternion.LookRotation(Vector3.up), 1, 1, Handles.CylinderCap))
        {
            mc.CombineMeshes();
        }
    }
}
