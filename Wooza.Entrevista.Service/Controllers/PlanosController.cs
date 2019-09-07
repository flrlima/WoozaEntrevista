using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Dominio.Enum;
using Wooza.Entrevista.Dominio.Repositorio;
using Wooza.Entrevista.Infraestrutura.Business.Business;
using Wooza.Entrevista.Infraestrutura.Data.Contexto;

namespace Wooza.Entrevista.Service.Controllers
{
    [RoutePrefix("Plano")]
    public class PlanosController : ApiController
    {
        private PlanoBusiness _planoBusiness;

        [HttpGet]
        [Route("ConsultarPlanos")]
        [ResponseType(typeof(List<Plano>))]
        public HttpResponseMessage ConsultarTodosOsPlanosController()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _planoBusiness = new PlanoBusiness();

                    var planos = _planoBusiness.ListarTodos();

                    if (planos.ToList().Count > 0)
                        return Request.CreateResponse(HttpStatusCode.OK, planos);
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Não encontramos nenhum plano");
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
        [Route("ConsultarPlano/{id}")]
        [ResponseType(typeof(Plano))]
        public HttpResponseMessage ListarController(Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _planoBusiness = new PlanoBusiness();

                    var plano = _planoBusiness.Listar(id);

                    if (plano.PlanoId != Guid.Empty)
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

        [HttpPut]
        [Route("AtualizarPlano/")]
        [ResponseType(typeof(Plano))]
        public HttpResponseMessage AtualizarPlanoController(Guid id, [FromBody]Plano plano)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _planoBusiness = new PlanoBusiness();

                    if (plano.PlanoId != Guid.Empty)
                    {
                        _planoBusiness.Atualizar(id, plano);
                        return Request.CreateResponse(HttpStatusCode.OK, plano);
                    }
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

        [HttpPost]
        [Route("CriarPlano")]
        //[ResponseType(typeof(Plano))]
        public HttpResponseMessage CriarPlanoController([FromBody]Plano plano)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _planoBusiness = new PlanoBusiness();

                    if (plano.Valor > 0.0 && (plano.Tipo == TipoPlanoEnum.Controle || plano.Tipo == TipoPlanoEnum.Pos ||
                        plano.Tipo == TipoPlanoEnum.Pre) && plano.Minuto > 0 && plano.CodigoDoPlano > 0 )
                    {
                        _planoBusiness.Salvar(plano);
                        return Request.CreateResponse(HttpStatusCode.Created, plano);
                    }
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Ocorreu algum erro, por favor tente inserir o plano novamente");

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
        [Route("RemoverPlano/{id}")]
        [ResponseType(typeof(Plano))]
        public HttpResponseMessage RemoverPlanoController(Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _planoBusiness = new PlanoBusiness();

                    if (id != Guid.Empty)
                    {
                        _planoBusiness.Remover(id);
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
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