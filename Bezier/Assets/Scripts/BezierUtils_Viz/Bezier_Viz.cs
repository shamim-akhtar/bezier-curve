using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier_Viz : MonoBehaviour
{
    public List<Vector2> ControlPoints = new List<Vector2>();
    public GameObject PointPrefab;
    public float LineWidth;
    public Color LineColour = new Color(0.5f, 0.5f, 0.5f, 0.8f);
    public Color BezierCurveColour = new Color(0.5f, 0.6f, 0.8f, 0.8f);

    List<GameObject> mLineRenderers = new List<GameObject>();
    List<GameObject> mPointGameObjects = new List<GameObject>();


    private LineRenderer GetOrCreateLine(int index)
    {
        if (index >= mLineRenderers.Count)
        {
            GameObject obj = new GameObject();
            obj.name = "LineRenderer_obj_" + index.ToString();
            //obj.AddComponent<EdgeCollider2D>();
            //obj.transform.SetParent(transform);
            LineRenderer lr = obj.AddComponent<LineRenderer>();
            mLineRenderers.Add(obj);
        }
        return mLineRenderers[index].GetComponent<LineRenderer>();
    }

    // create a LineRenderer default
    LineRenderer CreateLineRenderer(int i)
    {
        LineRenderer lr = GetOrCreateLine(i);
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = LineColour;
        lr.endColor = LineColour;
        lr.startWidth = LineWidth;
        lr.endWidth = LineWidth;
        return lr;
    }

    // Start is called before the first frame update
    void Start()
    { 
        // show the control points.
        for(int i = 0; i < ControlPoints.Count; ++i)
        {
            GameObject obj = Instantiate(PointPrefab, ControlPoints[i], Quaternion.identity);
            obj.name = "ControlPoint_" + i.ToString();
            mPointGameObjects.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = CreateLineRenderer(0);
        LineRenderer curveRenderer = CreateLineRenderer(1);

        List<Vector2> pts = new List<Vector2>();
        //List<Vector2> inv_pts = new List<Vector2>();

        //EdgeCollider2D ec = mLineRenderers[0].GetComponent<EdgeCollider2D>();

        for (int k = 0; k < mPointGameObjects.Count; ++k)
        {
            pts.Add(mPointGameObjects[k].transform.position);
            //inv_pts.Add(ec.transform.InverseTransformPoint(mPointGameObjects[k].transform.position));
        }
        //ec.points = pts.ToArray();

        // create a line renderer for showing the straight lines between control points.
        lineRenderer.positionCount = pts.Count;
        for (int i = 0; i < pts.Count; ++i)
        {
            lineRenderer.SetPosition(i, pts[i]);
        }

        // we take the control points from the list of points in the scene.
        // recalculate points every frame.
        List<Vector2> curve = BezierCurve.PointList2(pts, 0.01f);
        curveRenderer.startColor = BezierCurveColour;
        curveRenderer.endColor = BezierCurveColour;
        curveRenderer.positionCount = curve.Count;
        for (int i = 0; i < curve.Count; ++i)
        {
            curveRenderer.SetPosition(i, curve[i]);
        }
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isMouse)
        {
            if(e.clickCount == 2 && e.button == 0)
            {

                Vector2 rayPos = new Vector2(
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                //RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

                //if (hit)
                //{
                //    GameObject obj = hit.transform.gameObject;
                //    Debug.Log("Hit point: " + hit.point.x + ", " + hit.point.y);
                //    Debug.Log("Mouse clicks: " + e.clickCount);
                //}
                InsertNewControlPoint(rayPos);
            }
        }
    }

    void InsertNewControlPoint(Vector2 p)
    {
        GameObject obj = Instantiate(PointPrefab, p, Quaternion.identity);
        obj.name = "ControlPoint_" + mPointGameObjects.Count.ToString();
        mPointGameObjects.Add(obj);
    }
}
