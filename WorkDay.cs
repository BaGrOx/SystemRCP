﻿namespace SystemRCP_CSV
{
    public class WorkDay
    {
        public string? EmployeeCode { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
