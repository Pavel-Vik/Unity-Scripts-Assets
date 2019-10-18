using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class DrawLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject linePrefab;
    public GameObject triggerLinePrefab;
    private GameObject newGeneratedLine, newTriggerLine;
    private Transform player;

    private LineRenderer line;
    private EdgeCollider2D edgeColliderTrigger;
    private PolygonCollider2D edgeCollider;

    private List<Vector2> pointsPositions;
    private Random rand;
    private int difficulty = 10;

    public float levelSize;

    void Start()
    {

        LineGenerator();
        SetPlayerLocation();
    }
    
    void Update()
    {
        
    }

    private void LineGenerator()
    {
        newGeneratedLine = Instantiate(linePrefab);
        newTriggerLine = Instantiate(triggerLinePrefab);
        line = newGeneratedLine.GetComponent<LineRenderer>();
        edgeCollider = newGeneratedLine.GetComponent<PolygonCollider2D>();
        edgeColliderTrigger = newTriggerLine.GetComponent<EdgeCollider2D>();

        //pointsPositions.Clear();

        pointsPositions = gameObject.GetComponent<LoadData>().coordinates;

        AddStartAndEnd();

        edgeColliderTrigger.points = pointsPositions.ToArray();

        //AddHoles();


        for (int i = 0; i < pointsPositions.Count; i++)
        {
            line.positionCount++;
            line.SetPosition(i, pointsPositions[i]);
            //Debug.Log(pointsPositions[i]);
        }

        //line.SetPosition(0, pointsPositions[0]);
        //line.SetPosition(1, pointsPositions[1]);
        //line.SetPosition(2, pointsPositions[2]);

        edgeCollider.points = pointsPositions.ToArray();


        //DrawLines(0, 0, 0);
        //DrawLines(1, 10, 1);
        //DrawLines(2, 20, 0);
    }

    private void AddStartAndEnd()
    {
        pointsPositions.Insert(0, new Vector2(pointsPositions[0].x-10, pointsPositions[0].y));
        pointsPositions.Insert(0, new Vector2(pointsPositions[0].x, pointsPositions[0].y - 100));
        int indexOfLastPoint = pointsPositions.Count - 1;
        pointsPositions.Add(new Vector2(pointsPositions[indexOfLastPoint].x+10, pointsPositions[indexOfLastPoint].y));
        pointsPositions.Add(new Vector2(pointsPositions[indexOfLastPoint].x, pointsPositions[indexOfLastPoint].y - 100));

    }

    private void AddHoles()
    {
        if (difficulty > 0)
        {
            difficulty--;
            AddHoles();
        }
        float levelStartX;
        float levelEndX;
        float maxHoleSize = levelSize/50;
        float holeSize = Random.Range(5, maxHoleSize);

        levelStartX = pointsPositions[0].x;
        int indexOfLastPoint = pointsPositions.Count - 1;
        levelEndX = pointsPositions[indexOfLastPoint].x;

        int randPoint = Random.Range(0, indexOfLastPoint);


        float holeStartX = pointsPositions[randPoint].x - holeSize;
        float holeStartY = pointsPositions[randPoint].y;

        pointsPositions.Insert(randPoint, new Vector2(pointsPositions[randPoint].x, pointsPositions[randPoint].y - 20));
        pointsPositions.Insert(randPoint+1, new Vector2(pointsPositions[randPoint+1].x, pointsPositions[randPoint+1].y - 20));
        //pointsPositions.Insert(randPoint + 2, new Vector2(pointsPositions[randPoint + 2].x, pointsPositions[randPoint + 2].y - 20));
        //pointsPositions.Insert(randPoint+2, new Vector2(holeStartX + holeSize, -20));
        //pointsPositions.Insert(randPoint+3, new Vector2(holeStartX + holeSize, holeStartY));
    }

    private void SetPlayerLocation()
    {
        float levelStartX = pointsPositions[1].x;
        float levelEndX = pointsPositions[pointsPositions.Count - 1].x;
        float levelStartY = pointsPositions[1].y;
        levelSize = levelEndX - levelStartX;
        //Debug.Log(levelSize);
        float playerSize = (levelSize / 100) * 1/2;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        player.transform.position =  new Vector2 (levelStartX + 3, levelStartY + 3);
        player.transform.localScale = new Vector2(playerSize, playerSize);
    }

    //private void DrawLines(int index, float xCor, float yCor)
    //{

    //    Vector2[] colliderpoints;
    //    //colliderpoints = new Vector2[3];
    //    colliderpoints = collider.points;
    //    colliderpoints[index] = new Vector2(xCor, yCor);
    //    collider.points[index] = colliderpoints[index];

    //    line.SetPosition(index, new Vector2(xCor, yCor));
    //}
}
