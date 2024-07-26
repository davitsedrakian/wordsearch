using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
   public void StartButtonInteraction()
   {
      LevelManager.instance.CreateLevel();
   }
}
