using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class TetherRopeController : MonoBehaviour
{
    public Material spriteMaterial;
    public LayerMask layerMask;
    public float tetherWidth = .2f;
    public Dictionary<string, List<Transform>> pointsDictionary = new Dictionary<string, List<Transform>>();
    public Dictionary<string, LineRenderer> linerenderers = new Dictionary<string, LineRenderer>();

    private bool isShootingRay = false;

    public LineRenderer drawingLine;

    private bool isDrawing = false;

    public List<RobotMovementController> tetheredRobots;
    public GameEvent lineCreated;
    // Start is called before the first frame update
    void Start()
    {
        tetheredRobots = new List<RobotMovementController>();
        drawingLine = GetComponent<LineRenderer>();
        drawingLine.SetPosition(0, transform.position);
        drawingLine.SetPosition(1, transform.position);
        drawingLine.startWidth = tetherWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDrawing)
        {
            if (pointsDictionary.Keys.Count > 0)
            {
                foreach (string key in pointsDictionary.Keys)
                {
                    List<Transform> points;
                    pointsDictionary.TryGetValue(key, out points);

                    for (int i = 0; i < points.Count; i++)
                    {
                        LineRenderer lineRenderer;
                        linerenderers.TryGetValue(key, out lineRenderer);
                        if (lineRenderer)
                        {
                            lineRenderer.SetPosition(i, new Vector3(points[i].position.x, points[i].position.y, -2f));
                        }
                    }

                }
            }
        }
        
        else if (isDrawing)
        {
            DrawLine();
        }
    }

    public void FixedUpdate()
    {
        if (isShootingRay)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10f, layerMask);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);
            if (hit)
            {
                if(hit.transform.name != transform.name)
                {
                    CreateLine(hit.transform);
                }
            }
            else
            {
                resetDrawingLine();
            }
        }
    }

    private void resetDrawingLine()
    {
        drawingLine.SetPosition(1, transform.position);
    }

    private void OnMouseDown()
    {
        StartDrawing();
    }

    private void OnMouseUp()
    {
        isShootingRay = true;
    }

    public void CreateLine(Transform target)
    {
        isShootingRay = false;
        isDrawing = false;
        resetDrawingLine();

        List<Transform> newPoints = new List<Transform>();
        newPoints.Add(transform);
        newPoints.Add(target);

        GameObject lineToSpawn = new GameObject("Line");
        LineRenderer lineRenderer = lineToSpawn.AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.red;
        lineRenderer.startWidth = tetherWidth;
        lineRenderer.sortingOrder = 2;
        lineRenderer.material = spriteMaterial;
        linerenderers.Add("line1" + pointsDictionary.Keys.Count, lineRenderer);
        pointsDictionary.Add("line1" + pointsDictionary.Keys.Count, newPoints);
        tetheredRobots.Add(target.gameObject.GetComponent<RobotMovementController>());
        lineCreated.Raise();
    }

    public void StartDrawing()
    {
        drawingLine.SetPosition(1, transform.position);
        isDrawing = true;
    }

    public void DrawLine()
    {
        drawingLine.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
