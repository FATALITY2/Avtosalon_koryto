using System;
using System.Collections.Generic;
using System.Text;

namespace AutocentreKorytoClientBusinessLogics.HelperModels
{
    class WordParagraph
    {
        public List<(string, WordTextProperties)> Texts { get; set; }

        public WordTextProperties TextProperties { get; set; }
    }
}
