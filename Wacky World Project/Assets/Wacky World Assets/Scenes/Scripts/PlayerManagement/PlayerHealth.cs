using UnityEngine;

namespace PlayerManagement
{
    public class PlayerHealth : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
                PlayerManager.Instance.Health--;
            if (Input.GetKeyDown(KeyCode.Z))
                PlayerManager.Instance.Health =
                    PlayerManager.Instance.Health + 1 > 3 ? 3 : PlayerManager.Instance.Health + 1;
        }
    }
}