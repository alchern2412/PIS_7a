using lab7a_new.Models;
using lab7a_new.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lab7a_new.Controllers
{
    public class TSController : ApiController
    {
        RecordRepository dictRepository = new RecordRepository();
        // GET: api/TS
        public IEnumerable<Record> Get()
        {
            return dictRepository.GetRecords();
        }

        // GET: api/TS/5
        public Record Get(int id)
        {
            return dictRepository.GetRecords().Where(record => record.Id.Equals(id)).First();
        }

        // POST: api/TS
        public void Post([FromBody]Record value)
        {
            dictRepository.AddRecord(value);
        }

        // PUT: api/TS/5
        public void Put(int id, [FromBody]Record value)
        {
            value.Id = id;
            dictRepository.Update(value);
        }

        // DELETE: api/TS/5
        public void Delete(int id)
        {
            dictRepository.Delete(id);
        }
    }
}
