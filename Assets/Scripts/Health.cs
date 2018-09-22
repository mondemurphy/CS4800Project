using UnityEngine;

public class Health : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;

    private Animator anim;
    private Rigidbody2D rb2d;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        anim.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            anim.SetBool("Dead", true);
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            Debug.Log("Dead!");
        }
    }
}