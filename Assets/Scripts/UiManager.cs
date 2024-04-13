using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TreeTraversal treeTraversal;
    public TreeCreator TreeCreator;
    public void PreorderTraversalButton()
    {
        ChangeState(0);
        treeTraversal.DeleteText();
        StartCoroutine(treeTraversal.PreorderTraversal(TreeCreator.rootNode));
    }
    public void InorderTraversalButton()
    {
        ChangeState(1);

        treeTraversal.DeleteText();
        StartCoroutine(treeTraversal.InorderTraversal(TreeCreator.rootNode));
        
    }
    public void PostorderTraversalButton()
    {
        ChangeState(2);

        treeTraversal.DeleteText();
        StartCoroutine(treeTraversal.PostorderTraversal(TreeCreator.rootNode));
    }
    private void ChangeState(int i)
    {
        treeTraversal.Preorder = false;
        treeTraversal.Inorder = false;
        treeTraversal.Postorder = false;
        switch (i)
        {
            case 0:
                treeTraversal.Preorder=true;
                treeTraversal.Inorder = false;
                treeTraversal.Postorder = false;
                break;
                case 1:
                treeTraversal.Preorder = false;
                treeTraversal.Inorder = true;
                treeTraversal.Postorder = false;
                break;
                case 2:
                treeTraversal.Preorder = false;
                treeTraversal.Inorder = false;
                treeTraversal.Postorder = true;
                break;


        }
    } 
}
