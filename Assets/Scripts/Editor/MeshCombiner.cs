using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    /*Notes:
        * This class takes an object and combines all of its meshes into one.
        * This can be used for better rendering and enables the highlight system
          to highlight the entirety of selectable objects.
        * How to use:
          Steps
            1) Create an empty object in the scene
                - Add a mesh render and mesh filter components to the empty object
            2) Attach this script to the empty object.
            3) Move the object you wish to combine meshes into the empty object.
            4) click the empty object and look into the scene editor (this is made possible by a GUI made in MeshCombinerEditor.cs).
               A white cylinder should appear about 5 units above the object you wish to combine meshes together.
            5) click this cylinder and the mesh filter of the empty object will be populated with a mesh made up
               of all its children meshes (all meshes put together to make one mesh). The children meshes will be disabled
               making the object easier to render.
        * Further notes:
          * The method CombineMeshes will work as intended for one material texture objects.
          * Additional work will be required if we want to perserve multiple texture (material) 
            objects when combining meshes.
    */

    public void CombineMeshes()
    {
        Quaternion oldRot = transform.rotation; // old rotation
        Vector3 oldPos = transform.position; // old positon

        transform.rotation = Quaternion.identity; //setting rotation to 0.
        transform.position = Vector3.zero; // setting position to 0

        // get the meshFilters of all the objects children
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();

        Debug.Log(name + " is combining " + filters.Length + " meshes.");

        int fl = filters.Length;
        // need combine Instances for combining the meshes
        CombineInstance[] combines = new CombineInstance[filters.Length];
        Mesh finalMesh = new Mesh();


        // populate the combine Instance fields with the childrens feilds
        for (int i = 0; i < fl; i++)
        {
            if (filters[i].transform == transform)
            {
                continue;
            }
            combines[i].subMeshIndex = 0;
            combines[i].mesh = filters[i].sharedMesh;
            combines[i].transform = filters[i].transform.localToWorldMatrix; // gets transform location in the scene
        }


        // combining the meshes
        finalMesh.CombineMeshes(combines);
        GetComponent<MeshFilter>().sharedMesh = finalMesh; // editor mesh

        // restoring object to original (old) position / rotation
        transform.rotation = oldRot;
        transform.position = oldPos;

        //hide the children
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

    }
}
