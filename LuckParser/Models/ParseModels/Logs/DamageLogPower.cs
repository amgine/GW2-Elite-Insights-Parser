﻿namespace LuckParser.Models.ParseModels
{
    public class DamageLogPower : DamageLog
    {

        // Constructor
        public DamageLogPower(long time, CombatItem c) : base(time, c)
        {
            damage =  c.getValue();
        }
    }
}