using UnityEngine; 

public class GardenEndEffect : EventCardEffect
{
    public override void BodyTrigger()
    {
        base.BodyTrigger();

        DeckManager.instance.SubmitRun();
    }

    public override void MindTrigger()
    {
        base.MindTrigger();
        DeckManager.instance.SubmitRun();
    }
}