using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] private GameObject _loader;
    public string sceneToLoad; // Название сцены, которую нужно загрузить

    public void Start()
    {
        _loader.SetActive(false);
    }

    private IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("1 second has passed");
    }


    public void LoadScene()
    {
        _loader.SetActive(true);
        StartCoroutine(WaitOneSecond());
    }
}