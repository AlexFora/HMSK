using UnityEngine;
using TMPro;

public class BuildingDetection : MonoBehaviour
{
    private bool buildingDetectionMode = false;
    private BuildingMenu[] buildingScripts;
    private Outline[] outLines;
    //private Outline _outLines;

    //private Material buildingMaterial;
    //private Color originalColor;
    private bool _activOutline;
    private bool _activbuildingScripts;
    [SerializeField] private TMP_Text _buildingDetectionText;
    [SerializeField] private TMP_Text _buildingMenuText;
    [SerializeField] private GameObject _buildingMenu;
    [SerializeField] private GameObject _cursorOn;

    //public Texture2D cursorTexture;
    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotSpot = Vector2.zero;


    private bool _isDetectionActive = false;
    private bool _buildingMenuActive = false;
    private Collider lastCollider;


    public delegate void BuildingMenuDelegate();
    private BuildingMenuDelegate buildingMenuDelegate;

    void Start()
    {
        _buildingMenu.SetActive(false);
        buildingScripts = FindObjectsOfType<BuildingMenu>();
        outLines = FindObjectsOfType<Outline>();
        //DisableBuildingDetection();
        //originalColor = Color.white;
    }

    void Update()
    {
        foreach (var outline in outLines)
        {
            outline.enabled = false;

        }

        foreach (var buildingScript in buildingScripts)
        {
            buildingScript.enabled = false;

        }

        if (Input.GetKeyDown("tab"))
        {
            _isDetectionActive = !_isDetectionActive;
            _cursorOn.SetActive(_isDetectionActive);
        }

        if (_isDetectionActive)
        {
            _buildingDetectionText.text = "Режим информации об объектах включен";

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Building"))
                {
                    if (hit.collider.GetComponent<Outline>() != null)
                    {
                        hit.collider.GetComponent<Outline>().enabled = _activOutline;
                        _activOutline = true;
                    }

                    if (hit.collider.GetComponent<BuildingMenu>() != null)
                    {
                        hit.collider.GetComponent<BuildingMenu>().enabled = _activbuildingScripts;
                        _activbuildingScripts = true;
                        BuildingMenu buildingMenu = hit.collider.GetComponent<BuildingMenu>();
                        buildingMenu.GetInfo();

                        if (Input.GetKeyDown(KeyCode.Mouse0))
                        {

                            if (buildingMenu != null)
                            {

                                buildingMenu._buildingInfoText = _buildingMenuText;
                            }

                            if (buildingMenu != null)
                            {

                                buildingMenu._buildingInfoText = _buildingMenuText;
                            }
                            _buildingMenu.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                _buildingMenu.SetActive(false);

                foreach (var outline in outLines)
                {
                    outline.enabled = false;

                }

                foreach (var buildingScript in buildingScripts)
                {
                    buildingScript.enabled = false;

                }
            }
        }
        else
        {
            _buildingDetectionText.text = "";
            _buildingMenu.SetActive(false);

        }


        if (_buildingMenu.active == true)
        {
            StopCameraRotation();
        }
        
    }


    public void ButtonInterBuilding()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<BuildingMenu>() != null)
            {
                _buildingMenu.SetActive(false);

                foreach (var outline in outLines)
                {
                    outline.enabled = false;

                }

                foreach (var buildingScript in buildingScripts)
                {
                    buildingScript.enabled = false;

                }
                _isDetectionActive = false;
                _buildingDetectionText.text = "";

                StartCameraRotation();

                buildingMenuDelegate = hit.collider.GetComponent<BuildingMenu>().Inter;
            }
        }

        if (buildingMenuDelegate != null)
        {
            buildingMenuDelegate();
        }

    }


    public void ButtonInterURL()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<BuildingMenu>() != null)
            {
                _buildingMenu.SetActive(false);

                foreach (var outline in outLines)
                {
                    outline.enabled = false;

                }

                foreach (var buildingScript in buildingScripts)
                {
                    buildingScript.enabled = false;

                }
                _isDetectionActive = false;
                _buildingDetectionText.text = "";

                StartCameraRotation();

                buildingMenuDelegate = hit.collider.GetComponent<BuildingMenu>().InterOnLink;
            }
        }

        if (buildingMenuDelegate != null)
        {
            buildingMenuDelegate();
        }

    }


    public void ButtonDestroyBuilding()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<BuildingMenu>() != null)
            {
                _buildingMenu.SetActive(false);
                //StartCameraRotation();
                //Cursor.SetCursor(null, Vector2.zero, cursorMode);
                //Cursor.visible = false;

                foreach (var outline in outLines)
                {
                    outline.enabled = false;

                }

                foreach (var buildingScript in buildingScripts)
                {
                    buildingScript.enabled = false;

                }
                _isDetectionActive = false;
                _buildingDetectionText.text = "";
                //StartCameraRotation();
                //Cursor.SetCursor(null, Vector2.zero, cursorMode);
                //Cursor.visible = false;
                //_buildingMenu.SetActive(false);

                StartCameraRotation();

                buildingMenuDelegate = hit.collider.GetComponent<BuildingMenu>().DestroyBuilding;
                //BuildingMenu buildingMenu = hit.collider.GetComponent<BuildingMenu>();
                //buildingMenuDelegate = buildingMenu.DestroyBuilding;
            }
        }

        if (buildingMenuDelegate != null)
        {
            buildingMenuDelegate();
        }

    }



    private void StopCameraRotation()
    {
        // Находим камеру по тегу "MainCamera"
        Camera mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        // Получаем компонент "FirstPersonLook" у камеры
        FirstPersonLook firstPersonLook = mainCamera.GetComponent<FirstPersonLook>();

        // Если компонент найден, отключаем вращение
        if (firstPersonLook != null)
        {
            firstPersonLook.enabled = false;
        }
    }

    public void StartCameraRotation()
    {
        //Camera mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Camera mainCamera = GameObject.FindGameObjectWithTag("MainCamera")?.GetComponent<Camera>();

        if (mainCamera != null)
        {
            // Находим камеру по тегу "MainCamera"


            // Получаем компонент "FirstPersonLook" у камеры
            FirstPersonLook firstPersonLook = mainCamera.GetComponent<FirstPersonLook>();

            // Если компонент найден, включаем вращение
            if (firstPersonLook != null)
            {
                firstPersonLook.enabled = true;
            }
        }
    }
}
