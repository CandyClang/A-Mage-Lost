using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPositions;

    private Ray ray;
    private RaycastHit hit;

    bool lineDrawing;

    public CameraManager cam;
    public GameObject waterBall;
    GameObject waterHeld;

    Animator anim;

    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("character").GetComponent<Animator>();
        cam = Camera.main.GetComponent<CameraManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject mana = GameObject.Find("ManaSystem");
        ManaManager manaManager = mana.GetComponent<ManaManager>();

        if (lineDrawing)
        {
            Vector3 target = cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            waterHeld.transform.position = new Vector2(target.x, target.y);
        }

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Pause.isPaused) //if any issue remove pause thing
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (MouseOverWater())
                {
                    waterHeld = Instantiate(waterBall, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                    //waterHeld.GetComponent<MeshRenderer>().enabled = true;

                    anim.SetTrigger("Cast");

                    manaManager.currManaAmount -= 20f;

                    lineDrawing = true;
                  //  CreateLine();
                    soundManager.playSound(SoundManager.Sound.Water);
                }
            }
            if (Input.GetMouseButton(0) && lineDrawing)
            {
                Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f)
                //{
                //    UpdateLine(tempFingerPos);
                //}
            }
            if (Input.GetMouseButtonUp(0))
            {
                Destroy(waterHeld);
                anim.SetTrigger("Release");
                lineDrawing = false;
               // Destroy(currentLine);
            }


            if (lineDrawing)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Growable")
                    {
                        soundManager.playSound(SoundManager.Sound.Splash);
                        GrowablePlants bush = hit.collider.GetComponent<GrowablePlants>();
                        bush.Grow();

                        Destroy(waterHeld);

                        
                        anim.SetTrigger("Release");

                        lineDrawing = false;
                    }
                    if(hit.collider.tag == "FireObstacle")
                    {
                        soundManager.playSound(SoundManager.Sound.Splash);
                        hit.collider.gameObject.SetActive(false);
                        lineDrawing = false;
                        Destroy(waterHeld);
                        anim.SetTrigger("Release");

                    }

                    if (hit.collider.tag == "destroyWater" ||
                        hit.collider.tag == "Flammable" ||
                        hit.collider.tag == "boulder")
                    {
                        lineDrawing = false;
                        Destroy(waterHeld);
                        

                    }


                }

            }
        } //if any issue remove this line
    }


    void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
        edgeCollider.points = fingerPositions.ToArray();
    }

    void UpdateLine(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();

    }

    bool MouseOverWater()
    {
        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.tag == "WaterSource";
        }
        else
        {
            return false;
        }
    }
}