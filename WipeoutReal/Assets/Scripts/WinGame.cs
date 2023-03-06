using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider _other)
    {
        if(_other.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            CharacterMovement player = _other.GetComponentInParent<CharacterMovement>();

            if(player != null && !player.win)
            {
                player.WinGame();
                SceneManager.LoadSceneAsync("Victory", LoadSceneMode.Additive);
            }
        }
    }
}
