using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        //IUserRepository User { get; }
        //IValidationRepository Validation { get; }
        IComponentRepository Component { get; }
        ICategorieRepository Categorie { get; }
        void Save();
    }
}
