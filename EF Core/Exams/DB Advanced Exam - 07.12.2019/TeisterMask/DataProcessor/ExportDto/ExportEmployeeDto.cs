namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Collections.Generic;
    public class ExportEmployeeDto
    {
        public string Username { get; set; }

        public ICollection<TaskDto2> Tasks { get; set; }
    }
}
