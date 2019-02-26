using System;
using System.Collections.Generic;

namespace WordFrequencyCounter
{
    /// <summary>
    /// Represents a word - frequency collection considering all Document objects.
    /// </summary>
    public class WordFrequency
    {
        // Total word - frequency map considering the whole documents collection
        private SortedDictionary<string, int> _frequencies = new SortedDictionary<string, int>();

        /// <summary>
        /// Total word - frequency map considering the whole documents collection.
        /// </summary>
        public SortedDictionary<string, int> Frequencies { get { return _frequencies; } }

        /// <summary>
        /// Creates a new instance of word - frequency collection.
        /// </summary>
        /// <param name="documents">Documents collection.</param>
        public WordFrequency(List<Document> documents)
        {
            foreach (Document document in documents)
            {
                foreach (string word in document.Frequencies.Keys)
                {
                    if (!_frequencies.ContainsKey(word))
                    {
                        _frequencies.Add(word, document.Frequencies[word]);
                    }
                    else
                    {
                        _frequencies[word] += document.Frequencies[word];
                        //目前的系統需求不需計算本文詞頻，所以不累加
                        //若往後有該需求，再_frequencies[word] += document.Frequencies[word]
                    }
                }
            }
        }
    }
}
