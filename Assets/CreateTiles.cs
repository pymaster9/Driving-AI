using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateTiles : MonoBehaviour
{
    public static CreateTiles main;
    public List<GameObject> tilesplaced;
    public GameObject trackPiece;
    public int segments, trackLength;
    void Start()
    {
        main = this;
        GenerateTrack(segments, trackLength);
    }

    void DestroyTrack()
    {
        foreach (GameObject curr in tilesplaced)
        {
            Destroy(curr);
        }
    }

    void GenerateTrack(int numberOfSides, int trackLength)
    {
        DestroyTrack();
        //Create Track
        Vector2Int position = new Vector2Int(0,0);
        Vector2Int movementDelta = new Vector2Int(1, 0);
        for(int side = 0; side < numberOfSides; side++)
        {
            //Create Straight Track
            for(int x = 0; x < trackLength; x++)
            {
                position += movementDelta;
                tilesplaced.Add(Instantiate(trackPiece, new Vector3(position.x * 15, 0, position.y * 15), transform.rotation));
            }
            //Turn
            float degrees = Mathf.Atan2(movementDelta.y, movementDelta.x) * Mathf.Rad2Deg;
            Vector2Int mdleft = new Vector2Int(Mathf.RoundToInt(Mathf.Cos((degrees + 90) * Mathf.Deg2Rad)), Mathf.RoundToInt(Mathf.Sin((degrees + 90) * Mathf.Deg2Rad)));
            Vector2Int mdright = new Vector2Int(Mathf.RoundToInt(Mathf.Cos((degrees- 90) * Mathf.Deg2Rad)), Mathf.RoundToInt(Mathf.Sin((degrees - 90) * Mathf.Deg2Rad)));
            bool useleft = true, useright = true;
            foreach(GameObject curr in tilesplaced)
            {
                if(new Vector2Int(Mathf.RoundToInt(curr.transform.position.x), Mathf.RoundToInt(curr.transform.position.y)) == (position + 10 * mdleft))
                {
                    useleft = false;
                }
                else if (new Vector2Int(Mathf.RoundToInt(curr.transform.position.x), Mathf.RoundToInt(curr.transform.position.y)) == position + (10 * mdright))
                {
                    useright = false;
                }
            }
            if (useleft && useright)
            {
                if (Random.Range(0, 2) == 0) { degrees += 90; }
                else { degrees -= 90; }
                degrees *= Mathf.Deg2Rad;
                movementDelta = new Vector2Int(Mathf.RoundToInt(Mathf.Cos(degrees)), Mathf.RoundToInt(Mathf.Sin(degrees)));
                print(mdleft - movementDelta);
            }
            else if(useleft)
            {
                degrees += 90;
                degrees *= Mathf.Deg2Rad;
                movementDelta = new Vector2Int(Mathf.RoundToInt(Mathf.Cos(degrees)), Mathf.RoundToInt(Mathf.Sin(degrees)));
            }
            else if (useright)
            {
                degrees -= 90;
                degrees *= Mathf.Deg2Rad;
                movementDelta = new Vector2Int(Mathf.RoundToInt(Mathf.Cos(degrees)), Mathf.RoundToInt(Mathf.Sin(degrees)));
            }
        }
    }
}