using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider _other)
    {
        if(_other.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            _other.GetComponentInParent<CharacterMovement>().WinGame();
            SceneManager.LoadSceneAsync("Victory");
        }
    }
}
