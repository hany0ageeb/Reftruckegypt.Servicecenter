﻿using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class Period : EntityBase
    {
        public string Name { get; set; }
        [Npoi.Mapper.Attributes.Column("From Date")]
        public DateTime FromDate { get; set; }
        [Npoi.Mapper.Attributes.Column("To Date")]
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
        [Npoi.Mapper.Attributes.Ignore()]
        public virtual SparePartsPriceList SparePartsPriceList { get; set; }
        [Npoi.Mapper.Attributes.Ignore()]
        public Period Self => this;

        public const int MaxPeriodStateLength = 50;
        public const int MaxPeriodNameLength = 250;
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
