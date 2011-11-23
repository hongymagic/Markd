using System.Collections.Generic;

namespace Markd.Adaptors.Interfaces
{
    using DomainModels;

    public interface IPostAdaptor
    {
        IEnumerable<PostDomainModel> Posts();
    }
}