using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;
    public PlayerHealth healthPlayer;
    public Gradient lifeColorGradient;


    // Update is called once per frame
    void Update()
    {
        float lifeRatio = ((float) healthPlayer.currentLifePoints / (float) healthPlayer.maxLifePoints);
        fillImage.fillAmount = lifeRatio;
        fillImage.color = lifeColorGradient.Evaluate(lifeRatio);
        
    }
}
