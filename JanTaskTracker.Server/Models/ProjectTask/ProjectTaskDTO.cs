﻿namespace JanTaskTracker.Server.DTOs
{
    public class ProjectTaskDTO
    {
        public int ProjectTaskId { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int AssignedEmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}