using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public Sprite sprite1;
    public Sprite sprite2;
    public Transform chestTop;
    public Transform item;
    public Vector3 position = new Vector3(0, 0, 0);
    public Vector3 scale = new Vector3(0, 0, 0);

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = sprite1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Chest open!");
            if (spriteRenderer.sprite == sprite1)
            {
                spriteRenderer.sprite = sprite2;
                chestTop.localScale = scale;
                position = gameObject.transform.position - new Vector3(0, 1, 0);
                Instantiate(chestTop, position, Quaternion.identity);
                Instantiate(item, transform.position, Quaternion.identity);
            }
            else
            {
                spriteRenderer.sprite = sprite2;
            }
        }
    }
}
