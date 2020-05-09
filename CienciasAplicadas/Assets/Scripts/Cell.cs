using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Cell : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform pivot;
    Rigidbody2D rb;
    public float speed;
    public float maxSpeed;
    public float springRange;

    Vector2 disVector;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

    }

    bool canDrag = true;
    Vector2 dis;
    private void OnMouseDrag()
    {
        if (!canDrag)
            return;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 positionPiv2 = new Vector2(pivot.position.x, pivot.position.y);
        dis = pos - positionPiv2;
        if (dis.magnitude > springRange)
        {
            dis = dis.normalized * springRange;
        }
        transform.position = dis + positionPiv2;
        disVector = dis;
    }

    private void OnMouseUp()
    {
        if (!canDrag)
            return;
        canDrag = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = -dis.normalized * maxSpeed * dis.magnitude / springRange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
