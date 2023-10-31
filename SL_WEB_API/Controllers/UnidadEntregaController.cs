using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WEB_API.Controllers
{
    [RoutePrefix("api/unidadEntrega")]
    public class UnidadEntregaController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.UnidadEntrega unidadEntrega = new ML.UnidadEntrega();
            unidadEntrega.Unidades = BL.UnidadEntrega.GetAll();
            if(unidadEntrega.Unidades != null)
            {
                return Content(HttpStatusCode.OK,unidadEntrega);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,unidadEntrega);
            }
        }
        [Route("{idUnidadEntrega}")]
        [HttpGet]
        public IHttpActionResult GetById(int idUnidadEntrega)
        {
            ML.UnidadEntrega unidadEntrega = BL.UnidadEntrega.GetById(idUnidadEntrega);
            if(unidadEntrega != null)
            {
                return Content(HttpStatusCode.OK, unidadEntrega);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, unidadEntrega);
            }
        }
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.UnidadEntrega unidadEntrega)
        {
            bool coorect = BL.UnidadEntrega.Add(unidadEntrega);
            if (coorect)
            {
                return Content(HttpStatusCode.OK, coorect);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, coorect);
            }
        }
        [Route("{idUnidadEntrega}")]
        [HttpPut]
        public IHttpActionResult Update(int idUnidadEntrega, [FromBody] ML.UnidadEntrega unidadEntrega)
        {
            unidadEntrega.IdUnidad = idUnidadEntrega;
            bool correct = BL.UnidadEntrega.Update(unidadEntrega);
            if (correct)
            {
                return Content(HttpStatusCode.OK, correct);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, correct);
            }
        }
        [Route("{idUnidadEntrega}")]
        [HttpDelete]
        public IHttpActionResult Delete(int idUnidadEntrega)
        {
            bool correct = BL.UnidadEntrega.Delete(idUnidadEntrega);
            if (correct)
            {
                return Content(HttpStatusCode.OK, correct);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, correct);
            }
        }
    }
}
