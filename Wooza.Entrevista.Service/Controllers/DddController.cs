using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Infraestrutura.Business.Business;
using Wooza.Entrevista.Service.Dto;

namespace Wooza.Entrevista.Service.Controllers
{
    [RoutePrefix("DDD")]
    public class DddController : ApiController
    {
        private DddBusiness _dddBusiness;

        [HttpGet]
        [Route("ConsultarDDDs")]
        [ResponseType(typeof(List<DddDto>))]
        public HttpResponseMessage ConsultarTodosDddsController()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dddBusiness = new DddBusiness();

                    var planos = _dddBusiness.ListarTodos();

                    if (planos.ToList().Count > 0)
                        return Request.CreateResponse(HttpStatusCode.OK, planos);
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Não encontramos nenhum DDD");
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
        [Route("ConsultarDDD/{codigoDoPlano}")]
        [ResponseType(typeof(DDD))]
        public HttpResponseMessage ListarController(int DddDigito)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dddBusiness = new DddBusiness();

                    var plano = _dddBusiness.Listar(DddDigito.ToString());

                    if (plano != null)
                        return Request.CreateResponse(HttpStatusCode.OK, plano);
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "DDD não encontrado");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new HttpError(ex.ToString()));
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ModelState.ToString()));
        }

        [HttpPut]
        [Route("AtualizarDDD/")]
        [ResponseType(typeof(Plano))]
        public HttpResponseMessage AtualizarPlanoController(Guid id, [FromBody]DDD ddd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dddBusiness = new DddBusiness();

                    if (id != Guid.Empty)
                    {
                        _dddBusiness.Atualizar(id, ddd);
                        return Request.CreateResponse(HttpStatusCode.OK, ddd);
                    }
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "DDD não encontrado");

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new HttpError(ex.ToString()));
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ModelState.ToString()));
        }

        [HttpPost]
        [Route("CriarDDD")]
        [ResponseType(typeof(DDD))]
        public HttpResponseMessage CriarPlanoController([FromBody]DDD ddd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dddBusiness = new DddBusiness();

                    if (!(string.IsNullOrEmpty(ddd.DddDigito) && string.IsNullOrEmpty(ddd.DddEstadoSigla) && 
                        string.IsNullOrEmpty(ddd.DddCidade)))
                    {
                        _dddBusiness.Salvar(ddd);
                        return Request.CreateResponse(HttpStatusCode.Created, ddd);
                    }
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Ocorreu algum erro, por favor tente inserir o DDD novamente");

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new HttpError(ex.ToString()));
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ModelState.ToString()));
        }


        [HttpDelete]
        [Route("RemoverDDD/{id}")]
        [ResponseType(typeof(DDD))]
        public HttpResponseMessage RemoverDddController(Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dddBusiness = new DddBusiness();

                    if (id != Guid.Empty)
                    {
                        _dddBusiness.Remover(id);
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "DDD não encontrado");

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