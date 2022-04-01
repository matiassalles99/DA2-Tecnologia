using System;
using System.Collections.Generic;
using Vet.Domain;

namespace Vet.BusinessLogicInterface
{
    public interface IDogLogic
    {
        Dog GetById(int dogId);
        IEnumerable<Dog> GetAll();
        Dog Add(Dog dog);
        void Update(int dogId, Dog dog);
        void Delete(int dogId);
    }
}
