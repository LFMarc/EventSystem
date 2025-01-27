using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private GameObject _charmander;
    [SerializeField] private GameObject _charmeleon;
    [SerializeField] private GameObject _charizard;



    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Public Methods
    public void UpdateSliderLife(float currentLife)
    {
        _slider.value = currentLife;
    }
    public void UpdatePoints(int currentPoints)
    {
        _pointsText.text = currentPoints.ToString();
    }
    public void UpdateLevel(int currentLevel)
    {
        // Actualiza el texto del nivel
        _levelText.text = currentLevel.ToString();
        #endregion

        #region Private Methods
        #endregion
    }

    public void Stage1()
    {
        _charmander.gameObject.SetActive(false);
        _charmeleon.gameObject.SetActive(true);
    }

    public void Stage2()
    {
        _charmeleon.gameObject.SetActive(false);
        _charizard.gameObject.SetActive(true);
    }
}
