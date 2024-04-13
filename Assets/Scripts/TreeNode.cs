using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreeNode : MonoBehaviour
{
    public int value;
    public TreeNode left;
    public TreeNode right;

    public Color defaultColor = Color.white; // Default color of the node
    public Color selectedColor = Color.yellow; // Color when node is selected
    public SpriteRenderer spriteRenderer;
    private bool signal = false;
    private String position="";
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

    public void SetValue(int newValue)
    {
        value = newValue;
        SetPosition(position);
    }
    public TextMeshProUGUI textMeshProUGUI;
    public void SetPosition(string pos)
    {
        position = pos;
        textMeshProUGUI.text = position + value.ToString();
        gameObject.name = position + value.ToString();
         
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
