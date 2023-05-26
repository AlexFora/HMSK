using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderMenu : MonoBehaviour
{

    public string sceneToLoad; // Название сцены, которую нужно загрузить
    [SerializeField] GameObject _player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            _player.SetActive(false);
            LoadSceneThis();
        }
    }

    private void LoadSceneThis()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
