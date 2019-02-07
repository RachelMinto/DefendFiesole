using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    Defender defender;
    GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent() {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown() {
        Vector2 locationClicked = GetSquareClicked();
        AttemptToPlaceDefender(locationClicked);
    }

    public void SetSelectedDefender(Defender defenderToSelect) {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefender(Vector2 gridPos) {
        if (!defender) { return; }
        var StarDisplay = FindObjectOfType<StarsDisplay>();
        int defenderCost = defender.GetStarCost();

        if (StarDisplay.HaveEnoughStars(defenderCost) && !DefenderInSquare(gridPos)) {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
    }

    private bool DefenderInSquare(Vector2 gridPos) {
        bool squareIsOccupied = false;
        Defender[] placedDefenders = FindObjectsOfType<Defender>();
        foreach(Defender placedDefender in placedDefenders) {
            Vector2 defenderVector2Pos = new Vector2(placedDefender.transform.position.x, placedDefender.transform.position.y);
            Vector2 snappedGridPos = new Vector2(Mathf.RoundToInt(gridPos.x), Mathf.RoundToInt(gridPos.y));
            if (defenderVector2Pos == snappedGridPos) {
                squareIsOccupied = true;
            }
        }
        return squareIsOccupied;
    }

    private Vector2 GetSquareClicked() {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    private Vector2 SnapToGrid(Vector2 coordinates) {
        float newX = Mathf.RoundToInt(coordinates.x);
        float newY = Mathf.RoundToInt(coordinates.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPos) {
        Vector2 snappedWorldPos = SnapToGrid(worldPos);
        Defender newDefender = Instantiate(
            defender,
            snappedWorldPos,
            Quaternion.identity
        );

        newDefender.transform.parent = defenderParent.transform;
    }
}
