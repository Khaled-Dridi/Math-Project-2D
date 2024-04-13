using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMAnager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.SetParent(GameObject.Find("TextCanvas").transform);
    }

    
}
