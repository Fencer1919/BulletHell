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

        // Sağlık sıfır olduğunda FinishScene sahnesine geçiş yap
        if (GameController.Health <= 0)
        {
            Debug.Log("Health is zero, switching to FinishScene...");
            SceneManager.LoadScene("FinishScene");
        }
    }
}
