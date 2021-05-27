using MyNamespace;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDecay", menuName = "GourouManager/Ressource/Corruption")]
public class DecaySO : SyncIntSO
{
    public override int Value
    {
        get => m_value;
        set => m_value = Mathf.Clamp(value, 0, 100);
    }

    public void Test()
    {
        int i = 10;
        int dl = DecayLvl.Complaisant.lvlMax();
        DecayLvl.Complaisant.GetDecayLvl(10);
        DecayLvl dl2 = DecayLvlExtension.GetDecayLvl(DecayLvl.Complaisant, 10);
    }
}
