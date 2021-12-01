using System.Collections.Generic;

namespace Task.Models
{
    /// <summary>
    /// Class holding workplan information
    /// </summary>
    public class WorkplanModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Workplan Steps
        /// </summary>
        public List<WorkplanStepModel> WorkplanSteps { get; set; }
        /// <summary>
        /// Returns Workplan Steps count
        /// </summary>
        public int StepsCount { get { return WorkplanSteps.Count; } }
    }
}
