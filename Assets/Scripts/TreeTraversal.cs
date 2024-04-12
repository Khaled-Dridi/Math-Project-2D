using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTraversal : MonoBehaviour
{
    public void PreorderTraversal(TreeNode node)
    {
        if (node == null)
            return;

        // Visualize visited node
        node.GetComponent<SpriteRenderer>().color = Color.yellow;

        PreorderTraversal(node.left);
        PreorderTraversal(node.right);
    }

    public void InorderTraversal(TreeNode node)
    {
        if (node == null)
            return;

        InorderTraversal(node.left);

        // Visualize visited node
        node.GetComponent<SpriteRenderer>().color = Color.yellow;

        InorderTraversal(node.right);
    }

    public void PostorderTraversal(TreeNode node)
    {
        if (node == null)
            return;

        PostorderTraversal(node.left);
        PostorderTraversal(node.right);

        // Visualize visited node
        node.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public void LevelOrderTraversal(TreeNode root)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();

            // Visualize visited node
            node.GetComponent<SpriteRenderer>().color = Color.yellow;

            if (node.left != null)
                queue.Enqueue(node.left);

            if (node.right != null)
                queue.Enqueue(node.right);
        }
    }
}
