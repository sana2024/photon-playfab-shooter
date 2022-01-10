using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
     public void Create()
    {
        SceneManager.LoadScene("Register", LoadSceneMode.Additive);
    }

    public void Login()
    {
        SceneManager.LoadScene("Login", LoadSceneMode.Additive);
    }
}
