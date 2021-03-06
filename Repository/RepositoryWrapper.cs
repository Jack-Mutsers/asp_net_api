﻿using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IOwnerRepository _owner;
        private IUserRepository _user;
        private IValidationRepository _validation;
        private IComponentRepository _component;
        private ICategorieRepository _Categorie;
        private IAccountRepository _account;

        public IOwnerRepository Owner
        {
            get
            {
                if (_owner == null)
                {
                    _owner = new OwnerRepository(_repoContext);
                }

                return _owner;
            }
        }

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

        public ICategorieRepository Categorie
        {
            get
            {
                if (_Categorie == null)
                {
                    _Categorie = new CategorieRepository(_repoContext);
                }

                return _Categorie;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }

                return _account;
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