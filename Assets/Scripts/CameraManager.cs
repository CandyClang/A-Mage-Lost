using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject followTarget;
    public Vector2 followOffset;
    private Vector2 threshold;
    public float speed;
    private Rigidbody rb;

    public Vector3 target;

    //Pause pause;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        threshold = calculateThreshold();
        rb = followTarget.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.isPaused)
        {
            Cursor.visible = true;
        } else
        {
            Cursor.visible = false;
        }
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        crosshair.transform.position = new Vector2(target.x, target.y);
    }

    private void LateUpdate()
    {
        Vector2 follow = followTarget.transform.position;
        float diffx = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float diffy = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPos = transform.position;
        if (Mathf.Abs(diffx) >= threshold.x)
        {
            newPos.x = follow.x;
        }
        if (Mathf.Abs(diffy) >= threshold.y)
        {
            newPos.y = follow.y;
        }

        float moveSpeed = rb.velocity.magnitude > speed ? rb.velocity.magnitude : speed;

        transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime);
    }

    private Vector3 calculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
}
