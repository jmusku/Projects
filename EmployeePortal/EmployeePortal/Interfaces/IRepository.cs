﻿using System.Collections.Generic;


namespace EmployeePortal.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        bool Add(T item);

        bool Update(T item);

        bool Delete(int id);
    }
}