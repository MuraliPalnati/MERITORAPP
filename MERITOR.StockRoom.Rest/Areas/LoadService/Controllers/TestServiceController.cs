using log4net;
using MERITOR.StockRoom.DomainEntity;
using MERITOR.StockRoom.Business;
using MERITOR.StockRoom.BusinessInterface;
using MERITOR.StockRoom.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MERITOR.StockRoom.Rest.Areas.Manage.Controllers
{
    public class TestServiceController : ApiController
    {
        private readonly ILog logger = null;
        private readonly IDIBusiness business;
        public TestServiceController()
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            business = new DIBusiness();
        }
        /*
         public class EMPLOYEEsController : ApiController
     {
         private TEJAEntities db = new TEJAEntities();

         // GET: api/EMPLOYEEs
         public IQueryable<EMPLOYEE> GetEMPLOYEEs()
         {
             return db.EMPLOYEEs;
         }

         // GET: api/EMPLOYEEs/5
         [ResponseType(typeof(EMPLOYEE))]
         public IHttpActionResult GetEMPLOYEE(decimal id)
         {
             EMPLOYEE eMPLOYEE = db.EMPLOYEEs.Find(id);
             if (eMPLOYEE == null)
             {
                 return NotFound();
             }

             return Ok(eMPLOYEE);
         }

         // PUT: api/EMPLOYEEs/5
         [ResponseType(typeof(void))]
         public IHttpActionResult PutEMPLOYEE(decimal id, EMPLOYEE eMPLOYEE)
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }

             if (id != eMPLOYEE.ID)
             {
                 return BadRequest();
             }

             db.Entry(eMPLOYEE).State = EntityState.Modified;

             try
             {
                 db.SaveChanges();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!EMPLOYEEExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return StatusCode(HttpStatusCode.NoContent);
         }

         // POST: api/EMPLOYEEs
         [ResponseType(typeof(EMPLOYEE))]
         public IHttpActionResult PostEMPLOYEE(EMPLOYEE eMPLOYEE)
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }

             db.EMPLOYEEs.Add(eMPLOYEE);

             try
             {
                 db.SaveChanges();
             }
             catch (DbUpdateException)
             {
                 if (EMPLOYEEExists(eMPLOYEE.ID))
                 {
                     return Conflict();
                 }
                 else
                 {
                     throw;
                 }
             }

             return CreatedAtRoute("DefaultApi", new { id = eMPLOYEE.ID }, eMPLOYEE);
         }

         // DELETE: api/EMPLOYEEs/5
         [ResponseType(typeof(EMPLOYEE))]
         public IHttpActionResult DeleteEMPLOYEE(decimal id)
         {
             EMPLOYEE eMPLOYEE = db.EMPLOYEEs.Find(id);
             if (eMPLOYEE == null)
             {
                 return NotFound();
             }

             db.EMPLOYEEs.Remove(eMPLOYEE);
             db.SaveChanges();

             return Ok(eMPLOYEE);
         }

         protected override void Dispose(bool disposing)
         {
             if (disposing)
             {
                 db.Dispose();
             }
             base.Dispose(disposing);
         }

         private bool EMPLOYEEExists(decimal id)
         {
             return db.EMPLOYEEs.Count(e => e.ID == id) > 0;
         }
     }
         */
    }
}
