using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f,1f)]
    public float scrollerSpeed = 0.5f;
    private float offset;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollerSpeed)/10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, offset));
    }
}
