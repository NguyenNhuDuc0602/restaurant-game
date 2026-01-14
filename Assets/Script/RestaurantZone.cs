using UnityEngine;

public class RestaurantZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            GameManager.I.isInRestaurantZone = true;
            GameManager.I.ShowHint("Bạn đang ở nhà hàng. Bấm nút để nâng cấp!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            GameManager.I.isInRestaurantZone = false;
            GameManager.I.ShowHint("Rời nhà hàng. Đi bắt vịt kiếm tiền!");
        }
    }
}
