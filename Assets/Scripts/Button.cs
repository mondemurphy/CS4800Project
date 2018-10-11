using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public Sprite sprite1;
    public Sprite sprite2;
    public Transform prefab;
    public Vector3 position = new Vector3(0, 0, 0);
    public Vector3 scale = new Vector3(0, 0, 0);
    
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = sprite1;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Button push!");
            if (spriteRenderer.sprite == sprite1)
            {
                spriteRenderer.sprite = sprite2;
                prefab.localScale = scale;
                Instantiate(prefab, position, Quaternion.identity);
            }
            else
            {
                spriteRenderer.sprite = sprite2;
            }
        }
    }
}
