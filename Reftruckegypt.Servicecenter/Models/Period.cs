﻿using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class Period : EntityBase
    {
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string State { get; set; } = PeriodStates.OpenState;

        public void ReverseState()
        {
            if(State == PeriodStates.OpenState)
            {
                State = PeriodStates.ClosedState;
            }
            else
            {
                State = PeriodStates.OpenState;
            }
        }
        public virtual SparePartsPriceList SparePartsPriceList { get; set; }

        public const int MaxPeriodNameLength = 250;
        public const int MaxPeriodStateLength = 50;
    }
    public static class PeriodStates
    {
        public static string OpenState = "Open";
        public static string ClosedState = "Closed";
        public static bool IsValidState(string state)
        {
            return state == OpenState || state == ClosedState;
        }
        public static string[] AllStates = { OpenState, ClosedState };
    }
}
