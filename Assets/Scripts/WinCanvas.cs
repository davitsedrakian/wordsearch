using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCanvas : MonoBehaviour
{

   public void ChangState(bool state)
   {
      GetComponent<Canvas>().enabled = state;
   }
   
   public void ContinueButtonInteraction()
   {
      Debug.LogError("Continue button clicked");
      SceneManager.LoadScene(0);
   }
}
