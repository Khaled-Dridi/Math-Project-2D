using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TreeTraversal treeTraversal;
    public TreeCreator TreeCreator;
    public void PreorderTraversalButton()
    {
        
        StartCoroutine(treeTraversal.PreorderTraversal(TreeCreator.rootNode));
    }
    public void InorderTraversalButton()
    {
        StartCoroutine(treeTraversal.InorderTraversal(TreeCreator.rootNode));
        
    }
    public void PostorderTraversalButton()
    {
        StartCoroutine(treeTraversal.PostorderTraversal(TreeCreator.rootNode));
    }
}
