namespace Task.Models
{
    /// <summary>
    /// Class holding  Workplan Step information
    /// </summary>
    public class WorkplanStepModel
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Id of previous step. Null when first
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// Id of next step. Null when last
        /// </summary>
        public int? ChildId { get; set; }
    }
}
