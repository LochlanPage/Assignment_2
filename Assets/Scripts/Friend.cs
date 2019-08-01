using System.Collections;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    float fieldOfView = 10f;

    public bool friendWaving = false;

    [SerializeField]
    ParticleSystem friendship_Particle;

    [SerializeField]
    GameObject particle_Spawn;

    [SerializeField]
    bool hasWaved = false;

    void Update()
    {
        FriendCheck();
    }

    private void FriendCheck()
    {
        Vector3 targetDir = target.position - transform.position;
        Vector3 forward = transform.forward;
        
        float angle = Vector3.Angle(targetDir, forward);
        if (angle < fieldOfView)
        {
            if (WaveCharacter.waving)
            {
                StartCoroutine(Wave());

                if (hasWaved == false)
                {
                    Instantiate(friendship_Particle, particle_Spawn.transform.position, particle_Spawn.transform.rotation);
                    hasWaved = true;
                }                
            }
        }
    }

    private IEnumerator Wave()
    {
        friendWaving = true;

        yield return new WaitForSeconds(2);
        friendWaving = false;
        hasWaved = false;
    }
}
