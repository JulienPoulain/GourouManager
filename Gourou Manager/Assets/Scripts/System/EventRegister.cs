using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventRegister : Singleton<EventRegister>
{
    private SortedDictionary<int, Register> m_registers = new SortedDictionary<int, Register>();

    /*public Register this[int p_turn]
    {
        get
        {
            Debug.Log("Dans le get");
            if (!m_registers.ContainsKey(p_turn))
                m_registers[p_turn] = new Register();
            return m_registers[p_turn];
        }
        set
        {
            Debug.Log("Dans le set");
            if (!m_registers.ContainsKey(p_turn))
                m_registers[p_turn] = new Register();
            m_registers[p_turn] = value;
        }
    }*/

    private class Register
    {
        private HashSet<ExactionSO> m_exactions = new HashSet<ExactionSO>();
        private HashSet<EventSO> m_events = new HashSet<EventSO>();

        public HashSet<ExactionSO> Exactions => m_exactions;
        public HashSet<EventSO> Events => m_events;

        public string Summary()
        {
            string str = "";
            
            if (m_exactions.Count == 0)
            {
                str += "Aucune exactions.";
            }
            else
            {
                str += "EXACTIONS : [ ";
                foreach (ExactionSO exaction in m_exactions)
                {
                    str += exaction.name + ", ";
                }
                //str += String.Join(", ", m_exactions);
                str += "]\r";
            }
            
            if (m_exactions.Count == 0)
            {
                str += "Aucune évènements.";
            }
            else
            {
                str += "EVENEMENTS : [ ";
                foreach (EventSO iEvent in m_events)
                {
                    str += iEvent.name + ", ";
                }
                str += "]\r";
            }
            
            return str;
        }
    }

    private void Awake()
    {
        name = "EventRegister";
    }

    public string Summary(int p_turn)
    {
        if (m_registers.ContainsKey(p_turn))
        {
            return m_registers[p_turn].Summary();
        }
        return "Aucune entrée au tour " + p_turn;
    }

    public void AddDay(int p_turn)
    {
        if (!m_registers.ContainsKey(p_turn))
            m_registers.Add(p_turn, new Register());
    }

    /// <summary>
    /// Renvoie les exactions s'étant produit durant le tour précisé.
    /// </summary>
    /// <param name="p_turn">Tour</param>
    /// <returns>Les exactions provoquées au tour p_turn.</returns>
    public List<ExactionSO> GetExactions(int p_turn)
    {
        if (!m_registers.ContainsKey(p_turn))
            return new List<ExactionSO>();
            //m_registers.Add(p_turn, new Register());
        return m_registers[p_turn].Exactions.ToList();
    }

    /// <summary>
    /// Renvoie les évènements ayant eu lieu durant le tour précisé.
    /// </summary>
    /// <param name="p_turn">Tour</param>
    /// <returns>Les évènements ayant eu une activité durant le tour p_turn.</returns>
    public List<EventSO> GetEvents(int p_turn)
    {
        if (!m_registers.ContainsKey(p_turn))
            //m_registers.Add(p_turn, new Register());
            return new List<EventSO>();
        return m_registers[p_turn].Events.ToList();
    }

    /// <summary>
    /// L'exaction p_exaction au registre pour le tour p_turn.
    /// </summary>
    /// <param name="p_turn">Tour</param>
    /// <param name="p_exaction">Exaction</param>
    public void Add(int p_turn, ExactionSO p_exaction)
    {
        if (!m_registers.ContainsKey(p_turn))
            m_registers.Add(p_turn, new Register());
        m_registers[p_turn].Exactions.Add(p_exaction);
    }
    
    /// <summary>
    /// Ajoute l'ensemble d'exactions p_exactions au registre pour le tour p_turn.
    /// </summary>
    /// <param name="p_turn">Tour</param>
    /// <param name="p_exactions">Collection d'exactions</param>
    public void Add(int p_turn, IEnumerable<ExactionSO> p_exactions)
    {
        if (!m_registers.ContainsKey(p_turn))
            m_registers.Add(p_turn, new Register());
        m_registers[p_turn].Exactions.UnionWith(p_exactions);
    }
    
    /// <summary>
    /// L'évènement p_event au registre pour le tour p_turn.
    /// </summary>
    /// <param name="p_turn">Tour</param>
    /// <param name="p_event">Évènement</param>
    public void Add(int p_turn, EventSO p_event)
    {
        if (!m_registers.ContainsKey(p_turn))
            m_registers.Add(p_turn, new Register());
        m_registers[p_turn].Events.Add(p_event);
    }
    
    /// <summary>
    /// Ajoute l'ensemble d'évènements p_events au registre pour le tour p_turn.
    /// </summary>
    /// <param name="p_turn">Tour</param>
    /// <param name="p_events">Collection d'évènements</param>
    public void Add(int p_turn, IEnumerable<EventSO> p_events)
    {
        if (!m_registers.ContainsKey(p_turn))
            m_registers.Add(p_turn, new Register());
        m_registers[p_turn].Events.UnionWith(p_events);
    }
}
