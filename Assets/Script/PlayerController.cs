using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int maxHealth = 10;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject bombPrefab;
    public GameObject activeItem;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        HandleMovement();
        HandleShooting();
        HandleActions();
    }

    void HandleMovement()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W)) moveY = +1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = +1f;

        Vector3 moveVector = new Vector3(moveX, moveY).normalized;
        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }

    void HandleShooting()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Shoot(Vector2.up);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Shoot(Vector2.down);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Shoot(Vector2.left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Shoot(Vector2.right);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - (Vector2)firePoint.position;
            Shoot(direction.normalized);
        }
    }

    void Shoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
    }

    void HandleActions()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseActiveItem();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.E))
        {
            PlaceBomb();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseSingleUseItem();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMusic();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFullScreen();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ExpandMiniMap();
        }

        if (Input.GetKey(KeyCode.R))
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            DropTrinket();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Oyuncunun ölmesi durumunda yapılacaklar
        Debug.Log("Player Died!");
        // Örneğin, sahneyi yeniden başlatabilirsiniz:
        // UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    void UseActiveItem()
    {
        // Aktif öğeyi kullan
    }

    void PlaceBomb()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }

    void UseSingleUseItem()
    {
        // Tek kullanımlık öğeyi kullan
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void ToggleMusic()
    {
        // Müziği aç/kapat
    }

    void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    void ExpandMiniMap()
    {
        // Mini haritayı genişlet
    }

    void RestartGame()
    {
        // Oyunu yeniden başlat
    }

    void DropTrinket()
    {
        // Trinketi bırak
    }
}
