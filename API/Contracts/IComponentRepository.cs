﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IComponentRepository
    {
        IEnumerable<Component> GetAllComponents();
        Component GetComponentById(int id);
        Component GetComponentsWithCategory(int cat);
        void CreateComponent (Component comp);
        void UpdateComponent(Component comp);
        void DeleteComponent(Component comp);
        IEnumerable<Component> componentsByCategory(int catId);

    }
}
