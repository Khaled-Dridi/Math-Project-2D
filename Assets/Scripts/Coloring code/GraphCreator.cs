using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphCreator : MonoBehaviour
{
    public GameObject GraphNodePrefab;

    private GraphNode selectedNode;

    private int value = 0;
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(1))
        {
        //    Debug.Log("clicked");

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Ensure nodes are on the same z-plane
            
            // Check if a node was clicked
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                GraphNode clickedNode = hit.collider.GetComponent<GraphNode>();
                Debug.Log("clicked line 27");
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
        if (selectedNode == null && value != 0)
        {
            return;
        }

        // Instantiate a new node prefab at the given position
        GameObject newNode = Instantiate(GraphNodePrefab, position, Quaternion.identity);
        GraphNode nodeComponent = newNode.GetComponent<GraphNode>();


        if (selectedNode != null)
        {
            Debug.Log("line53");
            value++;

            // Visualize the connection (optional)
            DrawLineBetweenNodes(selectedNode.transform.position, nodeComponent.transform.position);

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

    void SelectNode(GraphNode node)
    {

        // Deselect the previously selected node (if any)
        if (selectedNode != null)
        {
            selectedNode.DeselectNode();
        }

        // Select the new node
        selectedNode = node;
        selectedNode.SelectNode();
          Debug.Log("Node Selected: " );
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
