public enum Decay
{
    Devoue,
    Complaisant,
    Indifferent,
    Mefiant,
    Hostile
}

static class DecayMethode
{
    public static string GetString(this Decay p_decay) => p_decay switch
    {
        Decay.Devoue => "Dévoué",
        Decay.Complaisant => "Complaisant",
        Decay.Indifferent => "Indifférent",
        Decay.Mefiant => "Méfiant",
        Decay.Hostile => "Hostile",
        _ => "ERROR"
    };

    public static int lvlMin(this Decay p_decay) => p_decay switch
    {
        Decay.Devoue => 85,
        Decay.Complaisant => 56,
        Decay.Indifferent => 45,
        Decay.Mefiant => 26,
        Decay.Hostile => 0,
        _ => -1
    };

    public static int lvlMax(this Decay p_decay) => p_decay switch
    {
        Decay.Devoue => 100,
        Decay.Complaisant => 84,
        Decay.Indifferent => 55,
        Decay.Mefiant => 44,
        Decay.Hostile => 25,
        _ => 101
    };
}
