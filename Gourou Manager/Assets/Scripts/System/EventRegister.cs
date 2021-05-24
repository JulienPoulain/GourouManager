using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventRegister : Singleton<EventRegister>
{
    private SortedDictionary<int, Register> m_registers = new SortedDictionary<int, Register>();

    private class Register
    {
        private HashSet<ExactionSO> m_exactions = new HashSet<ExactionSO>();
        private HashSet<EventSO> m_events = new HashSet<EventSO>();

        public HashSet<ExactionSO> Exactions => m_exactions;
        public HashSet<EventSO> Events => m_events;
    }
    
    private void Awake()
    {
        name = "EventRegister";
    }

    public void AddDay(int p_turn)
    {
        Debug.Log("AddDay");
        if (!m_registers.ContainsKey(p_turn))
            m_registers.Add(p_turn, new Register());
    }

    public List<ExactionSO> GetExactions(int p_turn)
    {
        return m_registers[p_turn].Exactions.ToList();
    }

    public List<EventSO> GetEvents(int p_turn)
    {
        return m_registers[p_turn].Events.ToList();
    }

    public void Add(int p_turn, ExactionSO p_exaction)
    {
        if (!m_registers.ContainsKey(p_turn))
            m_registers.Add(p_turn, new Register());
        m_registers[p_turn].Exactions.Add(p_exaction);
    }
    
    public void Add(int p_turn, IEnumerable<ExactionSO> p_exactions)
    {
        if (!m_registers.ContainsKey(p_turn))
            m_registers.Add(p_turn, new Register());
        m_registers[p_turn].Exactions.UnionWith(p_exactions);
    }
    
    public void Add(int p_turn, EventSO p_event)
    {
        if (!m_registers.ContainsKey(p_turn))
            m_registers.Add(p_turn, new Register());
        m_registers[p_turn].Events.Add(p_event);
    }
    
    public void Add(int p_turn, IEnumerable<EventSO> p_events)
    {
        if (!m_registers.ContainsKey(p_turn))
            m_registers.Add(p_turn, new Register());
        m_registers[p_turn].Events.UnionWith(p_events);
    }
}
