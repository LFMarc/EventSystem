using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    [SerializeField] private InputSystem _inputs;
    [SerializeField] private Points _points;
    [SerializeField] private Health _payerHealth;
    [SerializeField] private UIController _ui;
    [SerializeField] private SoundController _sound;
    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
		//Event Listener
		//_payerHealth.OnGetDamage += OnGetDamage;
		//_payerHealth.OnGetHeal += OnGetHeal;
		_payerHealth.OnDie += OnDie;
		//_points.OnGetPoints += OnAddPoints;

		_inputs.OnKeyDamage += OnGetDamage;
        _inputs.OnKeyHeal += OnGetHeal;
		_inputs.OnKeyPoints += OnAddPoints;
        _inputs.OnKeyAddLevel += OnGetLevel;
    }

    //private void _inputs_OnKeyHeal()
    //{
    //    throw new NotImplementedException();
    //}

    #endregion

    #region Private Methods
    private void OnGetDamage()
	{
        Debug.Log("Evento Damage Escuchado");
		_payerHealth.GetDamage(20);
        _sound.PlayDamageSound();
		_ui.UpdateSliderLife(_payerHealth.CurrentHealth);
	}
	private void OnGetHeal()
	{
		Debug.Log("Evento Heal Escuchado");
		_payerHealth.GetHeal(20);
		_ui.UpdateSliderLife(_payerHealth.CurrentHealth);
	}
	private void OnDie()
	{
		_sound.PlayDieSound();
		Destroy(_payerHealth.gameObject);
	}
	private void OnAddPoints()
	{
        Debug.Log("Evento Points Escuchado");
        int randomPoints = UnityEngine.Random.Range(5, 101);
        Debug.Log("Se añaden puntos aleatorios: " + randomPoints);
        _points.AddPoints(randomPoints);
        _ui.UpdatePoints(_points.CurrentPoints);
	}

    private void OnGetLevel()
    {
        Debug.Log("Evento Try Level Up Escuchado");
        _points.TryLevelUp();

        if (_points.CurrentLevel > 15)
        {
            _ui.Stage1();
            _sound.PlayEvoSound();
        }

        if (_points.CurrentLevel > 35)
        {
            _ui.Stage2();
            _sound.PlayEvoSound();
        }
        _sound.PlayLevelSound();

        _ui.UpdateLevel(_points.CurrentLevel);
    }
    #endregion
}
