using System.Collections.Generic;
using System.Linq;
using MarkdownDeep;

namespace Markd.Services
{
    using Interfaces;
    using Adaptors.Interfaces;
    using ViewModels;
    using DomainModels;

    public class MarkdownPostService : IPostService
    {
        protected readonly IPostAdaptor Adaptor;
        public MarkdownPostService(IPostAdaptor adaptor)
        {
            Adaptor = adaptor;
        }

        #region Protected virtual helpers
        protected virtual PostViewModel Convert(PostDomainModel markdownPostDomainModel)
        {
            var transformer = new Markdown { 
                AutoHeadingIDs = true,
                NewWindowForExternalLinks = true
            };

            return new PostViewModel { HtmlContent = transformer.Transform(markdownPostDomainModel.Content), Content = markdownPostDomainModel.Content };
        }
        #endregion

        #region Implementation of IPostService
        public IEnumerable<PostViewModel> Posts()
        {
            return Adaptor.Posts().Select(Convert).ToList();
        }
        #endregion
    }
}
