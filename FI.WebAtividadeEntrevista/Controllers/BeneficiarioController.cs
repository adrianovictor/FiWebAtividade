using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DAL.Beneficiarios.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        private readonly BoBeneficiario _boBeneficiario;

        public BeneficiarioController()
        {
            _boBeneficiario = new BoBeneficiario();
        }
      
        [HttpPost]
        public JsonResult Incluir(IncluirBeneficiarioModel model)
        {
            if (!ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                var result = _boBeneficiario.Executar(new IncluirBeneficiarioCommand(
                    nome: model.Nome,
                    cpf: model.CPF,
                    clienteId: model.ClienteId
                ));

                if (result.HasError)
                {
                    Response.StatusCode = result.ErrorCode;
                    return Json(result.ErrorMessage);
                }
                else return Json("Cadastrdo efetuado com sucesso.");
            }
        }

        [HttpPost]
        public JsonResult Alterar(AtualizarBeneficiarioModel model)
        {
            if (!ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                var result = _boBeneficiario.Executar(new AlterarBeneficiarioCommand(
                    id: model.Id,
                    nome: model.Nome,
                    cpf: model.CPF,
                    clienteId: model.ClienteId
                ));

                if (result.HasError)
                {
                    Response.StatusCode = result.ErrorCode;
                    return Json(result.ErrorMessage);
                }
                else return Json("Cadastrdo efetuado com sucesso.");
            }
        }
    }
}