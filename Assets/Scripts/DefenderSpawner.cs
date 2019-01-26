using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    Defender defender;

    private void OnMouseDown() {
        Vector2 locationClicked = GetSquareClicked();
        AttemptToPlaceDefender(locationClicked);
    }

    public void SetSelectedDefender(Defender defenderToSelect) {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefender(Vector2 gridPos) {
        var StarDisplay = FindObjectOfType<StarsDisplay>();
        int defenderCost = defender.GetStarCost();

        if (StarDisplay.HaveEnoughStars(defenderCost)) {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
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
        ) as Defender;
    }
}
