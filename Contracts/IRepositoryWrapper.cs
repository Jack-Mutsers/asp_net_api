using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IOwnerRepository Owner { get; }
        IAccountRepository Account { get; }
        IUserRepository User { get; }
        IValidationRepository Validation { get; }
        IComponentRepository Component { get; }
        ICategorieRepository Categorie { get; }
        void Save();
    }
}
