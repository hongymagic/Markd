using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Markd.DomainModels;

namespace Markd.Adaptors
{
    using Interfaces;

    public class AppDataPostAdaptor : IPostAdaptor
    {
        private readonly string _directory;
        public AppDataPostAdaptor(string directory)
        {
            _directory = directory;
        }

        #region Protected virtual helpers
        protected virtual PostDomainModel GetPost(string contents)
        {
            return new PostDomainModel { Content = contents };
        }
        #endregion

        #region Implementation of IPostAdaptor
        public IEnumerable<PostDomainModel> Posts()
        {
            return Directory.GetFiles(_directory, "*.markdown", SearchOption.AllDirectories).Select(file => GetPost(File.ReadAllText(file, Encoding.Unicode))).ToList();
        }
        #endregion
    }
}
