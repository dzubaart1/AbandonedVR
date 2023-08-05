using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveCntrl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            SceneManager.LoadScene("FirstScene");
        }
    }
}
