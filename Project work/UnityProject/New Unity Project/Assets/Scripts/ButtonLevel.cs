using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonLevel : MonoBehaviour {

    public int SceneID;

   public void LoadLevel() {
        SceneManager.LoadScene(SceneID);
    }

}
