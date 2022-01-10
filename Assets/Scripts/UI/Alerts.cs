using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Alerts 
{
    public IEnumerator CreateNewAlert(string msg)
    {
      yield return  SceneManager.LoadSceneAsync("Alert", LoadSceneMode.Additive);
        GameObject.FindObjectOfType<AlertObject>().AlertText.text = msg;
     
    }

   /* IEnumerator UpdateText(string msg)
    {
        yield return new WaitForSeconds(.3f);
        GameObject.FindGameObjectWithTag("AlertMsg").GetComponent<AlertObject>().AlertText.text = msg;
    }
   */
}
