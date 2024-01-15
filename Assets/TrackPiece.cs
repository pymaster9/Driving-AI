using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPiece : MonoBehaviour
{
    public bool selectedLeft, selectedRight, selectedUp, selectedDown;
    public GameObject straightTrack, turnTrack, finishTrack, threeWayIntersection, fourWayIntersection;
    void Update()
    {
        selectedLeft = false; selectedRight = false; selectedUp = false; selectedDown = false;
        foreach(GameObject curr in CreateTiles.main.tilesplaced)
        {
            //Find Intersection
            if (gameObject != curr)
            {
                if (curr.transform.position == transform.position)
                {
                    CreateTiles.main.tilesplaced.Remove(gameObject);
                    Destroy(gameObject);
                }
                if (curr.transform.position.x == transform.position.x + 15 && curr.transform.position.z == transform.position.z)
                {
                    selectedLeft = true;
                }
                if (curr.transform.position.x == transform.position.x - 15 && curr.transform.position.z == transform.position.z)
                {
                    selectedRight = true;
                }
                if (curr.transform.position.z == transform.position.z + 15 && curr.transform.position.x == transform.position.x)
                {
                    selectedUp = true;
                }
                if (curr.transform.position.z == transform.position.z - 15 && curr.transform.position.x == transform.position.x)
                {
                    selectedDown = true;
                }
            }
        }
        //Plot straights
        if (selectedLeft && selectedRight && !selectedUp && !selectedDown)
        {
            straightTrack.SetActive(true);
            finishTrack.SetActive(false);
            turnTrack.SetActive(false);
            threeWayIntersection.SetActive(false);
            fourWayIntersection.SetActive(false);
            straightTrack.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (!selectedLeft && !selectedRight && selectedUp && selectedDown)
        {
            straightTrack.SetActive(true);
            finishTrack.SetActive(false);
            turnTrack.SetActive(false);
            threeWayIntersection.SetActive(false);
            fourWayIntersection.SetActive(false);
            straightTrack.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Plot finishes L-R
        if (selectedLeft && !selectedRight && !selectedUp && !selectedDown)
        {
            straightTrack.SetActive(false);
            finishTrack.SetActive(true);
            turnTrack.SetActive(false);
            threeWayIntersection.SetActive(false);
            fourWayIntersection.SetActive(false);
            finishTrack.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (!selectedLeft && selectedRight && !selectedUp && !selectedDown)
        {
            straightTrack.SetActive(false);
            finishTrack.SetActive(true);
            turnTrack.SetActive(false);
            threeWayIntersection.SetActive(false);
            fourWayIntersection.SetActive(false);
            finishTrack.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Plot finishes U-D
        if (!selectedLeft && !selectedRight && selectedUp && !selectedDown)
        {
            straightTrack.SetActive(false);
            finishTrack.SetActive(true);
            turnTrack.SetActive(false);
            threeWayIntersection.SetActive(false);
            fourWayIntersection.SetActive(false);
            finishTrack.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (!selectedLeft && !selectedRight && !selectedUp && selectedDown)
        {
            straightTrack.SetActive(false);
            finishTrack.SetActive(true);
            turnTrack.SetActive(false);
            threeWayIntersection.SetActive(false);
            fourWayIntersection.SetActive(false);
            finishTrack.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Plot Turns U-L and D-L
        if (selectedLeft && !selectedRight && selectedUp && !selectedDown)
        {
            straightTrack.SetActive(false);
            finishTrack.SetActive(false);
            turnTrack.SetActive(true);
            threeWayIntersection.SetActive(false);
            fourWayIntersection.SetActive(false);
            turnTrack.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (selectedLeft && !selectedRight && !selectedUp && selectedDown)
        {
            straightTrack.SetActive(false);
            finishTrack.SetActive(false);
            turnTrack.SetActive(true);
            threeWayIntersection.SetActive(false);
            fourWayIntersection.SetActive(false);
            turnTrack.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        //Plot Turns U-R and D-R
        if (!selectedLeft && selectedRight && selectedUp && !selectedDown)
        {
            straightTrack.SetActive(false);
            finishTrack.SetActive(false);
            turnTrack.SetActive(true);
            threeWayIntersection.SetActive(false);
            fourWayIntersection.SetActive(false);
            turnTrack.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (!selectedLeft && selectedRight && !selectedUp && selectedDown)
        {
            straightTrack.SetActive(false);
            finishTrack.SetActive(false);
            turnTrack.SetActive(true);
            threeWayIntersection.SetActive(false);
            fourWayIntersection.SetActive(false);
            turnTrack.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Plot ThreeWayIntersections
        if (selectedLeft && selectedRight && selectedUp && !selectedDown)
        {
            straightTrack.SetActive(false);
            finishTrack.SetActive(false);
            turnTrack.SetActive(false);
            threeWayIntersection.SetActive(true);
            fourWayIntersection.SetActive(false);
            threeWayIntersection.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (!selectedLeft && selectedRight && selectedUp && selectedDown)
        {
            straightTrack.SetActive(false);
            finishTrack.SetActive(false);
            turnTrack.SetActive(false);
            threeWayIntersection.SetActive(true);
            fourWayIntersection.SetActive(false);
            threeWayIntersection.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (selectedLeft && selectedRight && !selectedUp && selectedDown)
        {
            straightTrack.SetActive(false);
            finishTrack.SetActive(false);
            turnTrack.SetActive(false);
            threeWayIntersection.SetActive(true);
            fourWayIntersection.SetActive(false);
            threeWayIntersection.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (selectedLeft && !selectedRight && selectedUp && selectedDown)
        {
            straightTrack.SetActive(false);
            finishTrack.SetActive(false);
            turnTrack.SetActive(false);
            threeWayIntersection.SetActive(true);
            fourWayIntersection.SetActive(false);
            threeWayIntersection.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        //Plot FourWayIntersection
        if (selectedLeft && selectedRight && selectedUp && selectedDown)
        {
            straightTrack.SetActive(false);
            finishTrack.SetActive(false);
            turnTrack.SetActive(false);
            threeWayIntersection.SetActive(false);
            fourWayIntersection.SetActive(true);
            threeWayIntersection.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
