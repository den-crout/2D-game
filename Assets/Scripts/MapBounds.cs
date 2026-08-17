using UnityEngine;
using UnityEngine.Tilemaps;

public class MapBounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Tilemap tilemap;
    public float left;
    public float right;
    public float bottom;
    public float top;
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        BoundsInt bounds = tilemap.cellBounds;

        Vector3 min = bounds.min;
        Vector3 max = bounds.max;
        left = min.x;
        right = max.x;
        bottom = min.y;
        top = max.y;
        Debug.Log(bounds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
