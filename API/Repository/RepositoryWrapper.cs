using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        //private IUserRepository _user;
        //private IValidationRepository _validation;
        private IComponentRepository _component;
        private ICategoryRepository _Category;

        /*
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }

                return _user;
            }
        }

        public IValidationRepository Validation
        {
            get
            {
                if (_validation == null)
                {
                    _validation = new ValidationRepository(_repoContext);
                }

                return _validation;
            }
        }
        */

        public IComponentRepository Component
        {
            get
            {
                if (_component == null)
                {
                    _component = new ComponentRepository(_repoContext);
                }

                return _component;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_Category == null)
                {
                    _Category = new CategoryRepository(_repoContext);
                }

                return _Category;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}