using System.Collections;
using TMPro;
using UnityEngine;

public class playerVie : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private IntVariable currentLifePoints;

    [SerializeField]
    private IntVariable maxLifePoints;

    [SerializeField]
    private TextMeshProUGUI currentLifePointsText;

    [SerializeField]
    private bool isInvulnerable;

    [SerializeField]
    private VoidEventChannel OnTakeDamages;

    [SerializeField]
    private SpriteRenderer sr;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentLifePoints.CurrentValue = maxLifePoints.CurrentValue;
        currentLifePointsText.SetText(currentLifePoints.ToString());
    }

    public void TakeDamage(int damage = 1)
    {
        // Mathf.Clamp permet de limiter la valeur entre deux bornes
        currentLifePoints.CurrentValue = Mathf.Clamp(currentLifePoints.CurrentValue - 1, 0, maxLifePoints.CurrentValue);

        if (currentLifePoints.CurrentValue == 0)
        {
            Debug.Log("Game over");
        }

        if (isInvulnerable)
        {
            return;
        }
        isInvulnerable = true;
    }

    // Update is called once per frame

    IEnumerator InvulnerableDuration()
    {
        isInvulnerable = true;
        float duration = 1.25f;
        float timeElapsed = 0f;
        float flashDuration = 0.2f;
        float flashTimeElapsed = 0f;
        Debug.Log("End");

        bool isVisible = true;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            flashTimeElapsed += Time.deltaTime;
            if (flashTimeElapsed >= flashDuration)
            {
                if (isVisible)
                {
                    sr.color = Color.clear;
                }
                else
                {
                    sr.color = Color.white;
                }
                flashTimeElapsed = 0f;
                isVisible = !isVisible;
            }

            yield return null;
        }
        sr.color = Color.white;
        isInvulnerable = false;
    }

    void Update()
    {

    }
}
