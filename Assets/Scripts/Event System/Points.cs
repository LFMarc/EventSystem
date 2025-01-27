using UnityEngine;
using System;

public class Points : MonoBehaviour
{    
    #region Properties
	public int CurrentPoints { get; set; }
    public int CurrentLevel { get; set; } = 1;

    public event Action OnGetPoints;
    public event Action OnLevelChanged;

	private const int PointsPerLevel = 100;

    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
		CurrentPoints = 0;
    }

	//private void Update()
	//{
	//	if (Input.GetKeyUp(KeyCode.Escape))
	//		AddPoints(200);
	//}
	#endregion

	#region Public Methods
	public void AddPoints(int pointsToAdd)
	{
		CurrentPoints += pointsToAdd;
        Debug.Log("Puntos actuales: " + CurrentPoints);

        OnGetPoints?.Invoke();
    }

    public void TryLevelUp()
    {
        if (CurrentPoints >= PointsPerLevel * CurrentLevel)
        {
            LevelUp();
        }
        else
        {
            Debug.Log("No tienes suficientes puntos para subir de nivel.");
        }
    }

    public void LevelUp()
    {
        CurrentLevel++;
        Debug.Log("¡Has subido al nivel " + CurrentLevel + "!");

        OnLevelChanged?.Invoke();
    }
    #endregion
}
