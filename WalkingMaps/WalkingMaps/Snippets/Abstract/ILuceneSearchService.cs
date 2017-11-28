using Lucene.Net.Index;
using System.Collections.Generic;
using WalkingMaps.Entities;

namespace WalkingMaps.Services.Abstract
{
    public interface ILuceneSearchService
    {
        IEnumerable<Sight> GetAllIndexRecords();
        //void _addToLuceneIndex(Sight sight, IndexWriter writer);
    }
}
