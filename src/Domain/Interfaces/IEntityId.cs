using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{

    /// <summary>
    /// Contrato base que asegura que una entidad tenga un identificador único.
    /// </summary>
    public interface IEntityId<TIdentifierType>
    {

        TIdentifierType Id { get;}
    }
}
