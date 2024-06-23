using UnityEngine;

public class Gold : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncu altını topladığında yapılacak işlemler
            // Örneğin, puan artırma veya ses çalma gibi işlemler eklenebilir
            Debug.Log("Altın toplandı!"); // Konsola mesaj yazdır
            Destroy(gameObject); // Altını yok et
        }
    }
}
