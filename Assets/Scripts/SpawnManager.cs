using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of spawn points
    public GameObject playerPrefab; // The player prefab
    public Button[] spawnPointButtons; // Array of buttons
    [SerializeField] private GameObject _mapPanel; // The player prefab

    private GameObject _player;

    public AudioSource musicAudioSource;
    public AudioClip musicClip;


    private void Start()
    {
        // Check if the player has already selected a spawn point
        int selectedSpawnPointIndex = PlayerPrefs.GetInt("SelectedSpawnPoint", -1);

        selectedSpawnPointIndex = -1;

        if (selectedSpawnPointIndex >= 0 && selectedSpawnPointIndex < spawnPoints.Length)
        {
            // Spawn the player at the selected spawn point
            //SpawnPlayer(selectedSpawnPointIndex);

        }
        else
        {
            // Show the spawn selection menu
            ShowSpawnSelectionMenu();
            _mapPanel.SetActive(true);
        }
    }

    // Function to show the spawn selection menu
    private void ShowSpawnSelectionMenu()
    {
        // Enable the spawn point buttons
        foreach (Button button in spawnPointButtons)
        {
            button.gameObject.SetActive(true);

            // Add a listener to each button to spawn the player at the corresponding spawn point when clicked
            int spawnPointIndex = System.Array.IndexOf(spawnPointButtons, button);
            button.onClick.AddListener(() => {
                SpawnPlayer(spawnPointIndex);
            });
        }
    }

    // Function to spawn the player at a specified spawn point
    public void SpawnPlayer(int spawnPointIndex)
    {
        _mapPanel.SetActive(false);
        // Disable the spawn point buttons
        foreach (Button button in spawnPointButtons)
        {
            button.gameObject.SetActive(false);
        }

        // Play the music clip


        if (_player == null)
        {
            _player = Instantiate(playerPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
            musicAudioSource.clip = musicClip;
            musicAudioSource.Play();

        }
        else
        {
            // Move the existing player to the selected spawn point
            _player.transform.position = spawnPoints[spawnPointIndex].position;
        }


            // Instantiate the player prefab at the selected spawn point
            //GameObject player = Instantiate(playerPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);

            // Save the selected spawn point
            PlayerPrefs.SetInt("SelectedSpawnPoint", spawnPointIndex);
        PlayerPrefs.Save();
    }
}
