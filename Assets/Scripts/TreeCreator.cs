using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCreator : MonoBehaviour
{
    public GameObject treeNodePrefab;  // Assign your TreeNode prefab in the Inspector
    private TreeNode selectedNode;     // Keep track of the currently selected node
    private int value = 1;
    public TreeNode rootNode;
  
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Ensure nodes are on the same z-plane

            // Check if a node was clicked
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                TreeNode clickedNode = hit.collider.GetComponent<TreeNode>();
                if (clickedNode != null)
                {
                    // If a node was clicked, select it
                    SelectNode(clickedNode);
                }
            }
            else
            {
                // If no node was clicked, create a new node at the click position
                CreateNode(mousePosition);
            }
        }
      
    }

    void CreateNode(Vector3 position)
    {
        if (selectedNode == null && value != 1)
        {
            return;
        }
        // Instantiate a new node prefab at the given position
        GameObject newNode = Instantiate(treeNodePrefab, position, Quaternion.identity);
        TreeNode nodeComponent = newNode.GetComponent<TreeNode>();
        if (rootNode == null)
        {
            rootNode = nodeComponent;
            rootNode.gameObject.transform.SetParent(GameObject.Find("Tree").transform);
            
        }
        nodeComponent.SetValue(value++);

        if (selectedNode != null)
        {
            // If a node is selected, link the new node as its child
            if (selectedNode.left == null)
            {
                nodeComponent.SetPosition("L");
                selectedNode.left = nodeComponent;
            }
            else if (selectedNode.right == null)
            {
                nodeComponent.SetPosition("R");
                selectedNode.right = nodeComponent;
            }
            else
            {
                Debug.Log("you cant do that ");
                Destroy(newNode);
                return;
            }
            nodeComponent.gameObject.transform.SetParent(selectedNode.transform);
            // Visualize the connection (optional)
            DrawLineBetweenNodes(selectedNode.transform.position, position);

            // Deselect the node after linking
            selectedNode.DeselectNode();
            selectedNode = null;
        }
        else
        {
            // If no node is selected, set the new node as the selected node

            selectedNode = nodeComponent;
            if (selectedNode.SendSignal())
            {
                Debug.Log("selected");
            selectedNode.SelectNode();
            }
        }
    }

    void SelectNode(TreeNode node)
    {
        // Deselect the previously selected node (if any)
        if (selectedNode != null)
        {
            selectedNode.DeselectNode();
        }

        // Select the new node
        selectedNode = node;
        selectedNode.SelectNode();
        Debug.Log("Node Selected: " + node.value);
    }

    // Optional: Method to visualize the connection between nodes
    void DrawLineBetweenNodes(Vector3 startPos, Vector3 endPos)
    {
        // Example: Use LineRenderer to draw a line between nodes
        LineRenderer lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.gameObject.transform.SetParent(GameObject.Find("Lines").transform);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
