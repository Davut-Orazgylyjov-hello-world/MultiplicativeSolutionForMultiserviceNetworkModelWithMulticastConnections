using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsLogic : MonoBehaviour
{
   public void RestartScene()
   {
      Scene scene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(scene.name);
   }
}
