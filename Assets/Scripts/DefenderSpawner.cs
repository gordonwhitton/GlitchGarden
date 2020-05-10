using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    Defender defender;

    private float offset = 0.5f;

    private void OnMouseDown()
    {
        //Debug.Log("mouse was clicked");
        SpawnDefender(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        //float newX = Mathf.RoundToInt(rawWorldPosition.x)+0.5f;// + offset;
        //float newY = Mathf.RoundToInt(rawWorldPosition.y)+1f;// + offset - 0.5f;


        float yOffset;

        if(defender.name == "Trophy")
        {
            yOffset = 0.5f;
        } else
        {
            yOffset = 0.5f;
        }
        float newX = Mathf.FloorToInt(rawWorldPosition.x) + 0.5f;// + offset;

        float newY = Mathf.FloorToInt(rawWorldPosition.y) + yOffset;// + offset - 0.5f;

        Debug.Log("Raw " + rawWorldPosition.x + " " + rawWorldPosition.y);
        Debug.Log("New " + newX + " " + newY);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPosition)
    {
        Defender newDefender = Instantiate(defender, worldPosition, Quaternion.identity) as Defender;
    }
}
