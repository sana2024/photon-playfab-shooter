using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    public InputField username;
    public InputField Password;
    public InputField ConPassword;
    public InputField Email;

    public void CreateAccount()
    {
        if(Password.text == ConPassword.text)
        {
            RegisterPlayFabUserRequest request =new RegisterPlayFabUserRequest();
            request.Username = username.text;
            request.Password = Password.text;
            request.Email = Email.text;
            request.DisplayName = username.text;

            PlayFabClientAPI.RegisterPlayFabUser(request, result =>
            {
                Alerts a = new Alerts();
                StartCoroutine(a.CreateNewAlert(result.Username + " Has been created!"));

            }, error =>
            {
                Alerts a =new Alerts();
                StartCoroutine(a.CreateNewAlert(error.ErrorMessage));

            });
        }
    }
}
