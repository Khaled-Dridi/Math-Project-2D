using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TreeTraversal treeTraversal;
    public TreeCreator TreeCreator;
    public void PreorderTraversalButton()
    {
        treeTraversal.Preorder = true;
        treeTraversal.Inorder = false;
        treeTraversal.Postorder = false;
        treeTraversal.DeleteText();
        StartCoroutine(treeTraversal.PreorderTraversal(TreeCreator.rootNode));
    }

    public void InorderTraversalButton()
    {
        treeTraversal.Preorder = false;
        treeTraversal.Inorder = true;
        treeTraversal.Postorder = false;
        treeTraversal.DeleteText();
        StartCoroutine(treeTraversal.InorderTraversal(TreeCreator.rootNode));
    }

    public void PostorderTraversalButton()
    {
        treeTraversal.Preorder = false;
        treeTraversal.Inorder = false;
        treeTraversal.Postorder = true;
        treeTraversal.DeleteText();
        StartCoroutine(treeTraversal.PostorderTraversal(TreeCreator.rootNode));
    }
}
