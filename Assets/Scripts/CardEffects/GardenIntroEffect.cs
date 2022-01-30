public class GardenIntroEffect : EventCardEffect 
{
    private void Awake()
    {
        FindObjectOfType<UIManager>().DescisionResult.text =
            "You wake in a garden it feels familiar and yet...you don’t recall being here. On the left, there is a door that requires a puzzle. The right - a heavy door.";
    }
}
