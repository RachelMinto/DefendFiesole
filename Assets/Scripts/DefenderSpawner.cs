using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    [SerializeField] GameObject defender;

    private void OnMouseDown() {
        Vector2 locationClicked = GetSquareClicked();
        SpawnDefender(locationClicked);
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
        GameObject newDefender = Instantiate(
            defender,
            snappedWorldPos,
            Quaternion.identity
        );
    }
}
