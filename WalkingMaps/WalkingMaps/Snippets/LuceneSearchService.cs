using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using WalkingMaps.Entities;
using WalkingMaps.Services.Abstract;
using Lucene.Net.Analysis;


namespace WalkingMaps.Services
{
    public class LuceneSearchService : ILuceneSearchService
    {
        public static string _luceneDir;
        private static FSDirectory _directoryTemp;
        private static FSDirectory _directory
        {
            get
            {
                if (_directoryTemp == null) _directoryTemp = FSDirectory.Open(new DirectoryInfo(_luceneDir));
                if (IndexWriter.IsLocked(_directoryTemp)) IndexWriter.Unlock(_directoryTemp);
                var lockFilePath = Path.Combine(_luceneDir, "write.lock");
                if (File.Exists(lockFilePath)) File.Delete(lockFilePath);
                return _directoryTemp;
            }
        }

        public LuceneSearchService(IHostingEnvironment env)
        {           
            _luceneDir = Path.Combine(env.ContentRootPath, "lucene_index");
        }     
      

        public IEnumerable<Sight> GetAllIndexRecords()
        {
            throw new NotImplementedException();
        }

        public static void AddUpdateLuceneIndex(IEnumerable<Sight> sights)
        {
            // init lucene
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);
            using (var writer = new IndexWriter((_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                // add data to lucene search index (replaces older entries if any)
                foreach (var sight in sights) _addToLuceneIndex(sight, writer);

                // close handles
                analyzer.Close();
                writer.Dispose();
            }
        }

        private static void _addToLuceneIndex(Sight sight, IndexWriter writer)
        {
            // remove older index entry
            var searchQuery = new TermQuery(new Term("Id", sight.Id.ToString()));
            writer.DeleteDocuments(searchQuery);

            // add new index entry
            var doc = new Document();

            // add lucene fields mapped to db fields
            doc.Add(new StringField("Id", sight.Id.ToString(), Field.Store.YES));
            doc.Add(new StringField("Name", sight.Name, Field.Store.YES));
            doc.Add(new StringField("Description", sight.Description, Field.Store.YES));
            doc.Add(new StringField("Address", sight.Address, Field.Store.YES));
            doc.Add(new StringField("Author", sight.Author, Field.Store.YES));

            // add entry to index
            writer.AddDocument(doc);
        }
        
    }
}
