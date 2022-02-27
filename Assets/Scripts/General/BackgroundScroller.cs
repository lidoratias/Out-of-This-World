using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 2.0f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
