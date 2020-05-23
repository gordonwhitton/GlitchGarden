using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private float offset = 0.5f;

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(! defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        //Debug.Log("mouse was clicked");
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPosition)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        if(starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPosition);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        float newX = Mathf.FloorToInt(rawWorldPosition.x) + offset;
        float newY = Mathf.FloorToInt(rawWorldPosition.y) + offset;

        Debug.Log("Raw " + rawWorldPosition.x + " " + rawWorldPosition.y);
        Debug.Log("New " + newX + " " + newY);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPosition)
    {
        Defender newDefender = Instantiate(defender, worldPosition, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform; //makes it a child to the parent
    }
}
