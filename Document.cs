using System;
using System.Linq;
using System.Collections.Generic;

namespace WordFrequencyCounter
{
    /// <summary>
    /// Represents a document containing words.
    /// </summary>
    public class Document
    {
        // Word separators
        private char[] _separators = { ' ', '\n', '\r', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '*', ',', '.', '<', '>', '/', '?', ';', ':', '\'', '\"', '[', ']', '{', '}', '\\', '|', '`', '~' };

        // Document's extracted words
        private List<string> _words;

        // Document's word - frequency map
        private SortedDictionary<string, int> _frequencies = new SortedDictionary<string, int>();

        /// <summary>
        /// Document ID.
        /// </summary>
        public int ID { get; set; }

        public int int總字數含重複 { get { return _words.Count; } }

        /// <summary>
        /// Document's word - frequency map.
        /// </summary>
        public SortedDictionary<String, int> Frequencies { get { return _frequencies; } }

        /// <summary>
        /// Creates a new instance of Document.
        /// </summary>
        /// <param name="text">Document's content.</param>
        public Document(string text)
            : this(text, false)
        {
        }

        /// <summary>
        /// Creates a new instance of Document and specifies whether letter casing will be ignored.
        /// </summary>
        /// <param name="text">Document's content.</param>
        /// <param name="ignoreCase">True if small and capital letters will be treated the same way. False otherwise.</param>
        public Document(string text, bool ignoreCase)
            : this(text, ignoreCase, null)
        {
        }

        /// <summary>
        /// Creates a new instance of Document, specifies whether letter casing will be ignored and specifies an array of stopwrds that will be ignored.
        /// </summary>
        /// <param name="text">Document's content.</param>
        /// <param name="ignoreCase">True if small and capital letters will be treated the same way. False otherwise.</param>
        /// <param name="stopwords">An array of stopwords that will be omitted.</param>
        public Document(string text, bool ignoreCase, string[] stopwords)
        {
            string text小寫接大寫加入空白 = 在小寫接大寫間插入空白(text);

            // Extract words
            _words = text小寫接大寫加入空白.Split(_separators).ToList();

            // Check whether letter case will be ignored
            if (ignoreCase)
            {
                ConvertToLower();
            }

            // Remove stopwords
            if (stopwords != null)
            {
                foreach (string stopword in stopwords)
                {
                    while (_words.Contains(stopword))
                    {
                        _words.Remove(stopword);
                    }
                }
            }

            // Find frequencies
            foreach (string word in _words)
            {
                if (word != string.Empty && word.Length > 2)//2個字母以下的不處理
                {
                    if (!_frequencies.ContainsKey(word))
                    {
                        _frequencies.Add(word, 1);
                    }
                    else
                    {
                        _frequencies[word]++;
                        //目前的系統需求不需計算本文詞頻，所以不累加
                        //若往後有該需求，再_frequencies[word]++
                    }
                }
            }
        }

        private string 在小寫接大寫間插入空白(string text)
        { 
            int textLength = text.Length - 1;
            string rst = null;
            for (int i = 0; i < textLength; i++)
            {
                if ((97 <= Convert.ToInt32(text[i]) && Convert.ToInt32(text[i]) <= 122)
                    &&
                    (65 <= Convert.ToInt32(text[i + 1]) && Convert.ToInt32(text[i + 1]) <= 90)
                   )
                    rst += text[i] + " ";
                else
                    rst += text[i];
            }

            return rst;
        }

        // Ignores letter case
        private void ConvertToLower()
        {
            for (int index = 0; index < _words.Count; index++)
            {
                _words[index] = _words[index].ToLowerInvariant();
            }
        }
    }
}
