using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Items : MonoBehaviour
{
    public Invokeble target;
    public Grid grid;
    public Tilemap tilemap;
    public Sprite[] sprites;
    public Tile tile;
    public int sprites_index = 0;
    public string pick_up, put_down;
    public Color placeable, unplaceable, normal;
    private SpriteRenderer spriteRenderer;
    private Invokeble dropTarget;
    private bool isDragging, isPlaceable, isInPlace, beenDrag, isDroppable;

    public Vector3 offset = new Vector3(0.5f, 0.5f);
    private Vector3 pick_up_position;
    private Vector3Int pick_up_position_grid;
    private BoxCollider2D this_collider;
    private Rigidbody2D this_rigidbody;
    public void OnMouseDown()
    {
        //�ƹ����U
        isDragging = true;
        beenDrag = false;
        target.InDrag();
        pick_up_position = transform.position;
        pick_up_position_grid = grid.WorldToCell(transform.position);
    }
    public void OnMouseUp()
    {
        //�ƹ��P�}
        isDragging = false;
        target.OutDrag();
        if (isInPlace & !beenDrag) { OnMouseClick(); return; }
        spriteRenderer.color = normal;
        spriteRenderer.sortingLayerName = put_down;
        if (isDroppable) { dropTarget.Drop(gameObject); return; }
        if (!isPlaceable)
        {
            transform.position = pick_up_position;
            tilemap.SetTile(pick_up_position_grid, tile);
            return;
        }
        Vector3Int cell_position = grid.WorldToCell(transform.position);
        tilemap.SetTile(cell_position, tile);
    }
    public void OnMouseClick() { target.Click(); }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDragging) return;
        dropTarget = collision.gameObject.GetComponent<Invokeble>();
        if (dropTarget == null) return;
        isDroppable = dropTarget.IsDroppable(gameObject);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isDroppable = false;
    }
    public void Init()
    {
        tile.color = new Color(0f, 0f, 0f, 0f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        this_collider = GetComponent<BoxCollider2D>();
        this_rigidbody = GetComponent<Rigidbody2D>();
        this_collider.isTrigger = true;
        this_collider.size = new Vector2(0.97f, 0.97f);
        this_rigidbody.bodyType = RigidbodyType2D.Kinematic;
        this_rigidbody.gravityScale = 0f;

        Vector3Int cell_position = grid.WorldToCell(transform.position);
        tilemap.SetTile(cell_position, tile);
        Vector3 moving_position = grid.CellToLocalInterpolated(cell_position) + offset;
        transform.position = moving_position;
    }
    void Start()
    {
        if (gameObject.activeSelf) { Init(); }
    }
    void Update()
    {
        if (!isDragging) return;
        target.Drag();
        Vector3 camera_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cell_position = grid.WorldToCell(camera_position);
        Vector3 moving_position = grid.CellToLocalInterpolated(cell_position) + offset;
        transform.position = moving_position;
        isInPlace = pick_up_position == moving_position;
        if (isInPlace) { spriteRenderer.color = normal; return; }
        tilemap.SetTile(pick_up_position_grid, null);
        isPlaceable = !tilemap.HasTile(cell_position); //�ŴN�i��
        beenDrag = true;
        spriteRenderer.sortingLayerName = pick_up;
        if (isPlaceable || isDroppable) spriteRenderer.color = placeable;
        else spriteRenderer.color = unplaceable;
    }
}
