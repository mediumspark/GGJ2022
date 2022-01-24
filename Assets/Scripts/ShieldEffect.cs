public class ShieldEffect : ItemCardEffect
{
    public override void BodyTrigger()
    {
        PlayerStats.instance.Body += CardBase.BodyMod;
        PlayerStats.instance.Mind -= CardBase.MindMod / 2;

    }

    public override void MindTrigger()
    {
        PlayerStats.instance.Mind += CardBase.MindMod  + CardBase.BodyMod;
    }

    public override void OnUseFromDeck()
    {
        //Does Something when used
    }
}
