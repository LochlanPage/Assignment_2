using UnityEngine;

public class FriendAnimator : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    private Friend friend;

    private void Start()
    {
        friend = GetComponent<Friend>();
    }

    private void LateUpdate()
    {
        if (friend.friendWaving)
        {
            Wave();
        }
        else
            animator.SetBool("Wave", false);
    }

    private void Wave()
    {
        animator.SetBool("Wave", true);
    }
}
