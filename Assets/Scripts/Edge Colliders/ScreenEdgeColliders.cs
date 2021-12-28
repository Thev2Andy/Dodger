using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ScreenEdgeColliders : MonoBehaviour
{
    private GameObject Left;
    private GameObject Right;
 
    private void Awake()
    {
        Left = new GameObject("Left");
        Left.tag = "Bounds";

        Right = new GameObject("Right");
        Right.tag = "Bounds";
    }
 
 
    private void Start() {
        CreateScreenColliders();
	}
 
 
    private void CreateScreenColliders()
    {
        Vector3 bottomLeftScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 topRightScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        BoxCollider2D collider;
 
        // Create left collider
        collider = Left.AddComponent<BoxCollider2D>();
        collider.size = new Vector3(0.1f, Mathf.Abs(topRightScreenPoint.y - bottomLeftScreenPoint.y), 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);
 
        // Left needs to account for collider size
        Left.transform.position = new Vector3(((bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f) - collider.size.x, bottomLeftScreenPoint.y, 0f);
 
 
        // Create right collider
        collider = Right.AddComponent<BoxCollider2D>();
        collider.size = new Vector3(0.1f, Mathf.Abs(topRightScreenPoint.y - bottomLeftScreenPoint.y), 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);
 
        Right.transform.position = new Vector3(topRightScreenPoint.x, bottomLeftScreenPoint.y, 0f);
    }
 }