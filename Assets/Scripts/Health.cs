using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Health : MonoBehaviour
{
    public const int maxHealth = 20;
    public static int currentHealth = maxHealth;

    private Animator anim;
    private Rigidbody2D rb2d;
    private 

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
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        Health.currentHealth = Health.maxHealth;
        SceneManager.LoadScene(1);
    }
}