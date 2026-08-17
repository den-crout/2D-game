 using UnityEngine;   // Gives access to Unity's commands

public class PlayerMovement : MonoBehaviour //creates a Unity component
{
  

    public float speed = 4f;
    public float health = 100f;
    public GameObject bulletPrefab;    //reference to a bullet prefab

    public float shootCooldown = 0.5f;
    private float shootTimer = 0f;
    private GameObject[] enemies;

    private SpriteRenderer spriteRenderer;    //spriterenderrer attached to a player

    private MapBounds mapBounds;
    private PolygonCollider2D playerCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   // find the spriterenderer on this gameObject and store reference to it
        mapBounds = FindAnyObjectByType<MapBounds>();
        playerCollider = GetComponent<PolygonCollider2D>();
    }
   
   

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Move();
        LimitBounds();

        shootTimer += Time.deltaTime;

        if (shootTimer >= shootCooldown)   //add time that passed since the previous frame to our shooting timer
        {
            shooting();
            shootTimer = 0f;
        }
    }


    void LimitBounds()
    {
        Vector3 position = transform.position;   // copy of the palyer's current position
        Bounds colliderBounds = playerCollider.bounds;
        Vector3 extents = colliderBounds.extents;

        position.x = Mathf.Clamp(position.x, mapBounds.left + extents.x, mapBounds.right - extents.x);   //bounds for X
        position.y = Mathf.Clamp(position.y, mapBounds.bottom + extents.y, mapBounds.top - extents.y);   // bounds for y

        transform.position = position;   //get player back to the position between bounds
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal");  // for horizontal input
        float y = Input.GetAxis("Vertical");    // for vertical input

        if (x < 0)
        {
            spriteRenderer.flipX = true;    //flip sprite
        }
        if (x > 0)
        {
            spriteRenderer.flipX = false;   //flip sprite
        }

        Vector2 direction = new Vector2(x, y);  //combine horizontal and vertical input into one vector.
        transform.position += (Vector3)direction * speed * Time.deltaTime;   //(vector3) - converts vector2 into vector3
    }

    public void TakeDamage(float damage)   //when player takes damage its called by another script
    {
        health -= damage;
       
        if (health <= 0)
        {
            Debug.Log("Player is dead!");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("I lost" + damage + "hp!");
        }
    }

    void shooting()
    {
        if (enemies.Length > 0)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        
    }
}
