using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Dominio.Enum;
using Wooza.Entrevista.Infraestrutura.Business.Business;

namespace Wooza.Entrevista.Service.Controllers
{
    [RoutePrefix("PesquisasRefinadas")]
    public class PesquisasController : ApiController
    {
        private PesquisaBusiness _pesquisaBusiness;

        [HttpGet]
        [Route("BuscarPorTipo/{tipo}")]
        [ResponseType(typeof(Plano))]
        public HttpResponseMessage BuscarPorTipoController(TipoPlanoEnum tipo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _pesquisaBusiness = new PesquisaBusiness();

                    var plano = _pesquisaBusiness.BuscarPorTipo(tipo);

                    if (plano.Any())
                        return Request.CreateResponse(HttpStatusCode.OK, plano);
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Plano não encontrado");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new HttpError(ex.ToString()));
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ModelState.ToString()));
        }


        [HttpGet]
        [Route("BuscarPorOperadora/{operadora}")]
        [ResponseType(typeof(Plano))]
        public HttpResponseMessage BuscarPorOperadoraController(OperadoraEnum operadora)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _pesquisaBusiness = new PesquisaBusiness();

                    var plano = _pesquisaBusiness.BuscarPorOperadora(operadora);

                    if (plano.Any())
                        return Request.CreateResponse(HttpStatusCode.OK, plano);
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Plano não encontrado");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new HttpError(ex.ToString()));
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ModelState.ToString()));
        }
    }
}