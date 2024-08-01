using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthUIController : MonoBehaviour
{
    public GameObject heartContainer;
    private float fillValue;

    void Update()
    {
        // Sağlık durumunu UI'ye yansıt
        fillValue = (float)GameController.Health;
        fillValue = fillValue / GameController.MaxHealth;
        heartContainer.GetComponent<Image>().fillAmount = fillValue;

        // Sağlık sıfır olduğunda oyunu yeniden başlat
        if (GameController.Health <= 0)
        {
            Debug.Log("Health is zero, restarting game...");
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Mevcut sahneyi yeniden yükle
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("Restarting scene: " + currentScene.name);
        SceneManager.LoadScene(currentScene.name);
    }
}
