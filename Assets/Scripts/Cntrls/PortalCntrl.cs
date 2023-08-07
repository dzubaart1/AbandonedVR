using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cntrls
{
    public class PortalCntrl : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                SceneManager.LoadScene(_sceneName);
            }
        }
    }
}
