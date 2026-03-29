using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class flipImage : MonoBehaviour
{
    public Image img;
    public RectTransform rt;

    void Awake()
    {
        img = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
    }

    void Start()
    {
        rt.localScale = new Vector3(-1, 1, 1);
    }
}
