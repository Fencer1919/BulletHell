using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button2 : MonoBehaviour
{
 public void FinishScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
