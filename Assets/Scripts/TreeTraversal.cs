using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTraversal : MonoBehaviour
{
    private Coroutine traversalCoroutine; // Coroutine for traversal
    public float traversalDelay = 2f; // Delay between traversing each node
    public Color visitedColor = Color.green; // Color to change the visited nodes
    private SpriteRenderer SpriteRenderer;
    public void PreorderTraversal(TreeNode node)
    {
        
        if (node == null) return;

        Debug.Log(node.value); // Visit the current node
        PreorderTraversal(node.left); // Traverse left subtree
        PreorderTraversal(node.right); // Traverse right subtree
    }

    public void InorderTraversal(TreeNode node)
    {
        if (node == null) return;

        InorderTraversal(node.left); // Traverse left subtree
        Debug.Log(node.value); // Visit the current node
        InorderTraversal(node.right); // Traverse right subtree
    }

    public void PostorderTraversal(TreeNode node)
    {
        if (node == null) return;

        PostorderTraversal(node.left); // Traverse left subtree
        PostorderTraversal(node.right); // Traverse right subtree
        Debug.Log(node.value); // Visit the current node
    }

}
