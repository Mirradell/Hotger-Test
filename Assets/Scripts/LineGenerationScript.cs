using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerationScript : MonoBehaviour
{
    public GameObject wallTile;
    public GameObject mainSphere;
    public GameObject upButton;
    public Camera mainCamera;
    public float upWallYPosition;
    public float downWallYPosition;
    public int frequency;


    private LinkedList<GameObject> upWall;
    private LinkedList<GameObject> downWall;
    private LinkedList<GameObject> randomWall;
    private float sphereSpeed;
    private float cameraWindowSize;
    private float tileWidth;
    private float nextTileXPosition;
    private int counter;
    // Start is called before the first frame update
    void Awake()
    {
        mainSphere = Instantiate(mainSphere, new Vector3(0, 0), Quaternion.identity);
        upButton   = Instantiate(upButton, new Vector3(7, -3.45f), Quaternion.identity);
        mainSphere.GetComponent<MainSphereScript>().upButton = upButton;
        upButton.GetComponent<UpButtonScript>().mainSphere   = mainSphere;

        counter        = frequency;
        var wallSprite = wallTile.GetComponentInChildren<SpriteRenderer>().sprite;
        tileWidth      = wallTile.transform.localScale.x / wallSprite.pixelsPerUnit * wallSprite.rect.width;
        sphereSpeed    = ScenesDataStaticScript.speed;
        upWall         = new LinkedList<GameObject>();
        downWall       = new LinkedList<GameObject>();
        randomWall     = new LinkedList<GameObject>();

        cameraWindowSize  = Camera.main.orthographicSize * 2 + sphereSpeed;
        nextTileXPosition = -cameraWindowSize;
        while (nextTileXPosition <= cameraWindowSize)
        {
            upWall.AddLast(Instantiate(wallTile, new Vector3(nextTileXPosition, upWallYPosition), Quaternion.identity));
            downWall.AddLast(Instantiate(wallTile, new Vector3(nextTileXPosition, downWallYPosition), Quaternion.identity));
            nextTileXPosition += tileWidth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nextTileXPosition - mainSphere.transform.position.x < cameraWindowSize)
        {
            Destroy(upWall.First.Value);
            Destroy(downWall.First.Value);

            upWall.RemoveFirst();
            upWall.AddLast(Instantiate(wallTile, new Vector3(nextTileXPosition, upWallYPosition), Quaternion.identity));

            downWall.RemoveFirst();
            downWall.AddLast(Instantiate(wallTile, new Vector3(nextTileXPosition, downWallYPosition), Quaternion.identity));

            nextTileXPosition += tileWidth;
            counter--;
        }

        if (counter == 0)
        {
            counter = frequency;
            randomWall.AddLast(Instantiate(wallTile, 
                                           new Vector3(nextTileXPosition, Random.Range(downWallYPosition + tileWidth, upWallYPosition - tileWidth)), 
                                           Quaternion.identity));
        }

        if (randomWall.Count > 0 && randomWall.First.Value.transform.position.x < mainSphere.transform.position.x - cameraWindowSize)
        {
            Destroy(randomWall.First.Value);
            randomWall.RemoveFirst();
        }
    }
}
