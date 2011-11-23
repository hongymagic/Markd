using System.Collections.Generic;

namespace Markd.Services.Interfaces
{
    using ViewModels;

    public interface IPostService
    {
        IEnumerable<PostViewModel> Posts();
    }
}