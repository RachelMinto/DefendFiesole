using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Remember to use UI!
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour {
    [SerializeField] int stars = 100;
    Text starText;

	// Use this for initialization
	void Start () {
        starText = GetComponent<Text>();
        UpdateDisplay();
	}
	
	// Update is called once per frame
	private void UpdateDisplay () {
        starText.text = stars.ToString();
	}

    public void AddStars(int amount) {
        stars += amount;
        UpdateDisplay();
    }

    public bool HaveEnoughStars(int amount) {
        return stars >= amount;
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount) {
            stars -= amount;
            UpdateDisplay();            
        }
    }
}
