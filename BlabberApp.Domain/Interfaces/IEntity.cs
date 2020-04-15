using System;

//Responsible for identity
namespace BlabberApp.Domain.Interfaces
{
    //Use if single id type is used across all entities
    public interface IEntity
    {
        Guid Id {get;}
    }
}