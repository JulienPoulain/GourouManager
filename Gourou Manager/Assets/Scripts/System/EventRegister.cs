using System.Collections.Generic;
using System.Linq;

public class EventRegister : Singleton<EventRegister>
{
    private SortedDictionary<int, Register> m_registers;

    private class Register
    {
        public HashSet<ExactionSO> m_exactions;
        private HashSet<EventSO> m_events;

        public HashSet<ExactionSO> Exactions => m_exactions;
        public HashSet<EventSO> Events => m_events;
    }

    public void AddDay(int p_turn)
    {
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
        m_registers[p_turn].m_exactions.Add(p_exaction);
    }
    
    public void Add(int p_turn, IEnumerable<ExactionSO> p_exactions)
    {
        m_registers[p_turn].m_exactions.UnionWith(p_exactions);
    }
    
    public void Add(int p_turn, EventSO p_event)
    {
        m_registers[p_turn].Events.Add(p_event);
    }
    
    public void Add(int p_turn, IEnumerable<EventSO> p_events)
    {
        m_registers[p_turn].Events.UnionWith(p_events);
    }
}
