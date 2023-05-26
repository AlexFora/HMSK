using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BuildingMenu : MonoBehaviour
{
    public TMP_Text _buildingInfoText; // drag and drop the TMP UI Text object in the inspector
    [SerializeField] private string _houseName;
    [SerializeField] private string _houseNumber;
    [SerializeField] private string _street;
    [SerializeField] private string _area;
    [SerializeField] private string _cost;
    [SerializeField] private string _owner;
    [SerializeField] private string _propertyType;

    [SerializeField] private GameObject _building;
    [SerializeField] private int _numberShowRoom;

    public string urlToOpen;

    public void GetInfo()
    {
        _buildingInfoText.text = "Название здания: " + _houseName +
            "\nНомер дома: " + _street +
            "\nУлица: " + _street +
            "\nПлощадь: " + _area +
            "\nЦена: " + _cost +
            "\nВладелец: " + _owner +
            "\nТип недвижимости: " + _propertyType;
    }
    private void Start()
    {
        GetInfo();
    }

    public void DestroyBuilding()
    {
        Destroy(_building);
    }

    public void Inter()
    {
        if (_numberShowRoom != -1)
        {
            SceneManager.LoadScene(_numberShowRoom);
        }
    }

    //public void InterOnLink()
    //{
    //    Application.OpenURL(urlToOpen);
    //}


    public void InterOnLink()
    {
        if (urlToOpen != "-1")
        {
            Application.OpenURL(urlToOpen);
            SceneManager.LoadScene(0);
        }
    }
}

