using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour 
{
	public Slider slider;
	public AudioSource audioS;
	public AudioClip[] painSounds;
	public Gradient gradient;
	public Image fill;

	public float HealthPoints
	{
		get{return healthPoints;}
		set
		{
			if (painSounds.Length > 0)
            {
				int index = Random.Range(0, painSounds.Length - 1);
				if (!audioS.isPlaying)
                {
					audioS.PlayOneShot(painSounds[index]);
				}
			}

			healthPoints = value;
			slider.value = healthPoints;
			fill.color = gradient.Evaluate(slider.normalizedValue);

			if (healthPoints <= 0)
            {
				Destroy(gameObject);
				GameOverMenu.gameOver = true;
			}
		}
	}

	[SerializeField]
	private float healthPoints = 100f;
}
