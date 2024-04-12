using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraverseCode : MonoBehaviour
{
    public TreeTraversal treeTraversal;
    public TreeCreator TreeCreator;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            treeTraversal.PreorderTraversal(TreeCreator.rootNode);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            treeTraversal.InorderTraversal(TreeCreator.rootNode);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            treeTraversal.PostorderTraversal(TreeCreator.rootNode);
        }
    }
}
