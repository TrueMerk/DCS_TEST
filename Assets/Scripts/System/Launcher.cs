using UnityEngine;
using UnityEngine.SceneManagement;

namespace System
{
    public class Launcher : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene("Game");
        }
    
    }
}
