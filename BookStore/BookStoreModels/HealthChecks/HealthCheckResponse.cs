﻿namespace BookStore.Models.HealthChecks
{
    public class HealthCheckResponse
    {
        public string Status { get; set; }

        public IEnumerable<IndividualHealthCheckResponse> HealthChecks { get; set; }

        public TimeSpan HealthCheckDuration { get; set; }
    }
}
