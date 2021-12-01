using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Services
{
    /// <summary>
    /// An interface that provides an access to the WorkplanProvider class.
    /// </summary>
    public interface IWorkplanProvider
    {
        /// <summary>
        /// A method that provides loading workplans from the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        List<WorkplanModel> LoadWorkplans(string filePath);
        /// <summary>
        /// A method that provides saving workplans to the file.
        /// </summary>
        /// <param name="workplanModels"></param>
        /// <param name="filePath"></param>
        void SaveWorkplan(List<WorkplanModel> workplanModels, string filePath);


    }
}
