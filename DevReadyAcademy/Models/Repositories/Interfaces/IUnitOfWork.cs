using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevReadyAcademy.Models.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        ICourseRepository Courses { get; }
        IStudentRepository Students { get; }

        int Save();
    }
}
