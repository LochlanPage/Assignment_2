using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    private WaveCharacter waveCharacter;

    private void Awake()
    {
        waveCharacter = GetComponent<WaveCharacter>();

        waveCharacter.onWave += waveCharacter_onWave;
    }

    private void waveCharacter_onWave()
    {
        animator.SetTrigger("Wave");
    }

    private void LateUpdate()
    {
        animator.SetFloat("Speed", waveCharacter.speed);
    }
}
