﻿namespace HsptMS.Data.Models
{
    public class EmailConfiguration
    {
        public string? From { get; set; }
        public string? Password { get; set; }
        public int Port { get; set; }
        public string? Host { get; set; }
    }
}
