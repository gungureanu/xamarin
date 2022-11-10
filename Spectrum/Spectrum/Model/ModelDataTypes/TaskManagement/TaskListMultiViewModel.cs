using System;
using System.Collections.Generic;
using Spectrum.View.MasterPages;

namespace Spectrum.Model.ModelDataTypes.TaskManagement
{
    public class TaskListMultiViewModel
    {
        public List<string> lstMainLineName { get; set; }
        List<ProjectTasksDetails> lstTasks { get; set; }
        public TaskListMultiViewModel()
        {
            lstTasks = new List<ProjectTasksDetails>();
        }
    }
}
