using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private float minY = -1.1f;
    private float maxY = 1.35f;
    private float minSize = 0.13f;
    private float maxSize = 0.21f;
    // Start is called before the first frame update
    void Start()
    {
        float size = minSize + (((transform.position.y - minY) / (maxY - minY)) * (maxSize- minSize));
        transform.localScale = new Vector3(size, size, size);
    }
}
