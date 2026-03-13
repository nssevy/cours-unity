using UnityEngine.UI;
using UnityEngine;
using System;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private Image image;

    [SerializeField]
    private Gradient gradient;

    [SerializeField]
    private IntVariable currentLifePoint;

    [SerializeField]
    private IntVariable maxLifePoints;

    [SerializeField]
    private VoidEventChannel OnPlayerTakeDammage;



    void OnEnable()
    {
        // Limite le lien entre plusieur class et limite les pertes de performance en faisant appel a une valeur qui ne sera pas mise à jour tout le temp;
        OnPlayerTakeDammage.OnEventRaised += UpdateBar;
    }

    void OnDisable()
    {
        OnPlayerTakeDammage.OnEventRaised -= UpdateBar;

    }

    void UpdateBar()
    {
        SetHealth((float)currentLifePoint.CurrentValue / maxLifePoints.CurrentValue);
    }
    public void SetHealth(float healthNormalized)
    {
        image.fillAmount = healthNormalized;
        image.color = gradient.Evaluate(healthNormalized);
    }
}
