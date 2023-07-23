using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    LevelManagerScript levelManagerScript;
    bool isMouseOn = false;

    bool isFound = false;
    [SerializeField] Sprite foundSprite;

    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject fixParticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        levelManagerScript = FindObjectOfType<LevelManagerScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isMouseOn);
    }
    private void OnMouseEnter()
    {
        isMouseOn = true;
    }
    private void OnMouseExit()
    {
        isMouseOn = false;
    }
    private void OnMouseDown()
    {
        if (isMouseOn)
        {
            if (!isFound)
            {
                OnFound();
            }
        }
    }

    private void OnFound()
    {
        Vector2 clickPos = new Vector2(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Instantiate(fixParticlePrefab, clickPos, Quaternion.identity);
        levelManagerScript.ThingFound();
        isFound = true;
        spriteRenderer.sprite = foundSprite;
    }
}
