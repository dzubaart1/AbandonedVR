using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalCntrl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            SceneManager.LoadScene("SecondLevelScene");
        }
    }
}
