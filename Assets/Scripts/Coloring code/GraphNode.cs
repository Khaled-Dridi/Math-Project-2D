using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode : MonoBehaviour
{
    public Color defaultColor = Color.white; // Default color of the node
    public Color selectedColor = Color.yellow; // Color when node is selected
    public SpriteRenderer spriteRenderer;
    private bool signal = false;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on TreeNode prefab. line 20");
            return;
        }

        spriteRenderer.color = defaultColor;

        signal = true;
    }
    public bool SendSignal()
    {
        return signal;
    }
    public void SelectNode()
    {
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on TreeNode prefab. line 41");
            return;
        }

        spriteRenderer.color = selectedColor;
    }

    public void DeselectNode()
    {
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on TreeNode prefab. line 52");
            return;
        }

        spriteRenderer.color = defaultColor;
    }
}
