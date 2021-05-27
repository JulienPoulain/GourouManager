public enum DecayLvl
{
    None = 0,
    Devoue,
    Complaisant,
    Indifferent,
    Mefiant,
    Hostile
}

namespace DecayLvlMethods
{
    static class DecayLvlExtensions
    {
        public static string GetString(this DecayLvl p_decayLvl) => p_decayLvl switch
        {
            DecayLvl.Devoue => "Dévoué",
            DecayLvl.Complaisant => "Complaisant",
            DecayLvl.Indifferent => "Indifférent",
            DecayLvl.Mefiant => "Méfiant",
            DecayLvl.Hostile => "Hostile",
            _ => "None"
        };

        public static int lvlMin(this DecayLvl p_decayLvl) => p_decayLvl switch
        {
            DecayLvl.Devoue => 85,
            DecayLvl.Complaisant => 56,
            DecayLvl.Indifferent => 45,
            DecayLvl.Mefiant => 26,
            DecayLvl.Hostile => 0,
            _ => -1
        };

        public static int lvlMax(this DecayLvl p_decayLvl) => p_decayLvl switch
        {
            DecayLvl.Devoue => 100,
            DecayLvl.Complaisant => 84,
            DecayLvl.Indifferent => 55,
            DecayLvl.Mefiant => 44,
            DecayLvl.Hostile => 25,
            _ => -1
        };
    }
}
