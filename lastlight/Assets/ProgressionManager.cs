using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressionManager : Singleton<ProgressionManager>
{
    public void TryAgain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
