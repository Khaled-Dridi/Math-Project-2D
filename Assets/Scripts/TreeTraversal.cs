using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTraversal : MonoBehaviour
{
    public float traversalDelay = 2f; // Delay between traversing each node
    public Color visitedColor = Color.green; // Color to change the visited nodes
    private TreeNode currentNode; // Current node being visited

    public IEnumerator PreorderTraversal(TreeNode node)
    {
        if (node == null) yield break;

        SetNodeColor(node, visitedColor); // Change color to visited color
        Debug.Log("Preorder: " + node.value); // Debug the value
        currentNode = node;

        yield return new WaitForSeconds(traversalDelay); // Wait for traversal delay

        yield return StartCoroutine(PreorderTraversal(node.left)); // Traverse left subtree
        yield return StartCoroutine(PreorderTraversal(node.right)); // Traverse right subtree

        SetNodeColor(node, Color.white); // Reset color after traversal
        currentNode = null;
    }

    public IEnumerator InorderTraversal(TreeNode node)
    {
        if (node == null) yield break;

        yield return StartCoroutine(InorderTraversal(node.left)); // Traverse left subtree

        SetNodeColor(node, visitedColor); // Change color to visited color
        Debug.Log("Inorder: " + node.value); // Debug the value
        currentNode = node;

        yield return new WaitForSeconds(traversalDelay); // Wait for traversal delay

        yield return StartCoroutine(InorderTraversal(node.right)); // Traverse right subtree

        SetNodeColor(node, Color.white); // Reset color after traversal
        currentNode = null;
    }

    public IEnumerator PostorderTraversal(TreeNode node)
    {
        if (node == null) yield break;

        yield return StartCoroutine(PostorderTraversal(node.left)); // Traverse left subtree
        yield return StartCoroutine(PostorderTraversal(node.right)); // Traverse right subtree

        SetNodeColor(node, visitedColor); // Change color to visited color
        Debug.Log("Postorder: " + node.value); // Debug the value
        currentNode = node;

        yield return new WaitForSeconds(traversalDelay); // Wait for traversal delay

        SetNodeColor(node, Color.white); // Reset color after traversal
        currentNode = null;
    }

    void SetNodeColor(TreeNode node, Color color)
    {
        if (node == null || node.spriteRenderer == null)
        {
            Debug.LogWarning("Node or SpriteRenderer is null.");
            return;
        }

        node.spriteRenderer.color = color;
    }


}
