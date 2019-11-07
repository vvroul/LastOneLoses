using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu_Scripts
{
    public class ChangeScene : MonoBehaviour
    {
        public void GoToScene(int scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
