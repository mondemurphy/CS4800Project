using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public const int maxHealth = 100;
    public static int currentHealth = maxHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public bool damaged;
    public AudioClip dead;

    private Animator anim;
    private Rigidbody2D rb2d;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if (currentHealth <= 0)
        {
            PlaySound();
        }

        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
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

    void PlaySound()
    {
        if (!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = dead;
            GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        Health.currentHealth = Health.maxHealth;
        SceneManager.LoadScene(1);
    }
}