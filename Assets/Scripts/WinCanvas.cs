using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCanvas : MonoBehaviour
{

   public void ChangState(bool state)
   {
      gameObject.SetActive(state);
   }
   
   public void ContinueButtonInteraction()
   {
      SceneManager.LoadSceneAsync(0);
   }
}
