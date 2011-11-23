using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MarkdownDeep;

namespace Markd.Services
{
    public class DummyMarkdownService
    {
        private const string MARKDOWN_FILTER = @"*.markdown";
        private readonly string _root;

        public DummyMarkdownService(string root)
        {
            _root = root;
        }

        protected string[] FilePaths()
        {
            return Directory.GetFiles(_root, MARKDOWN_FILTER, SearchOption.AllDirectories);
        }
        protected string GetFile(string filePath)
        {
            return File.ReadAllText(filePath, Encoding.Unicode);
        }
        protected string Convert(string text)
        {
            var transformer = new Markdown();
            return transformer.Transform(text);
        }

        public IEnumerable<string> All()
        {
            return FilePaths().Select(filePath => Convert(GetFile(filePath))).ToList();
        }
    }
}
