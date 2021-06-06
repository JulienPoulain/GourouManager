using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

[System.Flags]
public enum ConditionType
{
    Lesser = 1 << 0,
    Equal = 1 << 1,
    Greater = 1 << 2
}

namespace ConditionTypeMethods
{
    static class ConditionTypeExtensions
    {
        private static bool IsSet(this ConditionType p_conditionType, ConditionType p_flag)
        {
            return (p_conditionType & p_flag) == p_flag;
        }

        public static string GetString(this ConditionType p_conditionType, string p_separator = " ")
        {
            List<string> str = new List<string>();
            
            if (p_conditionType.IsSet(ConditionType.Lesser))
                str.Add("inférieure");
            if (p_conditionType.IsSet(ConditionType.Equal))
                str.Add("égale");
            if (p_conditionType.IsSet(ConditionType.Greater))
                str.Add("supérieure");
            
            return String.Join(p_separator, str);
        }
        
        public static string GetSymbol(this ConditionType p_conditionType, string p_separator = " ")
        {
            List<string> str = new List<string>();
            
            if (p_conditionType.IsSet(ConditionType.Lesser))
                str.Add("<");
            if (p_conditionType.IsSet(ConditionType.Equal))
                str.Add("=");
            if (p_conditionType.IsSet(ConditionType.Greater))
                str.Add(">");
            
            return String.Join(p_separator, str);
        }
    }
}