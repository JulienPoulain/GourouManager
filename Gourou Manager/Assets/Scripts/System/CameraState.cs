using System;

[Flags]
public enum CameraState
{
    None = 0,
    
    // VUES
    IslandView = 1<<0,
    InstitutionView = 1<<1,
    
    // COMPORTEMENTS
    Spring = 1<<2,
    Transition = 1<<3,
    
    // GROUPES
    Views = IslandView | InstitutionView,
    Behaviours = Spring | Transition,
    
    // TOUT
    All = Views | Behaviours
}
